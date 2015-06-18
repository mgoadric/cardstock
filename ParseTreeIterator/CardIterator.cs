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
		public static FancyCardLocation[] ProcessCard(CardLanguageParser.CardContext card){
			var ret = ProcessLocation(card.locstorage());
			foreach (var fancy in ret){
				fancy.locIdentifier = card.GetChild(1).GetText();
			}
			return ret;
		}
		public static FancyCardLocation[] ProcessLocation(CardLanguageParser.LocstorageContext loc){
			if (loc.who() != null){
				return new FancyCardLocation[]{
					new FancyCardLocation{cardList=CardGame.Instance.tableCards[loc.namegr().GetText()]}
				};
			}
			else if (loc.who2() != null){
				var resultingEntity = ProcessWho2(loc.who2());
				if (resultingEntity is Player){
					var innerPlayer = resultingEntity as Player;
					return new FancyCardLocation[]{
						new FancyCardLocation{cardList=innerPlayer.cardBins[loc.namegr().GetText()]}
					};
				}
				else if (resultingEntity is Team){
					//Not supported, teams don't have card locations
				}
				else if (resultingEntity is List<Player>){
					var plist = resultingEntity as List<Player>;
					var ret = new FancyCardLocation[plist.Count];
					for (int i = 0; i < plist.Count; ++i){
						ret[i] = new FancyCardLocation{cardList=plist[i].cardBins[loc.namegr().GetText()]};
					}
					return ret;
				}
			}
			return null;
		}
		public static object ProcessWho2(CardLanguageParser.Who2Context who2){
			if (who2.who2() == null){
				//base case
				if (who2.posq() != null){
					if (who2.posq().GetText() == "all"){
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