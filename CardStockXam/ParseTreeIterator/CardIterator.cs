using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics;
using Antlr4.Runtime.Tree;
using CardEngine;

namespace ParseTreeIterator
{
    public class CardIterator
    {
        public static FancyCardLocation ProcessCard(RecycleParser.CardContext card)
        {
            if (card.maxof() != null)
            {
                var scoring = CardGame.Instance.points[card.maxof().var().GetText()];
                var coll = ProcessLocation(card.maxof().cstorage());
                var max = 0;
                Card maxCard = null;
                foreach (var c in coll.cardList.AllCards())
                {
                    //MHG when equal, pick randomly
                    if (scoring.GetScore(c) > max || (scoring.GetScore(c) == max && (new Random()).Next(0, 2) == 0))
                    {
                        //if (scoring.GetScore(c) > max){
                        max = scoring.GetScore(c);
                        maxCard = c;
                    }
                }
                Debug.WriteLine("MAX:" + maxCard);
                var lst = new CardListCollection();
                lst.Add(maxCard);
                return new FancyCardLocation
                {
                    cardList = lst,
                    locIdentifier = "top",
                    //name="MAX"
                };
            }

            if (card.minof() != null)
            {
                var scoring = CardGame.Instance.points[card.minof().var().GetText()];
                var coll = ProcessLocation(card.minof().cstorage());
                var min = Int32.MaxValue;
                Card minCard = null;
                foreach (var c in coll.cardList.AllCards())
                {
                    //MHG when equal, pick randomly
                    if (scoring.GetScore(c) < min || (scoring.GetScore(c) == min && (new Random()).Next(0, 2) == 0))
                    {
                        //if (scoring.GetScore(c) < min) {
                        min = scoring.GetScore(c);
                        minCard = c;
                    }
                }
                Debug.WriteLine("MIN:" + minCard);
                var lst = new CardListCollection();
                lst.Add(minCard);
                return new FancyCardLocation
                {
                    cardList = lst,
                    locIdentifier = "top",
                    //name="MINIMUM"
                };
            }

            if (card.var() != null)
            {
                return VarIterator.ProcessCardVar(card.var());
            }
            if (card.actual() != null){
                var cardLocations = ProcessCard(card.actual().card());
                cardLocations.physicalLocation = true;
                return cardLocations;
            }
            else if (card.cstorage() != null){//cstorage
                var loc = ProcessLocation(card.cstorage());
                return new FancyCardLocation {
                    cardList = loc.cardList,
                    locIdentifier = card.GetChild(1).GetText()
                };
            }
            throw new NotSupportedException();
        }

        public static FancyCardLocation ProcessLocation(RecycleParser.CstorageContext loc)
        {
            if (loc.unionof() != null)
            {
                CardListCollection temp = new CardListCollection();
                if (loc.unionof().cstorage() != null)
                {
                    foreach (var locChild in loc.unionof().cstorage())
                    {
                        var locs = ProcessLocation(locChild);
                        foreach (var card in locs.cardList.AllCards())
                        {
                            temp.Add(card);
                        }
                    }
                }
                else{ //var
                    return VarIterator.ProcessAgg(loc.unionof().agg()) as FancyCardLocation; //TODO?
                }
                return new FancyCardLocation
                {
                    cardList = temp,
                    locIdentifier = "top",
                    //name="UNION"
                };
            }
            else if (loc.filter() != null)
            {
                return VarIterator.ProcessCStorageFilter(loc.filter());
            }
            else if (loc.locpre() != null)
            {
                Debug.WriteLine("Loc");
                if (loc.namegr() != null)
                {
                    return ProcessSubLocation(loc.locpre(), loc.locdesc().GetText(), loc.namegr(), null);
                }
                else
                {
                    return ProcessSubLocation(loc.locpre(), loc.locdesc().GetText(), null, loc.var());
                }
            }
            else if (loc.memstorage() != null){
                Debug.WriteLine("Tuple Track");
                var identifier = loc.memstorage().GetChild(1).GetText();
                var resultingSet = ProcessMemset(loc.memstorage().memset());
                if (identifier == "top") {
                    return new FancyCardLocation {
                        cardList = resultingSet[0].cardList
                    };
                }
                else if (identifier == "bottom")
                {
                    return new FancyCardLocation {
                        cardList = resultingSet[resultingSet.Length - 1].cardList
                    };
                }
                else{
                    return new FancyCardLocation{
                        cardList = resultingSet[Int32.Parse(identifier)].cardList
                    };
                }
            }
            else if (loc.var() != null){
                return VarIterator.ProcessCardStorageVar(loc.var());
            }
            throw new NotSupportedException();
        }

        public static FancyCardLocation[] ProcessMemset(RecycleParser.MemsetContext memset)
        {
            if (memset.tuple() != null)
            {
                var findEm = new CardGrouping(13, CardGame.Instance.points[memset.tuple().var().GetText()]);
                var cardsToScore = new CardListCollection();
                var stor = ProcessLocation(memset.tuple().cstorage());
                foreach (var card in stor.cardList.AllCards())
                {
                    cardsToScore.Add(card);
                }
                var pairs = findEm.TuplesOfSize(cardsToScore, IntIterator.ProcessInt(memset.tuple().@int()));
                var returnList = new FancyCardLocation[pairs.Count];
                for (int i = 0; i < pairs.Count; ++i)
                {
                    returnList[i] = new FancyCardLocation
                    {
                        cardList = pairs[i]
                        //name = "p" + i + "mem" + locpost.namegr().GetText()
                    };
                }
                return returnList;
            }
            return null;
        }
        public static FancyCardLocation ProcessSubLocation(RecycleParser.LocpreContext locpre,
            string desc, RecycleParser.NamegrContext namegr, RecycleParser.VarContext var)
        {
            string prefix = "";
            if (desc == "vloc")
            {
                prefix = "visible";
            }
            else if (desc == "iloc")
            {
                prefix = "invisible";
            }
            else if (desc == "hloc")
            {
                prefix = "hidden";
            }
            else{
                prefix = "mem";
            }
            Player player;
            if (locpre.GetText() == "game")
            {
                if (namegr != null)
                {
                    return new FancyCardLocation
                    {
                        cardList = CardGame.Instance.tableCards["{" + prefix + "}" + namegr]
                    };
                }
                else
                {
                    var name = VarIterator.ProcessStringVar(var);
                    return new FancyCardLocation
                    {
                        cardList = CardGame.Instance.tableCards["{" + prefix + "}" + name]
                    };
                }
            }
            if (locpre.whop() != null)
            {
                player = ProcessWhop(locpre.whop());
            }
            else { 
                player = VarIterator.ProcessWhoVar(locpre.var()) as Player;
            }
            if (namegr != null)
            {
                return new FancyCardLocation
                {
                    cardList = player.cardBins["{" + prefix + "}" + namegr]
                };
            }
            else{
                var name = VarIterator.ProcessStringVar(var);
                return new FancyCardLocation
                {
                    cardList = player.cardBins["{" + prefix + "}" + name]
                };
            }
            Console.WriteLine("NOTHING RETURNED!!!");
            return null;
        }
        public static string ProcessEitherCardatt(IParseTree att)
        {
            return ProcessCardatt(att as RecycleParser.CardattContext);
        }
        public static string ProcessCardatt(RecycleParser.CardattContext cardatt)
        {
            if (cardatt.namegr() != null)
            {
                return cardatt.GetText();
            }
            else if (cardatt.var() != null && cardatt.ChildCount == 1)
            {
                return VarIterator.ProcessStringVar(cardatt.var());
            }
            else
            {
                var loc = ProcessCard(cardatt.card());
                if (cardatt.namegr() != null)
                {
                    return loc.Get().ReadAttribute(cardatt.namegr().GetText());
                }
                else
                {
                    var str = VarIterator.ProcessStringVar(cardatt.var());
                    return loc.Get().ReadAttribute(str);
                }
            }
        }
        public static object ProcessWho(RecycleParser.WhoContext who)
        {
            if (who.whop() == null){
                return ProcessWhop(who.whop());
            }
            else if (who.whot() == null){
                return ProcessWhot(who.whot());
            }
            return null;
        }
        public static Player ProcessWhop(RecycleParser.WhopContext who)
        {
            if (who.owner() != null) {
                var loc = ProcessCard(who.owner().card());
                return loc.Get().owner.container.owner;
            }
            else{
                if (who.GetChild(2).GetText() == "current")
                {
                    return CardGame.Instance.CurrentPlayer().Current();
                }
                else if (who.GetChild(1).GetText() == "next")
                {
                    return CardGame.Instance.CurrentPlayer().PeekNext();
                }
                else if (who.GetChild(1).GetText() == "previous")
                {
                    return CardGame.Instance.CurrentPlayer().PeekPrevious();
                }
                else if (who.whodesc().@int() != null)
                {
                    return CardGame.Instance.players[IntIterator.ProcessInt(who.whodesc().@int())];
                }
            }
            return null;
        }
        public static Team ProcessWhot(RecycleParser.WhotContext who)
        {
            if (who.teamp() != null){
                return ProcessWhop(who.teamp().whop()).team;
            }
            else{
                if (who.GetChild(2).GetText() == "current")
                {
                    return CardGame.Instance.CurrentPlayer().Current().team;
                }
                else if (who.GetChild(1).GetText() == "next")
                {
                    return CardGame.Instance.CurrentPlayer().PeekNext().team;
                }
                else if (who.GetChild(1).GetText() == "previous")
                {
                    return CardGame.Instance.CurrentPlayer().PeekPrevious().team;
                }
                else if (who.whodesc().@int() != null)
                {
                    return CardGame.Instance.players[IntIterator.ProcessInt(who.whodesc().@int())].team;
                }
            }
            return null;
        }
    }
}