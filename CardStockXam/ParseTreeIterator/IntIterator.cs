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
	public class IntIterator{
		
		public static List<int> ProcessListInt(RecycleParser.IntContext intNode){
			
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
				if (intNode.@sizeof().cstorage() != null){
					var size = intNode.@sizeof() as RecycleParser.SizeofContext;
					var loc = size.cstorage() as RecycleParser.CstorageContext;
					var trueLoc = CardIterator.ProcessLocation(loc);
					foreach (var l in trueLoc){
						ret.Add(l.FilteredCount());
					}
					Debug.WriteLine("fCount:"+ret[0]);
				}
				else if (intNode.@sizeof().memset() != null){
					ret.Add(CardIterator.ProcessMemset(intNode.@sizeof().memset()).Count());
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
			else if (intNode.@add() != null){
				ret.Add( ProcessListInt(intNode.@add().@int(0))[0] + ProcessListInt(intNode.@add().@int(1))[0]);
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
					var coll = CardIterator.ProcessLocation(sum.cstorage());
					var total = 0;
					foreach (var loc in coll){
						foreach (var c in loc.FilteredList().AllCards()){
							total += scoring.GetScore(c);
						}
					}
					Debug.WriteLine("Sum:" + total);
					ret.Add(total);
				}
			}
			else if (intNode.owner() != null){
				var own = intNode.owner();
				Debug.WriteLine("Got to OWNER");
				var resultingCard = CardIterator.ProcessCard(own.card())[0].Get();
				Debug.WriteLine("Result :" + resultingCard);
				ret.Add(CardGame.Instance.CurrentPlayer().playerList.IndexOf(resultingCard.owner.container.owner));
				Debug.WriteLine("GOING TO: " + ret.Last());
			}
			else if (intNode.score() != null){
				var scorer = CardGame.Instance.points[intNode.score().namegr().GetText()];
				var card = CardIterator.ProcessCard(intNode.score().card());
				ret.Add(scorer.GetScore(card[0].Get()));
			}
			else{
				ret.Add(0);
			}
			
			return ret;
		}
		public static List<FancyRawStorage> ProcessRawStorage(RecycleParser.RawstorageContext raw){
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
		public static GameActionCollection SetAction(RecycleParser.SetactionContext setAction){
			var ret = new GameActionCollection();
			if (setAction.rawstorage() != null){
				var bins = ProcessRawStorage(setAction.rawstorage());
				var setValue = ProcessListInt(setAction.@int())[0];
				foreach (var bin in bins){
					ret.Add(new IntAction(bin.storage,bin.key,setValue));
				}
			}
			return ret;
		}
		public static GameActionCollection IncAction(RecycleParser.IncactionContext setAction){
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
		public static GameActionCollection DecAction(RecycleParser.DecactionContext setAction){
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