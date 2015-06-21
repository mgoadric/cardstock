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
				Console.WriteLine(intNode.GetText());
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
			
			
			return ret;
		}
		public static List<FancyRawStorage> ProcessRawStorage(CardLanguageParser.RawstorageContext raw){
			var ret = new List<FancyRawStorage>();
			if (raw.who() != null){
				var gamebucket = raw.namegr();
				ret.Add(new FancyRawStorage(CardGame.Instance.gameStorage,gamebucket.GetText()));
			}
			if (raw.who2() != null){
				if (raw.who2().posq() != null){
					if (raw.GetChild(2).GetText() == "team"){
						foreach (var team in CardGame.Instance.teams){
							ret.Add(new FancyRawStorage(team.teamStorage,raw.namegr().GetText()));
						}
					}
					else if (raw.GetChild(2).GetText() == "player"){
						foreach (var player in CardGame.Instance.players){
							ret.Add(new FancyRawStorage(player.storage,raw.namegr().GetText()));
						}
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