using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using Antlr4.Runtime.Tree;
using CardEngine;

namespace ParseTreeIterator
{
	public class CardIterator{

		public static FancyCardLocation[] ProcessCard(RecycleParser.CardmContext cardm){
			var ret = ProcessSubLocation(cardm.memstorage().locpre(),
					cardm.memstorage().locpost());
			foreach (var fancy in ret){
					fancy.locIdentifier = cardm.GetChild(1).GetText();
			}
			return ret;
	
		}
		public static FancyCardLocation[] ProcessCard(RecycleParser.CardpContext cardp){
			var ret = ProcessSubLocation(cardp.locstorage().locpre(),
					cardp.locstorage().locpost());	
			foreach (var fancy in ret){
					fancy.locIdentifier = cardp.GetChild(1).GetText();
			}
			return ret;
		}
		public static FancyCardLocation[] ProcessCard(RecycleParser.CardContext card){
			if (card.maxof() != null){
				var scoring = CardGame.Instance.points[card.maxof().namegr().GetText()];
				var coll = ProcessLocation(card.maxof().cstorage());
				var max = 0;
				Card maxCard = null;
				foreach (var loc in coll){
					foreach (var c in loc.FilteredList().AllCards()){
						if (scoring.GetScore(c) > max){
							max = scoring.GetScore(c);
							maxCard = c;
						}
					}
				}
				Console.WriteLine("MAX:" + maxCard);
				var lst = new CardListCollection();
				lst.Add(maxCard);
				return new FancyCardLocation[1]{
					new FancyCardLocation{
						cardList=lst,
						locIdentifier="top"
					}
				};
			}
			
			if (card.minof() != null){
				var scoring = CardGame.Instance.points[card.minof().namegr().GetText()];
				var coll = ProcessLocation(card.minof().cstorage());
				var min = Int32.MaxValue;
				Card minCard = null;
				foreach (var loc in coll){
					foreach (var c in loc.FilteredList().AllCards()){
						if (scoring.GetScore(c) < min){
							min = scoring.GetScore(c);
							minCard = c;
						}
					}
				}
				Console.WriteLine("MIN:" + minCard);
				var lst = new CardListCollection();
				lst.Add(minCard);
				return new FancyCardLocation[1]{
					new FancyCardLocation{
						cardList=lst,
						locIdentifier="top"
					}
				};
			}
			
			
			
			FancyCardLocation[] ret = null;
			if (card.cardp() != null) {
				ret = ProcessCard(card.cardp());
			} else if (card.cardm() != null) {
				ret = ProcessCard(card.cardm());				
			}
									
			return ret;
		}
		
		public static FancyCardLocation[] ProcessLocation(RecycleParser.CstorageContext loc){
			if (loc.unionof() != null){
				CardListCollection temp = new CardListCollection();
				foreach (var locChild in loc.unionof().cstorage()){
					var locChildren = ProcessLocation(locChild);
					foreach (var subLoc in locChildren){
						foreach (var card in subLoc.FilteredList().AllCards()){
							temp.Add(card);
						}
					}
				}
				return new FancyCardLocation[1]{
					new FancyCardLocation{
						cardList=temp,
						locIdentifier="top"
					}
				};
			} else if (loc.locstorage() != null) {				
				return ProcessSubLocation(loc.locstorage().locpre(), loc.locstorage().locpost());
			} else if (loc.memstorage() != null) {				
				return ProcessSubLocation(loc.memstorage().locpre(), loc.memstorage().locpost());
			}			
			return null;
		}
		public static FancyCardLocation[] ProcessSubLocation(RecycleParser.LocpreContext locpre,
			RecycleParser.LocpostContext locpost) {
			if (locpre.who() != null){
				var clause = ProcessWhere(locpost.whereclause());
				return new FancyCardLocation[]{
					new FancyCardLocation{
						cardList=CardGame.Instance.tableCards[locpost.namegr().GetText()],
						filter=clause
					}
				};
			}
			else if (locpre.who2() != null){
				var resultingEntity = ProcessWho2(locpre.who2());
				if (resultingEntity is Player){
					var innerPlayer = resultingEntity as Player;
					var clause = ProcessWhere(locpost.whereclause());
					return new FancyCardLocation[]{
						new FancyCardLocation{
							cardList=innerPlayer.cardBins[locpost.namegr().GetText()],
							filter=clause
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
						ret[i] = new FancyCardLocation{cardList=plist[i].cardBins[locpost.namegr().GetText()]};
					}
					return ret;
				}
			}
			Console.WriteLine("NOTHING RETURNED!!!");
			return null;
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
			ret.quant = Quantifier.ALL;
			return ret;
		}
		public static string ProcessEitherCardatt(IParseTree att){
			if (att is RecycleParser.CardattContext){
				return ProcessCardatt(att as RecycleParser.CardattContext);
			}
			else{
				
				return ProcessCardattwhere(att as RecycleParser.CardattwhereContext);
			}
		}
		public static string ProcessCardattwhere(RecycleParser.CardattwhereContext caw){
			
			if (caw.ChildCount == 1){
				return caw.GetText();
			}
			else{
				
				return caw.trueany().GetText();
			}
		}
		public static string ProcessCardatt(RecycleParser.CardattContext cardatt){
			if (cardatt.ChildCount == 1){
				return cardatt.GetText();
			}
			else{
			
				var loc = ProcessCard(cardatt.card())[0];
				return loc.Get().ReadAttribute(cardatt.name().GetText());
			
			}
		}
		public static object ProcessWho2(RecycleParser.Who2Context who2){
			if (who2.who2() == null){
				//base case
				if (who2.posq() != null){
					if (who2.posq().GetText() == "all" || who2.posq().GetText() ==  "any"){
						if (who2.GetChild(2).GetText() == "player"){
							return CardGame.Instance.players;
						}
						else{//teams
							return CardGame.Instance.teams;
						}
					}
					
				}
				else if (who2.GetChild(1).GetText() == "current"){
					if (who2.GetChild(2).GetText() == "player"){
						return CardGame.Instance.CurrentPlayer().Current();
					}
					else{//teams
						return CardGame.Instance.CurrentPlayer().Current().team;//TODO change to true current team
					}
				}
				else if (who2.GetChild(1).GetText() == "next"){
					if (who2.GetChild(2).GetText() == "player"){
						return CardGame.Instance.CurrentPlayer().PeekNext();
					}
					else{//teams
						return CardGame.Instance.CurrentPlayer().Current().team;//TODO change to true current team
					}
				}
				else if (who2.GetChild(1).GetText() == "previous"){
					if (who2.GetChild(2).GetText() == "player"){
						return CardGame.Instance.CurrentPlayer().PeekPrevious();
					}
					else{//teams
						return CardGame.Instance.CurrentPlayer().Current().team;//TODO change to true current team
					}
				}
				else if (who2.@int() != null){
					if (who2.GetChild(2).GetText() == "player"){
						return CardGame.Instance.players[IntIterator.ProcessListInt(who2.@int())[0]];
					}
					else{//teams
						return CardGame.Instance.CurrentPlayer().Current().team;//TODO change to true current team
					}
				}
			}
			else{
				//need to recurse
				var subObject = ProcessWho2(who2.who2());
				if (subObject is Player){
					return (subObject as Player).team;
				}
				else if (subObject is Team){
					return (subObject as Team).teamPlayers;
				}
			}
			return null;
		}
		
	}
}