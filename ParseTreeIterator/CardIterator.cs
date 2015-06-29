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
		public static FancyCardLocation[] ProcessCard(RecycleParser.CardContext card){
			if (card.maxof() != null){
				var scoring = CardGame.Instance.points[card.maxof().namegr().GetText()];
				var coll = ProcessLocation(card.maxof().locstorage());
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
			var ret = ProcessLocation(card.locstorage());
			foreach (var fancy in ret){
				fancy.locIdentifier = card.GetChild(1).GetText();
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
				return ProcessSubLocation(loc.locstorage().locpre(), loc.locstorage().locpost);
			} else if (loc.memstorage() != null) {				
				return ProcessSubLocation(loc.memstorage().locpre(), loc.memstorage().locpost);
			}			
			return null;
		}
		public static FancyCardLocation[] ProcessSubLocation(RecycleParser.LocpreContext locpre,
			RecycleParser.LocpostContext locpost) {
			if (locpre.who() != null){
				return new FancyCardLocation[]{
					new FancyCardLocation{cardList=CardGame.Instance.tableCards[locpost.namegr().GetText()]}
				};
			}
			else if (locpre.who2() != null){
				var resultingEntity = ProcessWho2(loc.who2());
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
			return null;
		}
		public static CardFilter ProcessWhere(RecycleParser.WhereclauseContext clause){
			if (clause == null){
				return null;
			}
			var attrcomp = clause.boolatt().attrcomp();
			
			return new CardFilter(new List<CardExpression>{
				new TreeExpression(ProcessCardatt(attrcomp.cardatt(0)),ProcessCardatt(attrcomp.cardatt(1)),(attrcomp.EQOP().GetText() == "=="))
			});
		}
		public static string ProcessCardatt(RecycleParser.CardattContext cardatt){
			if (cardatt.ChildCount == 1){
				return cardatt.GetText();
			}
			else{
				if (cardatt.GetChild(3).GetText() == "this"){
					return cardatt.name().GetText();
				}
				else{
					var loc = ProcessCard(cardatt.card())[0];
					return loc.Get().ReadAttribute(cardatt.name().GetText());
				}
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