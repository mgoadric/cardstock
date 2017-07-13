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
using CardStockXam.CardEngine;

namespace ParseTreeIterator
{
	public class ParseOOPIterator{
		public GameActionCollection ProcessAction(RecycleParser.ActionContext actionNode){
            Debug.WriteLine(actionNode.GetText()); 
			var ret = new GameActionCollection();
            if (actionNode.teamcreate() != null) {
                var teamCreate = actionNode.teamcreate() as RecycleParser.TeamcreateContext;
                ret.Add(new TeamCreateAction(teamCreate));
            }
            else if (actionNode.initpoints() != null) {
                var points = actionNode.initpoints();
                var name = points.var().GetText();
                if (!CardGame.Instance.points.binDict.ContainsKey(name)) {
                    CardGame.Instance.points.AddKey(name);
                }
                List<PointAwards> temp = new List<PointAwards>();
                var awards = points.awards();
                foreach (RecycleParser.AwardsContext award in awards) {
                    string key = "";
                    string value = "";
                    int reward = ProcessInt(award.@int());
                    var iter = award.subaward();
                    foreach (RecycleParser.SubawardContext i in iter) {
                        // TODO Is this working properly? I don't think so!
                        key += i.namegr()[0].GetText() + ",";
                        if (i.namegr().Length > 1) {
							Debug.WriteLine("*** Found a namegr...)" + i.namegr()[1].GetText());

							value += i.namegr()[1].GetText() + ",";
                        }
                        else {
                            Debug.WriteLine("*** Card Att parsing...)");
                            value += ProcessCardatt(i.cardatt()) + ",";
                        }
                 
                    }
                    key = key.Substring(0, key.Length - 1);
                    value = value.Substring(0, value.Length - 1);
                    CardGame.Instance.WriteToFile("A:" + value + " " + reward);
                    temp.Add(new PointAwards(key, value, reward));
                }
                CardGame.Instance.points[name] = new CardScore(temp);
            }
            else if (actionNode.copyaction() != null) {
                Debug.WriteLine("REMEMBER: '" + actionNode.GetText() + "'");
                var copy = ProcessCopy(actionNode.copyaction());
                if (copy != null) { ret.Add(copy); }
                else { Debug.WriteLine("copying from empty, " + actionNode.copyaction().GetText()); }
            }
            else if (actionNode.removeaction() != null) {
                Debug.WriteLine("FORGET: '" + actionNode.GetText() + "'");
                var removeAction = actionNode.removeaction();
                ret.Add(ProcessRemove(removeAction));
            }
            else if (actionNode.moveaction() != null) {
                Debug.WriteLine("MOVE: '" + actionNode.GetText() + "'");
                var move = actionNode.moveaction();
                ret.Add(ProcessMove(move));
            }
            else if (actionNode.shuffleaction() != null) {
                var locations = ProcessLocation(actionNode.shuffleaction().cstorage());
                ret.Add(ProcessShuffle(locations));
            }
            else if (actionNode.setaction() != null) {
                var setAction = actionNode.setaction();
                ret.Add(SetAction(setAction));
            }
            else if (actionNode.incaction() != null) {
                var incAction = actionNode.incaction();
                ret.Add(IncAction(incAction));
            }
            else if (actionNode.decaction() != null) {
                var decAction = actionNode.decaction();
                ret.Add(DecAction(decAction));
            }
            else if (actionNode.cycleaction() != null) {
                ret.Add(CycleAction(actionNode.cycleaction()));
            }
            else if (actionNode.deckcreate() != null) {
                ret.Add(ProcessDeck(actionNode.deckcreate()));
            }
            else if (actionNode.turnaction() != null) {
                ret.Add(new TurnAction());
            }
            else if (actionNode.repeat() != null) {
                ret.AddRange(ProcessRepeat(actionNode.repeat()));
			}
			else{
				Debug.WriteLine("Not Processed: '" + actionNode.GetText() + "'");
                throw new NotImplementedException();
			}
			return ret;
		}

        private GameAction CycleAction(RecycleParser.CycleactionContext cycle)
        {
            string text1 = cycle.GetChild(1).GetText();
            string text2 = cycle.GetChild(2).GetText();
            if (text1 == "next")
            {
                //Set next player
                if (cycle.owner() != null)
                {
                    var idx = ProcessOwner(cycle.owner());
                    return new NextAction(CardGame.Instance.CurrentPlayer(), idx);
                }
                else if (text2 == "next")
                {
                    return new NextAction(CardGame.Instance.CurrentPlayer(), CardGame.Instance.players.IndexOf(CardGame.Instance.CurrentPlayer().PeekNext()));
                }
                else if (text2 == "current")
                {
                    return new NextAction(CardGame.Instance.CurrentPlayer(), CardGame.Instance.players.IndexOf(CardGame.Instance.CurrentPlayer().Current()));
                }
                else if (text2 == "previous")
                {
                    return new NextAction(CardGame.Instance.CurrentPlayer(), CardGame.Instance.players.IndexOf(CardGame.Instance.CurrentPlayer().PeekPrevious()));
                }
            }
            else if (text1 == "current")
            {
                //Set next player
                if (cycle.owner() != null)
                {
                    var idx = ProcessOwner(cycle.owner());
                    return new SetPlayerAction(idx);
                }
                else if (text2 == "next")
                {
                    return new SetPlayerAction(CardGame.Instance.players.IndexOf(CardGame.Instance.CurrentPlayer().PeekNext()));
                }
                else if (text2 == "current")
                {
                    return new SetPlayerAction(CardGame.Instance.players.IndexOf(CardGame.Instance.CurrentPlayer().Current()));
                }
                else if (text2 == "previous")
                {
                    return new SetPlayerAction(CardGame.Instance.players.IndexOf(CardGame.Instance.CurrentPlayer().PeekPrevious()));
                }
            }
            return null;
        }

        public void ProcessDo(RecycleParser.CondactContext[] condact){
            foreach (RecycleParser.CondactContext cond in condact){
                ProcessSingleDo(cond);
            }
        }

        public void ProcessSingleDo(RecycleParser.CondactContext cond) {
			if (cond.boolean() == null || ProcessBoolean(cond.boolean())) { DoAction(cond); }
        }



        public  void DoAction(RecycleParser.CondactContext cond){
            if (cond.multiaction2() != null){
                Debug.WriteLine("Processing conditional multiaction.");
                ProcessMultiaction(cond.multiaction2());
            }
            else{
                Debug.WriteLine("Processing conditional action.");
				ProcessAction(cond.action()).ExecuteAll();
            }
        }

        public  GameActionCollection ProcessRepeat(RecycleParser.RepeatContext rep){
            var ret = new GameActionCollection();
            int idx = 1;
            if (rep.@int() != null){
                idx = ProcessInt(rep.@int());
                for (int i = 0; i < idx; i++){
                    ret.AddRange(ProcessAction(rep.action()));
                }
            }
            else { //'all'
                var card1 = ProcessCard(rep.moveaction().card()[0]);
                var card2 = ProcessCard(rep.moveaction().card()[1]);
                idx = card1.cardList.Count;
                for (int i = 0; i < idx; i++){
                    ret.Add(new FancyCardMoveAction(card1, card2));

                }
            }
            return ret;
        }

        private  int ProcessOwner(RecycleParser.OwnerContext owner) {
            Debug.WriteLine("Got to OWNER");
            var resultingCard = ProcessCard(owner.card()).Get();
            Debug.WriteLine("Result :" + resultingCard);
            return CardGame.Instance.CurrentPlayer().playerList.IndexOf(resultingCard.owner.container.owner);
        }

        public  bool ProcessBoolean(RecycleParser.BooleanContext boolNode) {
            if (boolNode.intop() != null) {
        
                var intop = boolNode.intop();
                var intOne = boolNode.@int(0);
                var intTwo = boolNode.@int(1);
                int trueOne = ProcessInt(intOne);
                int trueTwo = ProcessInt(intTwo);
                if (intop.EQOP() != null) {
                    string text = intop.EQOP().GetText();
                    if (text == "==") {
                        return trueOne == trueTwo;
                    }
                    else if (text == "!=") {
                        return trueOne != trueTwo;
                    }
                }
                else if (intop.COMPOP() != null) {
                    string text = intop.COMPOP().GetText();
                    if (text == ">") {
                        return trueOne > trueTwo;
                    }
                    else if (text == ">=") {
                        return trueOne >= trueTwo;
                    }
                    else if (text == "<") {
                        return trueOne < trueTwo;
                    }
                    else if (text == "<="){
                        return trueOne <= trueTwo;
                    }
                }
            }
			else if (boolNode.UNOP() != null){
				return ! ProcessBoolean(boolNode.boolean(0));
			}
			else if (boolNode.BOOLOP() != null){
                string text = boolNode.BOOLOP().GetText();
				if (text == "or"){
					bool flag = false;
					foreach (var boolean in boolNode.boolean()){
						flag |= ProcessBoolean(boolean);
                        if (flag){
                            return flag;
                        }
					}
					return flag;
				}
				else if (text == "and"){
					bool flag = true;
					foreach (var boolean in boolNode.boolean()){
						flag &= ProcessBoolean(boolean);
						if (!flag){
							return flag;
						}
					}
					return flag;
				}
			}
			else if (boolNode.attrcomp() != null){
				var str1 = ProcessCardatt(boolNode.attrcomp().cardatt(0));
				var str2 = ProcessCardatt(boolNode.attrcomp().cardatt(1));
                Debug.WriteLine(boolNode.GetText());
                Debug.WriteLine(str1 + ", " + str2);
				if (boolNode.attrcomp().EQOP().GetText() == "=="){
                    return str1 == str2;
				}
				else{// == "!="
                    return str1 != str2;
				}
			}
            else if (boolNode.EQOP() != null){
                bool eq = false;
                if (boolNode.EQOP().GetText() == "=="){
                    eq = true;
                }
                if (boolNode.card() != null){
                    var card1 = ProcessCard(boolNode.card()[0]);
                    var card2 = ProcessCard(boolNode.card()[1]);
                    return eq == card1.Equals(card2);
                }
                else if (boolNode.whop() != null){
                    var p1 = ProcessWhop(boolNode.whop()[0]);
                    var p2 = ProcessWhop(boolNode.whop()[1]);
                    return eq == p1.Equals(p2);
                }
                else if (boolNode.whot() != null){
                    var t1 = ProcessWhot(boolNode.whot()[0]);
                    var t2 = ProcessWhot(boolNode.whot()[1]);
                    return eq == t1.Equals(t2);
                }
            }
            else if (boolNode.agg() != null){
                return (bool) ProcessAgg(boolNode.agg());
            }
            throw new NotSupportedException();
		}

        public  GameAction ProcessCopy(RecycleParser.CopyactionContext copy) { //TODO fix this for real
            Debug.WriteLine(copy.GetText());
            var cardOne = ProcessCard(copy.GetChild(1) as RecycleParser.CardContext);
            
            if (cardOne.Count() == 0) {
                Debug.WriteLine(copy.GetText());
                ProcessCard(copy.GetChild(1) as RecycleParser.CardContext);
                return null;
            }
            var cardTwo = ProcessCard(copy.GetChild(2) as RecycleParser.CardContext);
            return new FancyCardCopyAction(cardOne, cardTwo);
        }

		public  GameAction ProcessRemove(RecycleParser.RemoveactionContext removeAction){
			var cardOne = ProcessCard(removeAction.card());
			return new FancyRemoveAction(cardOne);
		}
        public  GameAction ProcessMove(RecycleParser.MoveactionContext move) {
            var cardOne = ProcessCard(move.GetChild(1) as RecycleParser.CardContext);
            var cardTwo = ProcessCard(move.GetChild(2) as RecycleParser.CardContext);
            //Console.WriteLine("Card one: " + ProcessCard(move.GetChild(1) as RecycleParser.CardContext));
            //Console.WriteLine("Card two: " + ProcessCard(move.GetChild(2) as RecycleParser.CardContext));
			return new FancyCardMoveAction(cardOne, cardTwo);
        }

        internal  GameAction ProcessShuffle(FancyCardLocation locations)
        {
            return new ShuffleAction(locations);
        }

        public  FancyCardLocation ProcessCard(RecycleParser.CardContext card)
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
                return ProcessCardVar(card.var());
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

        public  List<object> ProcessOther(RecycleParser.OtherContext other){ //return list of teams or list of players
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

        public  List<FancyCardLocation> ProcessCStorageCollection(RecycleParser.CstoragecollectionContext cstoragecoll)
        {
            if (cstoragecoll.memset() != null){
                var lst = ProcessMemset(cstoragecoll.memset());
                return new List<FancyCardLocation>(lst);
            }
            else if (cstoragecoll.agg() != null){
                return ProcessAgg(cstoragecoll.agg()) as List<FancyCardLocation>;
            }
            else if (cstoragecoll.let() != null){
                ProcessLet(cstoragecoll.let());
                Debug.WriteLine("let, returning nothing");
                return new List<FancyCardLocation>();
            }
            throw new NotSupportedException();
        }

        public  FancyCardLocation ProcessLocation(RecycleParser.CstorageContext loc)
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
                    foreach (var locs in (ProcessAgg(loc.unionof().agg()) as List<FancyCardLocation>))
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
                return ProcessCStorageFilter(loc.filter());
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
                return ProcessCardVar(loc.var());
            }
            throw new NotSupportedException();
        }

        public  FancyCardLocation[] ProcessMemset(RecycleParser.MemsetContext memset)
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
                var pairs = findEm.TuplesOfSize(cardsToScore, ProcessInt(memset.tuple().@int()));
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
        public  FancyCardLocation ProcessSubLocation(RecycleParser.CstorageContext stor)
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
                    if (Get(stor.var()) is String){
                        name = Get(stor.var()) as String;
                    }
                    else{
                        Debug.WriteLine("Error, type is: " + Get(stor.var()).GetType());
                    }

                    // current error here 
                   
                    var fancy = new FancyCardLocation()
                    {
                        cardList = CardGame.Instance.tableCards[prefix + Get(stor.var())],
                        locIdentifier = "top",
                        name = "t" + prefix + Get(stor.var())
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
                player = Get(stor.locpre().var()) as Player;
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
                var name = ProcessStringVar(stor.var());
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
        public  string ProcessCardatt(RecycleParser.CardattContext cardatt)
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
                    return ProcessStringVar(cardatt.var());
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
                            var str = ProcessStringVar(cardatt.var());
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
        public  object ProcessWho(RecycleParser.WhoContext who)
        {
            if (who.whop() != null){
                return ProcessWhop(who.whop());
            }
            else if (who.whot() != null){
                return ProcessWhot(who.whot());
            }
            return null;
        }
        public  Player ProcessWhop(RecycleParser.WhopContext who){
            if (who.owner() != null) {
                var loc = ProcessCard(who.owner().card());
                return loc.Get().owner.container.owner;
            }
            else{
                string text = who.GetChild(1).GetText();
                if (text == "current")
                {
                    return CardGame.Instance.CurrentPlayer().Current();
                }
                else if (text == "next")
                {
                    return CardGame.Instance.CurrentPlayer().PeekNext();
                }
                else if (text == "previous")
                {
                    return CardGame.Instance.CurrentPlayer().PeekPrevious();
                }
                else if (who.whodesc().@int() != null)
                {
                    return CardGame.Instance.players[ProcessInt(who.whodesc().@int())];
                }
            }
            return null;
        }
        public  Team ProcessWhot(RecycleParser.WhotContext who){
            if (who.teamp() != null){
                return ProcessWhop(who.teamp().whop()).team;
            }
            else{
                string text = who.GetChild(1).GetText();
                if (text == "current")
                {
                    return CardGame.Instance.CurrentTeam().Current();
                }
                else if (text == "next")
                {
                    throw new NotImplementedException();
                    //return CardGame.Instance.CurrentTeam().PeekNext();
                }
                else if (text == "previous")
                {
                    throw new NotImplementedException();
					//return CardGame.Instance.CurrentTeam().PeekPrevious();
				}
                else if (who.whodesc().@int() != null)
                {
                    return CardGame.Instance.teams[ProcessInt(who.whodesc().@int())];
                }
            }
            return null;
        }

		public Tree ProcessDeck(RecycleParser.DeckContext deck)
		{
			//var attributeCount = deck.ChildCount - 3;

			List<Node> childs = new List<Node>();
			for (int i = 0; i < deck.attribute().Count(); ++i)
			{
				var att = ProcessAttribute(deck.attribute(i));
				childs.Add(new Node
				{
					Value = "combo" + i,
					children = ProcessAttribute(deck.attribute(i))
				});
			}
			return new Tree
			{
				rootNode = new Node
				{
					Value = "Attrs",
					children = childs
				}
			};
		}


		public  List<Node> ProcessAttribute(RecycleParser.AttributeContext attr) //TODO make this array!!
        {
            if (attr.var() != null) {
                return (Get(attr.var()) as Node[]).OfType<Node>().ToList();
            }
            else {
                var ret = new List<Node>();
                if (!attr.attribute()[0].attribute().Any())
                {
                    var terminalTitle = attr.namegr()[0];
                    var subNode = attr.attribute()[0];
                    if (subNode.var() == null)
                    {
                        var trueCount = (subNode.ChildCount - 3) / 2 + 1;
                        for (int i = 0; i < trueCount; ++i)
                        {
                            ret.Add(new Node
                            {
                                Key = terminalTitle.GetText(),
                                Value = subNode.namegr(i).GetText()
                            });
                        }
                    }
                    else{
                        var strings = Get(subNode.var()) as string[];
                        foreach (string s in strings){
                            ret.Add(new Node
                            {
                                Key = terminalTitle.GetText(),
                                Value = s
                            });
                        }
                    }
                }
                else{
                    var terminalTitle = attr.namegr()[0];
                    var children = attr.attribute();

                    foreach (var subNode in children)
                    {
                        var childs = new List<Node>();
                        foreach (var att in subNode.attribute())
                        {
                            childs.AddRange(ProcessAttribute(att));
                        }
                        ret.Add(new Node
                        {
                            Key = terminalTitle.GetText(),
                            Value = subNode.namegr()[0].GetText(),
                            children = childs
                        });

                    }
                }
                return ret;
            }
        }
		
		public  int ProcessInt(RecycleParser.IntContext intNode){
            if (intNode.rawstorage() != null) {
                var fancy = ProcessRawStorage(intNode.rawstorage());
                return fancy.Get();
            }
            else if (intNode.INTNUM() != null && intNode.INTNUM().Any()) {
                Debug.WriteLine(intNode.GetText());
                return int.Parse(intNode.GetText());
            }
            else if (intNode.@sizeof() != null) {
                if (intNode.@sizeof().cstorage() != null) {
                    return ProcessLocation(intNode.@sizeof().cstorage()).Count();
                }
                else if (intNode.@sizeof().memset() != null) {
                    return ProcessMemset(intNode.@sizeof().memset()).Length;
                }
                else if (intNode.@sizeof().var() != null){
                   
                    var temp = Get(intNode.@sizeof().var());
                    Debug.WriteLine(temp.GetType());
                    var temp2 = temp as FancyCardLocation;
					
                    if (temp2 != null){
                        if (temp2.locIdentifier != "-1"){
                            return temp2.Count();
                        }
                        throw new TypeAccessException();
                    }
                    else{
                        var temp3 = temp as FancyCardLocation[];
                        if (temp3 != null){
                            return temp3.Length;
                        } else {
                            var temp4 = temp as List<Card>;
                            if (temp4 != null)
                            {
                                return temp4.Count();
                            }
                        }
                        throw new TypeAccessException();
                    }
                }
                else {
                    Debug.WriteLine("failed to find size");
                    return 0;
                }
            }
            else if (intNode.mult() != null) {
                return ProcessInt(intNode.mult().@int(0)) * ProcessInt(intNode.mult().@int(1));
            }
            else if (intNode.subtract() != null) {
                return ProcessInt(intNode.subtract().@int(0)) - ProcessInt(intNode.subtract().@int(1));
            }
            else if (intNode.mod() != null) {
                return ProcessInt(intNode.mod().@int(0)) % ProcessInt(intNode.mod().@int(1));
            }
            else if (intNode.divide() != null) {
                return ProcessInt(intNode.divide().@int(0)) / ProcessInt(intNode.divide().@int(1));
            }
            else if (intNode.@add() != null) {
                return ProcessInt(intNode.@add().@int(0)) + ProcessInt(intNode.@add().@int(1));
            }
            else if (intNode.sum() != null) {
                var sum = intNode.sum();
                var scoring = CardGame.Instance.points[sum.var().GetText()];
                var coll = ProcessLocation(sum.cstorage());
                int total = 0;
                foreach (var c in coll.cardList.AllCards()) {
                    total += scoring.GetScore(c);
                }
                Debug.WriteLine("Sum:" + total);
                return total;
            }
            else if (intNode.score() != null) {
                Debug.WriteLine("trying to score" + intNode.GetText());
                var scorer = CardGame.Instance.points[intNode.score().var().GetText()];
                var card = ProcessCard(intNode.score().card());
                return scorer.GetScore(card.Get());
            }
            else if (intNode.var() != null){
                return ProcessIntVar(intNode.var());
            }
            else {
                throw new InvalidDataException();
            }
		}

        public  List<int> ProcessRange(RecycleParser.RangeContext range){
            int int1 = ProcessInt(range.GetChild(2) as RecycleParser.IntContext);
            int int2 = ProcessInt(range.GetChild(4) as RecycleParser.IntContext);
            List<int> ret = new List<int>();
            for (int idx = int1; idx <= int2; idx++){
                ret.Add(idx);
            }
            return ret;
        }

        public  FancyRawStorage AddedRaw(FancyRawStorage stor){
            CardGame.AddToMap(stor);
            return stor;
        }

        public  FancyRawStorage ProcessRawStorage(RecycleParser.RawstorageContext raw){
            if (raw.GetChild(1).GetText() == "game") {
                if (raw.var().Length == 1) {
                    String temp = ProcessStringVar(raw.var()[0]);
                    return AddedRaw(new FancyRawStorage(CardGame.Instance.gameStorage, temp));
                }
                else {
                    return AddedRaw(new FancyRawStorage(CardGame.Instance.gameStorage, raw.namegr().GetText()));

                }
            }
            else if(raw.who() != null){
                if (raw.who().whot() != null){
                    var who = ProcessWho(raw.who()) as Team;
                    if (raw.namegr() != null){
                        return AddedRaw(new FancyRawStorage(who.teamStorage, raw.namegr().GetText()));
                    }
                    else{
                        var temp = ProcessStringVar(raw.var()[0]);
                        return AddedRaw(new FancyRawStorage(who.teamStorage, temp));
                    }
                }
                else if (raw.who().whop() != null){
                    var who = ProcessWho(raw.who()) as Player;
                    if (raw.namegr() != null)
                    {
                        return AddedRaw(new FancyRawStorage(who.storage, raw.namegr().GetText()));
                    }
                    else
                    {
                        var temp = ProcessStringVar(raw.var()[0]);
                        return AddedRaw(new FancyRawStorage(who.storage, temp));
                    }
                }
            }
            else{
                var who = Get(raw.var()[0]);
                if (who.GetType().Name == "Team"){
                    Team temp = who as Team;
                    if (raw.namegr() != null)
                    {
                        return AddedRaw(new FancyRawStorage(temp.teamStorage, raw.namegr().GetText()));
                    }
                    else
                    {
                        var str = ProcessStringVar(raw.var()[1]);
                        return AddedRaw(new FancyRawStorage(temp.teamStorage, str));
                    }
                }
                else{
                    Player temp = who as Player;
                    if (raw.namegr() != null)
                    {
                        return AddedRaw(new FancyRawStorage(temp.storage, raw.namegr().GetText()));
                    }
                    else
                    {
                        var str = ProcessStringVar(raw.var()[1]);
                        return AddedRaw(new FancyRawStorage(temp.storage, str));
                    }
                }
            }
            return null;
		}

        public  GameAction SetAction(RecycleParser.SetactionContext setAction){
            var bin = ProcessRawStorage(setAction.rawstorage());
            var setValue = ProcessInt(setAction.@int());
            return new IntAction(bin.storage, bin.key, setValue);
        }
		public  GameAction IncAction(RecycleParser.IncactionContext setAction){
            var bin = ProcessRawStorage(setAction.rawstorage());
            var setValue = ProcessInt(setAction.@int());
            var newVal = bin.Get() + setValue;
            return new IntAction(bin.storage, bin.key, newVal);
        }
        public  GameAction DecAction(RecycleParser.DecactionContext setAction) {
            var bin = ProcessRawStorage(setAction.rawstorage());
            var setValue = ProcessInt(setAction.@int());
            var newVal = bin.Get() - setValue;
            return new IntAction(bin.storage, bin.key, newVal);
        }

        public  List<Tuple<int,int>> ProcessScore(RecycleParser.ScoringContext scoreMethod){
			var ret = new List<Tuple<int, int>>();

			CardGame.Instance.PushPlayer();
			CardGame.Instance.CurrentPlayer().idx = 0;
			for (int i = 0; i < CardGame.Instance.players.Count; ++i) {
				var working = ProcessInt (scoreMethod.@int ());
                CardGame.Instance.WriteToFile("s:" + working + " " + i);
				ret.Add(new Tuple<int,int>(working,i));
				CardGame.Instance.CurrentPlayer ().Next();
			}

			ret.Sort();
			if (scoreMethod.GetChild(2).GetText() == "max") {
                ret.Reverse();
            }

			return ret;
		}
 
        public  void ProcessTeamCreate(RecycleParser.TeamcreateContext teamCreate){
            var numTeams = teamCreate.teams().Count();
            for (int i = 0; i < numTeams; ++i){
                var newTeam = new Team(i);
                var teamStr = "T:";
                foreach (var p in teamCreate.teams(i).INTNUM()){
                    var j = Int32.Parse(p.GetText());
                    newTeam.teamPlayers.Add(CardGame.Instance.players[j]);
                    CardGame.Instance.players[j].team = newTeam;
                    teamStr += j + " ";
                }
                CardGame.Instance.teams.Add(newTeam);
                CardGame.Instance.WriteToFile(teamStr);
            }

            CardGame.Instance.currentTeam.Push(new StageCycle<Team>(CardGame.Instance.teams));
            Debug.WriteLine("NUMTEAMS:" + CardGame.Instance.teams.Count);

        }

		public  GameActionCollection ProcessSetup(RecycleParser.SetupContext setupNode){
			var ret = new GameActionCollection();
			if (setupNode.playercreate() != null){
                Debug.WriteLine("Creating players.");
				var playerCreate = setupNode.playercreate() as RecycleParser.PlayercreateContext;
                var numPlayers = 2;
                if (playerCreate.@int() != null){
                    numPlayers = ProcessInt(playerCreate.@int());
                }
                else{
                    numPlayers = ProcessIntVar(playerCreate.var());
                }
                CardGame.Instance.WriteToFile("nump:" + numPlayers);
				CardGame.Instance.AddPlayers(numPlayers);
			}
			if (setupNode.teamcreate() != null){
                Debug.WriteLine("Creating teams.");
				var teamCreate = setupNode.teamcreate() as RecycleParser.TeamcreateContext;
				ProcessTeamCreate(teamCreate);
			}
			if (setupNode.deckcreate() != null){
                Debug.WriteLine("Creating decks.");
				var decks = setupNode.deckcreate();
				foreach (var deckinit in decks) {
                    ret.Add(ProcessDeck(deckinit));
				}
			}
            if (setupNode.repeat() != null){
                foreach (var rep in setupNode.repeat()){
                    if (CheckDeckRepeat(rep)){
                        ret.AddRange(ProcessRepeat(rep));
                    }
                    else
                    {
                        throw new InvalidDataException();
                    }
                }
            }
			return ret;
		}

        public  bool CheckDeckRepeat(RecycleParser.RepeatContext reps){
            if (reps.action().deckcreate() != null){
                return true;
            }
            else if (reps.action().repeat() != null){
                return CheckDeckRepeat(reps.action().repeat());
            }
            return false;
        }
        // TODO NAME CONFLICT??
        public  GameAction ProcessDeck(RecycleParser.DeckcreateContext deckinit)
        {
            var locstorage = ProcessLocation(deckinit.cstorage());
            var deckTree = ProcessDeck(deckinit.deck());
            return new InitializeAction(locstorage.cardList, deckTree);
        }
                
        public  List<GameActionCollection> ProcessMultiaction(IParseTree sub)
        {
            var lst = new List<GameActionCollection>();

            if (sub is RecycleParser.MultiactionContext)
            {
                var multiaction = sub as RecycleParser.MultiactionContext;
                Debug.WriteLine(multiaction.GetType());
                if (multiaction.agg() != null)
                {
                    //List<GameAction> test = (List<CardEngine.GameAction>)ProcessAgg(multiaction.agg());
                    //Debug.WriteLine(test[0].GetType());
                    Debug.WriteLine("Processing multiaction aggregation.");
                    lst.Add(ProcessAgg(multiaction.agg()) as GameActionCollection);
                    //lst.AddRange((List<GameActionCollection>)ProcessAgg(multiaction.agg()));

                }
                else if (multiaction.let() != null)
                {
					Debug.WriteLine("Processing multiaction let statement.");
					lst.AddRange(ProcessLet(multiaction.let()));
                }
                else if (multiaction.GetChild(1).GetText() == "choice")
                {
					Debug.WriteLine("Processing multiaction choice block.");

					ProcessChoice(multiaction.condact());
                }
                else if (multiaction.GetChild(1).GetText() == "do")
                {
					Debug.WriteLine("Processing multiaction do statement.");
					ProcessDo(multiaction.condact());
                }
            }
            else if (sub is RecycleParser.StageContext)
            {
                // NEVER HAPPENS, PROCESSED ELSEWHERE
				Debug.WriteLine("Processing stage.");
				//ProcessStage(sub as RecycleParser.StageContext);
            }
            else if (sub is RecycleParser.Multiaction2Context)
            {
                Debug.WriteLine("ur in processing multiaction2");
                var multi = sub as RecycleParser.Multiaction2Context;
                if (multi.agg() != null)
                {
					Debug.WriteLine("Processing multiaction2 aggregation.");
					lst.Add(ProcessAgg(multi.agg()) as GameActionCollection);
                }
                else if (multi.let() != null)
                {
					Debug.WriteLine("Processing multiaction2 let statement.");
					lst.AddRange(ProcessLet(multi.let()));
                }
                else
                {
					Debug.WriteLine("Processing multiaction2 do statement.");
					ProcessDo(multi.condact());
                }
            }
            else {
                Console.WriteLine("What is happening???");
            }
            Debug.WriteLine("Returning list of game actions.");
            return lst;
        }


        // look at where "Put" is called 
        public  List<GameActionCollection> RecurseDo(RecycleParser.CondactContext cond){
            var all = new List<GameActionCollection>();
            // stack of iterating trees
            var stackTrees = new Stack<IteratingTree>();
            // iteratingtree = stack of iterable items (just has basic stack functionality) 
            //      -can store another iteratingtree, strings, or a key/value object
            //      -can copy
            var stackTree = new IteratingTree();
            // internal loop - where things are actually processed, not stored
            stackTree.Push(cond);
			// overarcing loop - stacktrees (another tree is created 
            //    for each ALTERNATIVE (any, etc) action
            //    so that all possible choices can be found
			stackTrees.Push(stackTree);
            var stackAct = new Stack<GameAction>();
            // iterate over stack of stacks
            while (stackTrees.Count != 0)
            {
                stackTree = stackTrees.Pop();
                Debug.WriteLine("Moving to next concurrent game tree");
                Debug.WriteLine("Number of concurrent game states: " + stackTrees.Count);
                // iterate over stack of iterable items
                while (stackTree.Count() != 0)
                {

                    var current = stackTree.Pop();
                    if (current.tree != null)
                    {
                        var currentTree = current.tree;
                        if (currentTree is RecycleParser.CondactContext)
                        {
                            var condact = currentTree as RecycleParser.CondactContext;
                            // if the boolean returns true (and exists), 
                            // push the resulting action/multiaction items
                            // on the current stack of iterable items
                            if (condact.boolean() == null || ProcessBoolean(condact.boolean()))
                            {
                                if (condact.action() != null)
                                {

                                    stackTree.Push(condact.action());
                                }
                                if (condact.multiaction2() != null)
                                {
                                    stackTree.Push(condact.multiaction2());
                                }
                            }
                        }

                        else if (currentTree is RecycleParser.Multiaction2Context)
                        {
							Debug.WriteLine("Finding game actions recursively in a multiaction2 statement.");

							var multi = currentTree as RecycleParser.Multiaction2Context;
                            // is any or and
                            if (multi.agg() != null)
                            {
                                Debug.WriteLine("multiaction context 2 agg pushed to stack");
                                stackTree.Push(multi.agg());
                            }
                            // is let 
                            else if (multi.let() != null)
                            {
                                stackTree.Push(multi.let());
                            }
                            else
                            { // is do
                              // push all condacts onto current stack
                              // to be processed
                                for (int i = multi.condact().Length - 1; i >= 0; i--)
                                {
                                    stackTree.Push(multi.condact()[i]);
                                }
                            }
                        }
                        else if (currentTree is RecycleParser.MultiactionContext){
							Debug.WriteLine("Finding game actions recursively in a multiaction.");
							// terrible terrible ! someday TODO make this not copy paste
							// included to allow multiactions after let statement 
							// if rewritten (to be actually recursive etc etc)
							// could streamline multi & multi2 to be the same thing
							var multi = currentTree as RecycleParser.MultiactionContext;
							if (multi.agg() != null)
							{
								stackTree.Push(multi.agg());
							}
							// is let 
							else if (multi.let() != null)
							{
								stackTree.Push(multi.let());
							}
							else
							{ // is do
							  // push all condacts onto current stack
							  // to be processed

								for (int i = multi.condact().Length - 1; i >= 0; i--)
								{
                                    Debug.WriteLine(multi.condact()[i].GetType());
									stackTree.Push(multi.condact()[i]);
								}
							}

						}
                        else if (currentTree is RecycleParser.AggContext)
                        {
							Debug.WriteLine("Finding game actions recursively in an aggregation statement.");

							var agg = currentTree as RecycleParser.AggContext;
                            var collection = ProcessCollection(agg.collection());
                            if (agg.GetChild(1).GetText() == "any")
                            {
                                // if there is something in the collection
                                if (collection.ToList().Count > 0)
                                {
                                    bool first = true;
                                    object firstItem = null;
                                    var vartext = agg.var().GetText();
                                    // add collection of obj to current stack 
                                    stackTree.Push(currentTree.GetChild(4));

                                    foreach (object item in collection)
                                    {
                                        // for first item in collection only
                                        if (first)
                                        {
                                            firstItem = item;

											Put(vartext, firstItem);
                                            first = false;
                                        }
                                        else
                                        {
                                            // push alternatives onto the stack
                                            // of game actions as 
                                            // an iterable item  
                                            //  (they are unexecutable as loop actions)
                                            // generate a copy of tree to use to
                                            //  process the results of choosing
                                            //  the next item in collection
                                         
                                            var newtree = stackTree.Copy();
                                            stackTrees.Push(newtree);
                                            Debug.WriteLine("pushed non-first any item: " + item);
                                            stackAct.Push(new LoopAction(vartext, item, newtree.level));
                                        }

                                    }
                                    // push first item to be processed (on current
                                    // Stack of game actions )
                                    Debug.WriteLine("pushed first any item: " + firstItem);
                                    stackTree.level++;
                                    stackAct.Push(new LoopAction(vartext, firstItem, stackTree.level));
                                }
                            }
                            else
                            { //all
                                // push
                                //      "'C" (string)
                                //      [contents of statement] (contained
                                //        in another stack tree)
                                //      "'C", iteritem (key, value)



                                foreach (object item in collection)
                                {
                                    stackTree.Push(agg.var().GetText());
                                    stackTree.Push(currentTree.GetChild(4));
                                    stackTree.Push(agg.var().GetText(), item);
                                }

                            }
                        }
                        else if (currentTree is RecycleParser.LetContext)
                        {
							// push name of var, statement after var, name/value pair
							Debug.WriteLine("Finding game actions recursively in a let statement.");

							var let = currentTree as RecycleParser.LetContext;
                            var item = ProcessTyped(let.typed());
                            // old handling of let vars
                            /*stackTree.Push(let.var().GetText());
                            stackTree.Push(currentTree.GetChild(4));
                            stackTree.Push(let.var().GetText(), item);*/

                            Debug.WriteLine("pushed let context");
                            Put(let.var().GetText(), item);
                            stackTree.Push(currentTree.GetChild(4));
                            stackTree.level++;
                            Debug.WriteLine("Pushing loop action" + item);
                            stackAct.Push(new LoopAction(let.var().GetText(), item, stackTree.level));
                        }
                        else if (currentTree is RecycleParser.ActionContext)
                        {
							Debug.WriteLine("Finding game actions recursively in an action. ");

							var actions = ProcessAction(currentTree as RecycleParser.ActionContext);
                            foreach (GameAction action in actions)
							{
                                // TODO where cycle actions are pushed 
                                Debug.WriteLine("pushed action" + action);
								stackAct.Push(action);
                                action.TempExecute();
                            }
                        }
                        else
                        {
                            Debug.WriteLine("failed to parse type " + current.GetType());
                        }
                    }
                    else
                    {//var context
                        
                        if (current.item != null)
                        {
                            Debug.WriteLine("Adding var in RecurseDo: " + current.varContext);

							Put(current.varContext, current.item);
                        }
                        else
                        {

                            Remove(current.varContext);
                        }
                    }
                }
                // end of loop over current stack of iteritems
                var coll = new GameActionCollection();
                foreach (GameAction act in stackAct.ToArray())
                {
                    // add everythign but loop actions to coll
                    if (!(act is LoopAction))
                    {
                        Debug.WriteLine(act);
                        Debug.WriteLine("Adding non-loop action to collection.");
                        coll.Add(act);
                    }
                }

                while (stackAct.Count > 0 && !(stackAct.Peek() is LoopAction))
                {
                    
                    var temp = stackAct.Pop();
                    Debug.WriteLine("Popping non-loop action off (first time)" + temp);
                    temp.Undo();
                }
                if (coll.Count > 0)
                {
                    // puts game action collection back in stack order 
                    // adds list of actions to overall choice list to be returned 
                    coll.Reverse();
                    all.Add(coll);
                }

                // if there are still loopactions,
                //   remove the current one, 
                var currentLevel = 0;
                if (stackAct.Count > 0)
                {
                    var loop = stackAct.Pop() as LoopAction;
                    currentLevel = loop.level;
                    Remove(loop.var);
                }
                // undo everything (until
                bool unwinding = true;
                while (unwinding)
                {
                    // "normal" - item before is loopaction & same level
                    // up one level - item before is loopaction & different level
                    // up one level - items need to be undone before finding loopaction, but is different level
                    // up n levels - 

                    while (stackAct.Count > 0 && !(stackAct.Peek() is LoopAction))
                    {
                        Debug.WriteLine("popping off non-loop action (second time)" + stackAct.Peek());
                        stackAct.Pop().Undo();
                    }
                    if (stackAct.Count > 0)
                    {
                        var loop = stackAct.Peek() as LoopAction;

                        Debug.WriteLine("peek + add : " + loop.item);
                        if (loop.level == currentLevel)
                        {

							Put(loop.var, loop.item);
                            unwinding = false;
                        }
                        else
                        {
                            stackAct.Pop();
                            currentLevel = loop.level;
                        }

                    }
                    else
                    {
                        unwinding = false;
                    }


                }
            
            }
            return all;
        }

        public  void ProcessChoice(RecycleParser.CondactContext[] choices)
        {
            Debug.WriteLine("Player turn: " + CardGame.Instance.CurrentPlayer().idx);
            Debug.WriteLine("Processing choice.");
            var allOptions = new List<GameActionCollection>();
            for (int i = 0; i < choices.Length; ++i)
            {
                Debug.WriteLine("choice info: " + choices[i].GetType() + choices[i].GetText());
                // PROBLEM! TODO when gets through for loop here without pushing any actions (specifically actions)
                //  then throws off number of choices, indexing choices[1] becomes impossible. 
                Debug.WriteLine("in for loop");
                var gacs = RecurseDo(choices[i]);
                if (gacs.Count > 0){
                    Debug.WriteLine("gacs.count > 0");
                    allOptions.AddRange(gacs);
                }
            }
            //BranchingFactor.Instance.AddCount(allOptions.Count, CardGame.Instance.CurrentPlayer().idx);
            if (allOptions.Count != 0){
                Debug.WriteLine("processed choices");
                Debug.WriteLine("Choice count:" + allOptions.Count);
                CardGame.Instance.PlayerMakeChoice(allOptions, CardGame.Instance.CurrentPlayer().idx);
                Debug.WriteLine("player choice made");
                Debug.WriteLine(CardGame.Instance.CurrentPlayer().playerList.Count);
            }
            else
            { 
                Console.WriteLine("NO Choice Available");
                throw new InvalidOperationException();
            }
		}

        public  List<GameActionCollection> ProcessCondactChoice(RecycleParser.CondactContext cond)
        {
			Debug.WriteLine("Processing conditional action choice.");

			var allOptions = new List<GameActionCollection>();
            bool condition = true;
            if (cond.boolean() != null){
                condition = ProcessBoolean(cond.boolean());
            }
            if (condition){
                if (cond.multiaction2() != null)
                {
                    allOptions.AddRange(ProcessMultiaction(cond.multiaction2()));
                }
                else if (cond.action() != null)
                {
                    allOptions.Add(ProcessAction(cond.action()));
                }
            }
            return allOptions;
        }

        public  object Get(RecycleParser.VarContext var){
            return Get(var.GetText());
        }
        public  object Get(String text){
            if (CardGame.Instance.vars.ContainsKey(text)){
                
                return CardGame.Instance.vars[text];
            }
            Debug.WriteLine("Failure");
            throw new Exception("Object " + text + " could not be found");
        }
        public  void Put(string k, Object v){
            CardGame.Instance.vars[k] = v;
           // Console.WriteLine("putting key " + k + " for " + v);
        }
        public  void Remove(string k){
            if (!CardGame.Instance.vars.ContainsKey(k)) {
                throw new KeyNotFoundException();
            }
            CardGame.Instance.vars.Remove(k);
        }
        public  FancyCardLocation ProcessCStorageFilter(RecycleParser.FilterContext filter)
        {
            var cList = new CardListCollection();
            FancyCardLocation stor;
            /*
            Debug.WriteLine(filter.GetText());
            Debug.WriteLine("parent:\n" + filter.Parent.GetText());
            Debug.WriteLine("parent's parent:\n" + filter.Parent.Parent.GetText());
            Debug.WriteLine("parent 3:\n" + filter.Parent.Parent.Parent.GetText());
            Debug.WriteLine("parent 4:\n" + filter.Parent.Parent.Parent.Parent.GetText());
            Debug.WriteLine("parent 5:\n" + filter.Parent.Parent.Parent.Parent.Parent.GetText());
            Debug.WriteLine("\n\n");*/
            IEnumerable<Card> stor2;
            String name2;

            if (filter.collection().cstorage() != null)
            {
                Debug.WriteLine("Filter: cstorage collection");
                stor = ProcessLocation(filter.collection().cstorage());
                stor2 = stor.cardList.AllCards();
                name2 = stor.name;
            }
            else if (filter.collection().var() != null)
            {
                Debug.WriteLine("Filter: variable collection");

                stor = Get(filter.collection().var()) as FancyCardLocation;
                if (stor != null)
                {
                    stor2 = stor.cardList.AllCards();

                    name2 = stor.name;
                }
                else
                {
                    stor2 = Get(filter.collection().var()) as List<Card>;
                    name2 = "FilteredCardListWithoutName";
                }
            }
            else
            {
                throw new NotSupportedException();
            }
            foreach (Card card in stor2)
            {
                string text = filter.var().GetText();
                Put(text, card);
                if (ProcessBoolean(filter.boolean()))
                {
                    cList.Add(card);
                }
                Remove(text);
            }
            var fancy = new FancyCardLocation()
            {
                cardList = cList,
                nonPhysical = true,
                name = name2 + "{filter}" + filter.boolean().GetText(),
            };
            fancy.cardList.loc = fancy;
            CardGame.AddToMap(fancy);
            return fancy;
        }
        // want to clean up & understand processagg TODO
        public  object ProcessAgg(RecycleParser.AggContext agg){
            return IterateAgg(agg, ProcessCollection(agg.collection()));
        }

        public  IEnumerable<object> ProcessCollection(RecycleParser.CollectionContext collection)
        {
          
            if (collection.var() != null){
				Debug.WriteLine("Processing collection type: var.");
                var stor = Get(collection.var());
                if (stor is FancyCardLocation){
                    var card = stor as FancyCardLocation;
                    return card.cardList.AllCards();
                }
                if (stor is string[])
                {
                    return stor as string[];
                }
                if (stor is List<FancyCardLocation>)
                {
                    return stor as List<FancyCardLocation>;
                }
                if (stor is Team)
                {
                    var team = stor as Team;
                    return team.teamPlayers;
                }
                if (stor is List<int>)
                {
                    return stor as List<object>;
                }
            }
            string text = collection.GetText();
            if (collection.cstorage() != null)
            {
                Debug.WriteLine("Processing collection type: Cstorage.");

                var stor = ProcessLocation(collection.cstorage());
                return stor.cardList.AllCards();
            }
            else if (collection.strcollection() != null)
            {
                Debug.WriteLine("Processing collection type: string collection.");

                return ProcessStringCollection(collection.strcollection());
            }
            else if (collection.cstoragecollection() != null)
            {
                Debug.WriteLine("Processing collection type: Cstorage collection.");

                return ProcessCStorageCollection(collection.cstoragecollection());
            }
            else if (collection.whot() != null)
            {
                Debug.WriteLine("Processing collection type: whot.");

                return ProcessWhot(collection.whot()).teamPlayers;
            }
            else if (collection.range() != null)
            {
                Debug.WriteLine("Processing collection type: range.");

                var lst = ProcessRange(collection.range());
                List<object> newlst = new List<object>();
                foreach (int num in lst)
                {
                    newlst.Add((object)num);
                }
                return newlst;
            }
            else if (collection.filter() != null)
            {
                Debug.WriteLine("Processing collection type: filter.");

                var filter = ProcessCStorageFilter(collection.filter());
                return filter.cardList.AllCards();
            }
            else if (text == "player")
            {
                Debug.WriteLine("Processing collection type: players.");

                return CardGame.Instance.players;
            }
            else if (text == "team")
            {
                Debug.WriteLine("Processing collection type: team.");
				return CardGame.Instance.teams;
            }
            else if (collection.other() != null)
            {
                return ProcessOther(collection.other());
            }
            else{//var
				Debug.WriteLine("Processing collection type: var.");
				return (IEnumerable<object>) Get(collection.GetText());
            }
            throw new NotSupportedException();
        }

        private  object IterateAgg<T>(RecycleParser.AggContext agg, IEnumerable<T> stor)
        {

            var ret = new List<object>();
            foreach (T t in stor)
            {
                Debug.WriteLine("Iterating over aggregation of: " + t.GetType());
                Put(agg.var().GetText(), t);
                var post = ProcessAggPost(agg.GetChild(4));
                ret.Add(post);
                Remove(agg.var().GetText());
            }
            // only difference is really in rawstorage & boolean
            Debug.WriteLine(ret.Count);
            // TODO - MULTIACTIONS & ACTIONS NEVER GET HERE... (any & all)
            // Multiaction2 & any actions are handled in processMultiaction & processAction respectively 
            if (agg.GetChild(4) is RecycleParser.CstorageContext)
            {
                Debug.WriteLine("Processing All/Any + Cstorage: " + (((RecycleParser.CstorageContext)agg.GetChild(4)).GetText()));
                var coll = new List<FancyCardLocation>();
                foreach (object obj in ret)
                {
                    coll.Add((FancyCardLocation)obj);
                }
                return coll;
            }
            else if (All(agg))
            {
                if (agg.GetChild(4) is RecycleParser.BooleanContext)
                {
                    Debug.WriteLine("Processing All + Boolean: " + (((RecycleParser.BooleanContext)agg.GetChild(4)).GetText()));
                    var all = true;
                    Debug.WriteLine(agg.GetText());
                    Debug.WriteLine("4: " + agg.GetChild(4).GetText());
                    foreach (object obj in ret)
                    {
                        Debug.WriteLine("i: " + obj);
                        all &= (bool)obj;
                    }
                    return all;

                }
                else if (agg.GetChild(4) is RecycleParser.RawstorageContext)
                {
                    Debug.WriteLine("Processing All + Rawstorage: " + (((RecycleParser.RawstorageContext)agg.GetChild(4)).GetText()));

                    var sum = 0;
                    foreach (object obj in ret)
                    {
                        var raw = (FancyRawStorage)obj;
                        sum += raw.Get();
                    }
                    return sum;
                }
            }
            else // if not an all statement
            {
                if (agg.GetChild(4) is RecycleParser.BooleanContext)
                {
                    Debug.WriteLine("Processing Any + Boolean: " + (((RecycleParser.BooleanContext)agg.GetChild(4)).GetText()));

                    var all = false;
                    foreach (object obj in ret)
                    {
                        all |= (bool)obj;
                    }
                    return all;
                }
                else if (agg.GetChild(4) is RecycleParser.RawstorageContext)
                {
                    Debug.WriteLine("Processing Any + Rawstorage: " + (((RecycleParser.RawstorageContext)agg.GetChild(4)).GetText()));

                    var lst = new List<int>();
                    foreach (object obj in ret)
                    {
                        var raw = (FancyRawStorage)obj;
                        lst.Add(raw.Get());
                    }
                    return lst;
                }
            }
            return ret;
        }

        private  object ProcessAggPost(IParseTree parseTree){
            if (parseTree is RecycleParser.Multiaction2Context){
                return (ICloneable) ProcessMultiaction(parseTree);
            }
            else if (parseTree is RecycleParser.ActionContext){
                Debug.WriteLine("Processing action.");
                return ProcessAction(parseTree as RecycleParser.ActionContext);
            }
            else if (parseTree is RecycleParser.BooleanContext){
                Debug.WriteLine("Processing boolean.");
                return ProcessBoolean(parseTree as RecycleParser.BooleanContext);
            }
            else if (parseTree is RecycleParser.CstorageContext){
                Debug.WriteLine("Finding card.");
                return ProcessLocation(parseTree as RecycleParser.CstorageContext);
            }
            else if (parseTree is RecycleParser.CondactContext){
                Debug.WriteLine("Processing condition for conditional action(s).");
                ProcessSingleDo(parseTree as RecycleParser.CondactContext);
			
                return null;
            }
            else if (parseTree is RecycleParser.RawstorageContext){
                return ProcessRawStorage(parseTree as RecycleParser.RawstorageContext);
            }
            Debug.WriteLine("error: Could not parse " + parseTree.GetText());
            throw new NotSupportedException();
        }

        public  void ProcessDeclare(RecycleParser.DeclareContext declare)
        {
            Put(declare.var().GetText(), ProcessTyped(declare.typed()));
        }

        public  object ProcessTyped(RecycleParser.TypedContext typed)
        {
            if (typed.@int() != null)
            {
                Debug.WriteLine("Processing type: int");
				return ProcessInt(typed.@int());
            }
            else if (typed.boolean() != null)
            {
				Debug.WriteLine("Processing type: boolean");

				return ProcessBoolean(typed.boolean());
            }
            else if (typed.namegr() != null)
            {
				Debug.WriteLine("Processing type: namegr");

				return typed.namegr().GetText();
            }
            else if (typed.var() != null)
            {
				Debug.WriteLine("Processing type: var");

				return Get(typed.var());
            }
            else if (typed.collection() != null)
            {
				Debug.WriteLine("Processing type: collection");

				return ProcessCollection(typed.collection());
            }
            throw new NotSupportedException();
        }

        public  List<GameActionCollection> ProcessLet(RecycleParser.LetContext let){
            var ret = new List<GameActionCollection>(); //TODO check this
            // maybe don't need ProcessTyped ? 
            Put(let.var().GetText(), ProcessTyped(let.typed()));
            if (let.multiaction() != null){
                Debug.WriteLine("Processing let multiaction");
                ret.AddRange(ProcessMultiaction(let.multiaction()));
            }
            else if (let.action() != null){
                Debug.WriteLine("Processing let action");
                ret.Add(ProcessAction(let.action()));
            }
            else if (let.condact() != null){
                Debug.WriteLine("Processing let conditional action " + let.condact().GetText());
                ProcessSingleDo(let.condact());
            }
            Remove(let.var().GetText());
            return ret;
        }

        private  string[] ProcessStringCollection(RecycleParser.StrcollectionContext strcollectionContext)
        {
            string text = strcollectionContext.GetText();
            char[] delimiter = { ',' };
            text = text.Replace("(", string.Empty) ;
            text = text.Replace(")", string.Empty) ;
            var newlst = text.Split(delimiter);
            return newlst;
        }

        public  int ProcessIntVar(RecycleParser.VarContext varContext){
            var temp = Get(varContext.GetText());
            if (temp is FancyRawStorage){
                var raw = temp as FancyRawStorage;
                return raw.Get();
            }
            else if (temp is int) { return (int)temp; }
            else { throw new Exception("Temp is " + temp.GetType()); }
        }

        public  FancyCardLocation ProcessCardVar(RecycleParser.VarContext card){ //TODO get card instead of just top card of location when ret is Card
            var ret = Get(card);
            if (ret is FancyCardLocation)
            {
                var loc = ret as FancyCardLocation;
                if (loc.locIdentifier != "-1")
                {
                    return loc.ShallowCopy();
                }
            }
            else if (ret is Card){
                var c = ret as Card;
                var loc = c.owner.loc.ShallowCopy();                
                loc.setLocId(c);
                return loc;
            }
            Debug.WriteLine("error, type is " + ret.GetType());
            return null;
        }
        public  string ProcessStringVar(RecycleParser.VarContext var)
        {
            return Get(var) as string;
        }
        public  bool All(RecycleParser.AggContext agg){
            return agg.GetChild(1).GetText() == "all";
        }
    }
}
