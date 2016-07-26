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
		
		public static int ProcessListInt(RecycleParser.IntContext intNode){
            if (intNode.rawstorage() != null) {
                var raw = intNode.rawstorage();
                var fancy = ProcessRawStorage(intNode.rawstorage());
                return fancy.Get();
            }
            else if (intNode.INTNUM() != null && intNode.INTNUM().Count() != 0) {
                return int.Parse(intNode.GetText());
            }
            else if (intNode.@sizeof() != null) {
                if (intNode.@sizeof().cstorage() != null) {
                    var size = intNode.@sizeof() as RecycleParser.SizeofContext;
                    var loc = size.cstorage() as RecycleParser.CstorageContext;
                    var trueLoc = CardIterator.ProcessLocation(loc);
                    return trueLoc.FilteredCount();
                }
                else if (intNode.@sizeof().memset() != null) {
                    return CardIterator.ProcessMemset(intNode.@sizeof().memset()).Count());
                }
                else {
                    Debug.WriteLine("failed to find size");
                    return 0;
                }
            }
            else if (intNode.mult() != null) {
                return ProcessListInt(intNode.mult().@int(0)) * ProcessListInt(intNode.mult().@int(1));
            }
            else if (intNode.subtract() != null) {
                return ProcessListInt(intNode.subtract().@int(0)) - ProcessListInt(intNode.subtract().@int(1));
            }
            else if (intNode.mod() != null) {
                return ProcessListInt(intNode.mod().@int(0)) % ProcessListInt(intNode.mod().@int(1)));
            }
            else if (intNode.divide() != null) {
                return ProcessListInt(intNode.divide().@int(0)) / ProcessListInt(intNode.divide().@int(1));
            }
            else if (intNode.@add() != null) {
                return ProcessListInt(intNode.@add().@int(0)) + ProcessListInt(intNode.@add().@int(1));
            }
            else if (intNode.sum() != null) {
                var sum = intNode.sum();
                var scoring = CardGame.Instance.points[sum.var().GetText()];
                var coll = CardIterator.ProcessLocation(sum.cstorage());
                int total = 0;
                foreach (var c in coll.FilteredList().AllCards()) {
                    total += scoring.GetScore(c);
                }
                Debug.WriteLine("Sum:" + total);
                return total;
            }
            else if (intNode.score() != null) {
                var scorer = CardGame.Instance.points[intNode.score().var().GetText()];
                var card = CardIterator.ProcessCard(intNode.score().card());
                return scorer.GetScore(card.Get());
            }
            else {
                return 0;
            }
		}
		public static FancyRawStorage ProcessRawStorage(RecycleParser.RawstorageContext raw){ //TODO
            if (raw.GetChild(1).GetText() == "game") {
                
            }
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
				else if (raw.who2().GetText() == "((currentplayer)team)"){
					ret.Add(new FancyRawStorage(CardGame.Instance.CurrentPlayer().Current().team.teamStorage,
						raw.namegr().GetText()));
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
                    var newVal = bin.Get() + setValue;
					ret.Add(new IntAction(bin.storage,bin.key, newVal));
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
                    var newVal = bin.Get() - setValue;
                    ret.Add(new IntAction(bin.storage, bin.key, newVal));
                }
			}
			return ret;
		}
    }
}