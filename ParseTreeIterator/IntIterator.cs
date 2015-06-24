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
	public class IntIterator{
		
		public static List<int> ProcessListInt(CardLanguageParser.IntContext intNode){
			
			var ret = new List<int>();
			if (intNode.rawstorage() != null){
				var raw = intNode.rawstorage();
				var fancy = ProcessRawStorage(intNode.rawstorage());
				foreach (var fan in fancy){
					ret.Add(fan.Get());
				}
			}
			else if (intNode.INTNUM() != null && intNode.INTNUM().Count() != 0){
				ret.Add(int.Parse(intNode.GetText()));
			}
			else if (intNode.@sizeof() != null){
				var size = intNode.@sizeof() as CardLanguageParser.SizeofContext;
				var loc = size.locstorage() as CardLanguageParser.LocstorageContext;
				var trueLoc = CardIterator.ProcessLocation(loc);
				foreach (var l in trueLoc){
					ret.Add(l.FilteredCount());
				}
			}
			else if (intNode.mult() != null){
				ret.Add(ProcessListInt(intNode.mult().@int(0))[0] * ProcessListInt(intNode.mult().@int(1))[0]); 
			}
			else if (intNode.subtract() != null){
				ret.Add( ProcessListInt(intNode.subtract().@int(0))[0] - ProcessListInt(intNode.subtract().@int(1))[0]);
			}
			
			else if (intNode.mod() != null){
				ret.Add( ProcessListInt(intNode.mod().@int(0))[0] % ProcessListInt(intNode.mod().@int(1))[0]);
			}
			else if (intNode.divide() != null){
				ret.Add( ProcessListInt(intNode.divide().@int(0))[0] / ProcessListInt(intNode.divide().@int(1))[0]);
			}
			else if (intNode.sum() != null){
				if (intNode.sum().rawstorage() != null){
					var list = ProcessRawStorage(intNode.sum().rawstorage());
					var total = 0;
					foreach (var fancyRaw in list){
						total += fancyRaw.Get();
					}
					ret.Add(total);
				}
				else{
					var sum = intNode.sum();
					var scoring = CardGame.Instance.points[sum.namegr().GetText()];
					var coll = CardIterator.ProcessLocation(sum.locstorage());
					var total = 0;
					foreach (var loc in coll){
						foreach (var c in loc.FilteredList().AllCards()){
							total += scoring.GetScore(c);
						}
					}
					Console.WriteLine("Sum:" + total);
					ret.Add(total);
				}
			}
			else if (intNode.owner() != null){
				var own = intNode.owner();
				var resultingCard = CardIterator.ProcessCard(own.card())[0].Get();
				ret.Add(CardGame.Instance.CurrentPlayer().playerList.IndexOf(resultingCard.owner.container.owner));
			}
			else{
				ret.Add(0);
			}
			
			return ret;
		}
		public static List<FancyRawStorage> ProcessRawStorage(CardLanguageParser.RawstorageContext raw){
			var ret = new List<FancyRawStorage>();
			if (raw.who() != null){
				var gamebucket = raw.namegr();
				ret.Add(new FancyRawStorage(CardGame.Instance.gameStorage,gamebucket.GetText()));
			}
			if (raw.who2() != null&&raw.who2().who2() == null){
				if (raw.who2().posq() != null){
					if (raw.who2().GetChild(2).GetText() == "team"){
						foreach (var team in CardGame.Instance.teams){
							ret.Add(new FancyRawStorage(team.teamStorage,raw.namegr().GetText()));
						}
					}
					else if (raw.who2().GetChild(2).GetText() == "player"){
						foreach (var player in CardGame.Instance.players){
							ret.Add(new FancyRawStorage(player.storage,raw.namegr().GetText()));
						}
					}
					
				}
				else{
					if (raw.who2().GetChild(2).GetText() == "team"){
						var curTeam = CardGame.Instance.CurrentTeam().Current();
						ret.Add(new FancyRawStorage(curTeam.teamStorage,raw.namegr().GetText()));
						//Console.WriteLine("STO:" +raw.namegr().GetText() );
					}
					else if (raw.who2().GetChild(2).GetText() == "player"){
						if (raw.who2().GetChild(1).GetText() == "current"){
							var curPlayer = CardGame.Instance.CurrentPlayer().Current();
							ret.Add(new FancyRawStorage(curPlayer.storage,raw.namegr().GetText()));
							//Console.WriteLine("STO:" +raw.namegr().GetText() );
						}
						else if (raw.who2().GetChild(1).GetText() == "next"){
							var curPlayer = CardGame.Instance.CurrentPlayer().PeekNext();
							ret.Add(new FancyRawStorage(curPlayer.storage,raw.namegr().GetText()));
						}
					}
				}
			}
			else if (raw.who2() != null){
				if (raw.who2().GetText() == "((currentteam)player)"){
					foreach (var player in CardGame.Instance.CurrentTeam().Current().teamPlayers){
						ret.Add(new FancyRawStorage(player.storage,raw.namegr().GetText()));
					}
				}
			}
			return ret;
		}
		public static GameActionCollection SetAction(CardLanguageParser.SetactionContext setAction){
			var ret = new GameActionCollection();
			if (setAction.rawstorage() != null){
				var bins = ProcessRawStorage(setAction.rawstorage());
				var setValue = ProcessListInt(setAction.@int())[0];
				foreach (var bin in bins){
					ret.Add(new IntAction(bin.storage,bin.key,setValue));
				}
			}
			else if (setAction.GetChild(1).GetText() == "next"){
				//Set next player
				var idx = ProcessListInt(setAction.@int())[0];
				CardGame.Instance.CurrentPlayer().SetNext(idx);
				Console.WriteLine("Next Player:" + idx);
			}
			return ret;
		}
		public static GameActionCollection IncAction(CardLanguageParser.IncactionContext setAction){
			var ret = new GameActionCollection();
			if (setAction.rawstorage() != null){
				var bins = ProcessRawStorage(setAction.rawstorage());
				var setValue = ProcessListInt(setAction.@int())[0];
				foreach (var bin in bins){
					ret.Add(new IntAction(bin.storage,bin.key,bin.Get() + setValue));
				}
			}
			return ret;
		}
		public static GameActionCollection DecAction(CardLanguageParser.DecactionContext setAction){
			var ret = new GameActionCollection();
			if (setAction.rawstorage() != null){
				var bins = ProcessRawStorage(setAction.rawstorage());
				var setValue = ProcessListInt(setAction.@int())[0];
				foreach (var bin in bins){
					ret.Add(new IntAction(bin.storage,bin.key,bin.Get() - setValue));
				}
			}
			return ret;
		}
		
	}
}