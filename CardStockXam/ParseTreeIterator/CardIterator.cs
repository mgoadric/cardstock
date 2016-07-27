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
	public class CardIterator{
        public static FancyCardLocation ProcessCard(RecycleParser.CardContext card)
        {
            if (card.maxof() != null)
            {
                var scoring = CardGame.Instance.points[card.maxof().var().GetText()];
                var coll = ProcessLocation(card.maxof().cstorage());
                var max = 0;
                Card maxCard = null;
                foreach (var c in coll.FilteredList().AllCards()) {
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
                return new FancyCardLocation {
                        cardList=lst,
                        locIdentifier="top",
                        //name="MAX"
                };
            }

            if (card.minof() != null)
            {
                var scoring = CardGame.Instance.points[card.minof().var().GetText()];
                var coll = ProcessLocation(card.minof().cstorage());
                var min = Int32.MaxValue;
                Card minCard = null;
                foreach (var c in coll.FilteredList().AllCards()) {
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
                return new FancyCardLocation {
                        cardList=lst,
                        locIdentifier="top",
                        //name="MINIMUM"
                };
            }

            if (card.var() != null) {
                return ProcessCardVar(card);
            }
            if (card.actual() != null)
            {
                var temp = card.actual().card() as RecycleParser.CardContext;
                var cardLocations = ProcessCard(temp);
                cardLocations.physicalLocation = true;
                return cardLocations;
            }            
            else {
                if (card.cstorage().var() != null)
                {
                    var temp = VarIterator.ProcessCardStorageVar(card.cstorage());
                    return new FancyCardLocation {
                        cardList = temp.cardList,
                        locIdentifier = card.GetChild(1).GetText()
                    };
                }
                else{
                    var mem = ProcessLocation(card.cstorage());
                    return new FancyCardLocation {
                        cardList = mem.cardList,
                        locIdentifier = card.GetChild(1).GetText()
                    };
                }
            }
        }

        public static FancyCardLocation ProcessPhysical(RecycleParser.CardContext cardp) {
            var ret = ProcessSubLocation(cardp.locstorage().locpre(),
                    cardp.locstorage().locpost(), cardp.locstorage().GetChild(2).GetText() == "iloc",
                cardp.locstorage().GetChild(2).GetText() == "mem");

            foreach (var fancy in ret)
            {
                fancy.locIdentifier = cardp.GetChild(1).GetText();
            }
            return ret;
        }

        public static FancyCardLocation ProcessCardVar(RecycleParser.CardContext cardVar) {
            //TODO
        }

        public static FancyCardLocation ProcessLocation(RecycleParser.CstorageContext loc) {
            if (loc.unionof() != null) {
                CardListCollection temp = new CardListCollection();
                foreach (var locChild in loc.unionof().cstorage()) {
                    var locChildren = ProcessLocation(locChild);
                    foreach (var subLoc in locChildren) {
                        foreach (var card in subLoc.FilteredList().AllCards()) {
                            temp.Add(card);
                        }
                    }
                }
                return new FancyCardLocation{
                        cardList=temp,
                        locIdentifier="top",
                        //name="UNION"
                };
            } else if (loc.filter() != null) { 
                //TODO
            } else if (loc.locpre() != null) {
				Debug.WriteLine("Loc");
                if (loc.namegr() != null) {
                    return ProcessSubLocation(loc.locpre(), loc.namegr(), loc.locdesc().GetText());
                }
                else {
                    return ProcessSubLocation(loc.locpre(), loc.var(), loc.locdesc().GetText());
                }
			} else if (loc.memstorage() != null) {
					Debug.WriteLine("Tuple Track");
					var identifier = loc.memstorage().GetChild(1).GetText();
					var resultingSet = ProcessMemset(loc.memstorage().memset());
                if (identifier == "top")
                {
                    return new FancyCardLocation 
                            resultingSet.Get();
                        ;
                }
                else if (identifier == "bottom")
                {
                    return new FancyCardLocation {
                            //resultingSet.Last() TODO fix
                        };

                }
                else if (loc.memstorage().@int() != null)
                {
                    var processInt = IntIterator.ProcessInt(loc.memstorage().@int())[0];
                    return new FancyCardLocation[1]{
                            resultingSet[processInt]
                        };
                }
                else
                {
                    throw new NotImplementedException("Can't use any (yet) for memset");
                }
				
			}
            else if (loc.var() != null) {
                
            }			
			return null;
		}
		public static FancyCardLocation ProcessMemset(RecycleParser.MemsetContext memset){
			if (memset.tuple() != null){
				var findEm = new CardGrouping(13,CardGame.Instance.points[memset.tuple().var().GetText()]);
				//Pairs
				var cardsToScore = new CardListCollection();
				var cstorageProcessed = ProcessLocation(memset.tuple().cstorage());
				foreach (var fLoc in cstorageProcessed){
					foreach (var card in fLoc.FilteredList().AllCards()){
						cardsToScore.Add(card);
					}
				}
				var pairs = findEm.TuplesOfSize(cardsToScore,IntIterator.ProcessInt(memset.tuple().@int())[0]);
				var returnList = new FancyCardLocation[pairs.Count];
				for (int i = 0; i < pairs.Count; ++i){
                    returnList[i] = new FancyCardLocation {
                        cardList = pairs[i],
                        //name = "MEMSET"
                        //name = "p" + i + "mem" + locpost.namegr().GetText()
                    };
				}
				return returnList;
			}
			return null;
		}
		public static FancyCardLocation ProcessSubLocation(RecycleParser.LocpreContext locpre,
			RecycleParser.LocdescContext desc, RecycleParser.NamegrContext namegr, bool hidden,bool mem) {
            //TODO, this will have to be mostly rewritten (who2 is now who, who is gone (was 'game')
			if (locpre.who() != null){
				var clause = ProcessWhere(desc.whereclause());
                return new FancyCardLocation[]{
					new FancyCardLocation{
						cardList=CardGame.Instance.tableCards[(hidden?"{hidden}":mem?"{mem}":"{visible}") + desc.namegr().GetText()],
						filter=clause,
                        //name="t" + (hidden ? "{hidden}" : mem?"{mem}":"{visible}") + locpost.namegr().GetText()
                    }
				};
			}
			else if (locpre.who2() != null){
				var resultingEntity = ProcessWho2(locpre.who2());
				if (resultingEntity is Player){
					Debug.WriteLine("token:" + locpost.namegr().GetText());
					var innerPlayer = resultingEntity as Player;
					var clause = ProcessWhere(locpost.whereclause());
					return new FancyCardLocation[]{
						new FancyCardLocation{
							cardList=innerPlayer.cardBins[(hidden?"{hidden}":"{visible}") + locpost.namegr().GetText()],
							filter=clause,
                            name =innerPlayer.name + (hidden ? "{hidden}" : mem?"{mem}":"{visible}") + locpost.namegr().GetText()
                        }
					};
				}
				else if (resultingEntity is Team){
					//Not supported, teams don't have card locations
				}
				else if (resultingEntity is List<Player>){
					var plist = resultingEntity as List<Player>;
					var ret = new FancyCardLocation[plist.Count];
					for (int i = 0; i < plist.Count; ++i){
						ret[i] = new FancyCardLocation{cardList=plist[i].cardBins[(hidden?"{hidden}":"{visible}") + locpost.namegr().GetText()],
                                 name ="p" + i + (hidden ? "{hidden}" : "{visible}") + locpost.namegr().GetText() };
					}
					return ret;
				}
			}
			Console.WriteLine("NOTHING RETURNED!!!");
			return null;
		}

        public static FancyCardLocation ProcessSubLocation(RecycleParser.LocpreContext locpre,
            RecycleParser.VarContext loc, bool hidden, bool mem) {
            var newloc = ProcessLocVar(loc);
            //TODO
        }

        public static string ProcessLocVar(RecycleParser.VarContext loc) {
            //TODO
            return "";
        }

        public static CardFilter ProcessWhere(RecycleParser.WhereclauseContext clause){
			if (clause == null){
				return null;
			}
			else{
				return ProcessBooleanWhere(clause.booleanwhere());
			}
			
		}
		public static CardFilter ProcessBooleanWhere(RecycleParser.BooleanwhereContext clause){
			var quantifier = clause.GetChild(1).GetText();
			var tempList = new List<CardExpression>();
			foreach (var conds in clause.whereconditions()){
				if (conds.attrcompwhere() != null){
					var attrcomp = conds.attrcompwhere();
			
					tempList.Add(new TreeExpression(ProcessEitherCardatt(attrcomp.GetChild(1)),ProcessEitherCardatt(attrcomp.GetChild(2)),(attrcomp.EQOP().GetText() == "==")));
				}
				else{//intop, intwhere, intwhere
					var intop = conds.intop();
					var intOne = conds.scorewhere().namegr().GetText();
					var intTwo = IntIterator.ProcessListInt(conds.@int())[0];
					tempList.Add(new ScoreExpression(CardGame.Instance.points[intOne],intop.GetText(),intTwo));
				}
			}
			var ret = new CardFilter(tempList);
			if (quantifier == "all") {
				ret.quant = Quantifier.ALL;
			} else if (quantifier == "any") {
				ret.quant = Quantifier.ANY;
			} else if (quantifier == "none") {
				ret.quant = Quantifier.NONE;
			} 
			return ret;
		}
		public static string ProcessEitherCardatt(IParseTree att){
			return ProcessCardatt(att as RecycleParser.CardattContext);
		}
		public static string ProcessCardatt(RecycleParser.CardattContext cardatt){
			if (cardatt.ChildCount == 1){
				return cardatt.GetText();
			}
            else if (cardatt.var() != null && cardatt.ChildCount == 1) {
                //TODO process card var
                return null;
            }
			else{
				var loc = ProcessCard(cardatt.card())[0];
                if (cardatt.namegr() != null) {
                    return loc.Get().ReadAttribute(cardatt.namegr().GetText());
                }
                else {
                    //TODO ^
                    return loc.Get().ReadAttribute(ProcessCardVar(cardatt.var()));
                }
			
			}
		}
		public static object ProcessWho(RecycleParser.WhoContext who){
			if (who.whop() == null){
                var who2 = who.whop();
				if (who2.GetChild(2).GetText() == "current"){
						return CardGame.Instance.CurrentPlayer().Current();
				}
				else if (who2.GetChild(1).GetText() == "next"){
						return CardGame.Instance.CurrentPlayer().PeekNext();
				}
				else if (who2.GetChild(1).GetText() == "previous"){
						return CardGame.Instance.CurrentPlayer().PeekPrevious();
				}
				else if (who2.whodesc().@int() != null){
						return CardGame.Instance.players[IntIterator.ProcessInt(who2.whodesc().@int())];
				}
			}
            else if (who.whot() == null) {
                var who2 = who.whot();
                if (who2.GetChild(2).GetText() == "current")
                {
                    return CardGame.Instance.CurrentPlayer().Current().team;
                }
                else if (who2.GetChild(1).GetText() == "next")
                {
                    return CardGame.Instance.CurrentPlayer().PeekNext().team;
                }
                else if (who2.GetChild(1).GetText() == "previous")
                {
                    return CardGame.Instance.CurrentPlayer().PeekPrevious().team;
                }
                else if (who2.whodesc().@int() != null)
                {
                    return CardGame.Instance.players[IntIterator.ProcessInt(who2.whodesc().@int())].team;
                }
			}
			return null;
		}
		
	}
}