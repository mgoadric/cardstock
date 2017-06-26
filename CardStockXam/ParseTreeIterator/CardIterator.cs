using System;
using System.Collections.Generic;
using System.Linq;
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
                var fancy = new FancyCardLocation()
                {
                    cardList = lst,
                    locIdentifier = "top",
                    name=coll.name + "{MAX}"
                };
                fancy.cardList.loc = fancy;
                CardGame.AddToMap(fancy);
                return fancy;
            }

            if (card.minof() != null){
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
                var fancy =  new FancyCardLocation()
                {
                    cardList = lst,
                    locIdentifier = "top",
                    name=coll.name + "{MIN}"
                };
                fancy.cardList.loc = fancy;
                CardGame.AddToMap(fancy);
                return fancy;
            }

            if (card.var() != null){
                return VarIterator.ProcessCardVar(card.var());
            }
            if (card.actual() != null){
                var cardLocations = ProcessCard(card.actual().card());
                cardLocations.actual = true;
                return cardLocations;
            }
            else if (card.cstorage() != null){//cstorage
                var loc = ProcessLocation(card.cstorage());
                var fancy = new FancyCardLocation() {
                    cardList = loc.cardList,
                    locIdentifier = card.GetChild(1).GetText(),
                    name = loc.name
                };
                fancy.cardList.loc = fancy;
                CardGame.AddToMap(fancy);
                return fancy;
            }
            throw new NotSupportedException();
        }

        public static List<object> ProcessOther(RecycleParser.OtherContext other){ //return list of teams or list of players
            List<object> lst = new List<object>();
            if (other.GetChild(2).GetText() == "player"){
                foreach (Player p in CardGame.Instance.players){
                    lst.Add(p);
                }
                lst.Remove(CardGame.Instance.currentPlayer.ElementAt(0));
            }
            else{
                foreach (Team t in CardGame.Instance.teams){
                    lst.Add(t);
                }
                lst.Remove(CardGame.Instance.currentTeam);
            }
            return lst;
        }

        public static List<FancyCardLocation> ProcessCStorageCollection(RecycleParser.CstoragecollectionContext cstoragecoll)
        {
            if (cstoragecoll.memset() != null){
                var lst = ProcessMemset(cstoragecoll.memset());
                return new List<FancyCardLocation>(lst);
            }
            else if (cstoragecoll.agg() != null){
                return VarIterator.ProcessAgg(cstoragecoll.agg()) as List<FancyCardLocation>;
            }
            else if (cstoragecoll.let() != null){
                VarIterator.ProcessLet(cstoragecoll.let());
                Debug.WriteLine("let, returning nothing");
                return new List<FancyCardLocation>();
            }
            throw new NotSupportedException();
        }

        public static FancyCardLocation ProcessLocation(RecycleParser.CstorageContext loc)
        {
            string name = "";
            if (loc.unionof() != null)
            {
                CardListCollection temp = new CardListCollection();
                if (loc.unionof().cstorage().Length > 0)
                {
                    foreach (var locChild in loc.unionof().cstorage())
                    {
                        var locs = ProcessLocation(locChild);
                        name += locs.name + " ";
                        foreach (var card in locs.cardList.AllCards())
                        {
                            temp.Add(card);
                        }
                    }
                    name.Remove(name.Length - 1);
                }
                else{ //agg
                    foreach (var locs in (VarIterator.ProcessAgg(loc.unionof().agg()) as List<FancyCardLocation>))
                    {
                        name += locs.name + " ";
                        foreach (var card in locs.cardList.AllCards())
                        {
                            temp.Add(card);
                        }
                    }
                    name.Remove(name.Length - 1);
                }
                var fancy = new FancyCardLocation()
                {
                    cardList = temp,
                    nonPhysical = true,
                    name = name + "{UNION}"
                };
                fancy.cardList.loc = fancy;
                CardGame.AddToMap(fancy);
                return fancy;
            }
            else if (loc.filter() != null)
            {
                return VarIterator.ProcessCStorageFilter(loc.filter());
            }
            else if (loc.locpre() != null)
            {
                Debug.WriteLine("Loc");
                return ProcessSubLocation(loc);
            }
            else if (loc.memstorage() != null){
                Debug.WriteLine("Tuple Track");
                var identifier = loc.memstorage().GetChild(1).GetText();
                var resultingSet = ProcessMemset(loc.memstorage().memset());
                if (identifier == "top") {
                    return resultingSet[0];
                }
                else if (identifier == "bottom"){
                    return resultingSet[resultingSet.Length - 1];
                }
                else{
                    return resultingSet[Int32.Parse(identifier)];
                }
            }
            else if (loc.var() != null){
                return VarIterator.ProcessCardVar(loc.var());
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
                    returnList[i] = new FancyCardLocation()
                    {
                        cardList = pairs[i],
                        nonPhysical = true,
                        name = "{mem}" + memset.tuple().var().GetText() + "{p" + i + "}"
                    };
                    returnList[i].cardList.loc = returnList[i];
                    CardGame.AddToMap(returnList[i]);
                }
                return returnList;
            }
            return null;
        }
        public static FancyCardLocation ProcessSubLocation(RecycleParser.CstorageContext stor)
        {
            string desc = stor.locdesc().GetText();
            string prefix = "";
            if (desc == "vloc")
            {
                prefix = "{visible}";
            }
            else if (desc == "iloc")
            {
                prefix = "{invisible}";
            }
            else if (desc == "hloc")
            {
                prefix = "{hidden}";
            }
            else{
                prefix = "{mem}";
            }
            Player player;
            /*
            Console.WriteLine("parent: " + stor.Parent.GetText());
            Console.WriteLine("next parent: " + stor.Parent.Parent.GetText());
            Console.WriteLine("next next parent " + stor.Parent.Parent.Parent.GetText());
            Console.WriteLine(stor);
            Console.WriteLine(stor.GetText());*/
            if (stor.locpre().GetText() == "game"){
                if (stor.namegr() != null){
                    var fancy = new FancyCardLocation()
                    {
                        cardList = CardGame.Instance.tableCards[prefix + stor.namegr().GetText()],
                        locIdentifier = "top",
                        name = "t" + prefix + stor.namegr().GetText()
                    };
                    fancy.cardList.loc = fancy;
                    CardGame.AddToMap(fancy);
                    return fancy;
                }
                else{
                    var name = "";
                    if (VarIterator.Get(stor.var()) is String){
                        name = VarIterator.Get(stor.var()) as String;
                    }
                    else{
                        Debug.WriteLine("Error, type is: " + VarIterator.Get(stor.var()).GetType());
                    }

                    // current error here 
                   
                    var fancy = new FancyCardLocation()
                    {
                        cardList = CardGame.Instance.tableCards[prefix + VarIterator.Get(stor.var())],
                        locIdentifier = "top",
                        name = "t" + prefix + VarIterator.Get(stor.var())
                    };
                    fancy.cardList.loc = fancy;
                    CardGame.AddToMap(fancy);
                    return fancy;
                }
            }
            if (stor.locpre().whop() != null){
                player = ProcessWhop(stor.locpre().whop());
            }
            else {
                player = VarIterator.Get(stor.locpre().var()) as Player;
            }
            if (stor.namegr() != null)
            {
                var fancy = new FancyCardLocation()
                {
                    cardList = player.cardBins[ prefix + stor.namegr().GetText()],
                    name = player.name + prefix + stor.namegr().GetText()
                };
                fancy.cardList.loc = fancy;
                CardGame.AddToMap(fancy);
                return fancy;
            }
            else{
                var name = VarIterator.ProcessStringVar(stor.var());
                var fancy = new FancyCardLocation()
                {
                    cardList = player.cardBins[prefix + name],
                    name = player.name + prefix + name
                };
                fancy.cardList.loc = fancy;
                CardGame.AddToMap(fancy);
                return fancy;
            }
        }
        public static string ProcessCardatt(RecycleParser.CardattContext cardatt)
        {
            if (cardatt.ChildCount == 1)
            {
                if (cardatt.namegr() != null)
                {
                    Debug.WriteLine("Att1 is " + cardatt.GetText());
                    return cardatt.GetText();
                }
                else if (cardatt.var() != null && cardatt.ChildCount == 1)
                {
                    return VarIterator.ProcessStringVar(cardatt.var());
                }
            }
            else
            {
                var loc = ProcessCard(cardatt.card());
                if (loc.cardList.Count > 0)
                {
                    var card = loc.Get();
                    if (card != null)
                    {
                        if (cardatt.namegr() != null)
                        {
                            Debug.WriteLine("Att2 is " + card.ReadAttribute(cardatt.namegr().GetText()));
                            return card.ReadAttribute(cardatt.namegr().GetText());
                        }
                        else
                        {
                            var str = VarIterator.ProcessStringVar(cardatt.var());
                            Debug.WriteLine("Att3 is " + card.ReadAttribute(str));
                            return card.ReadAttribute(str);
                        }
                    }
                }
            }
            Debug.WriteLine("Empty Attribute, no cards found");
			//throw new NotSupportedException();
			return "";
        }
        public static object ProcessWho(RecycleParser.WhoContext who)
        {
            if (who.whop() != null){
                return ProcessWhop(who.whop());
            }
            else if (who.whot() != null){
                return ProcessWhot(who.whot());
            }
            return null;
        }
        public static Player ProcessWhop(RecycleParser.WhopContext who){
            if (who.owner() != null) {
                var loc = ProcessCard(who.owner().card());
                return loc.Get().owner.container.owner;
            }
            else{
                if (who.GetChild(1).GetText() == "current")
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
        public static Team ProcessWhot(RecycleParser.WhotContext who){
            if (who.teamp() != null){
                return ProcessWhop(who.teamp().whop()).team;
            }
            else{
                if (who.GetChild(1).GetText() == "current")
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