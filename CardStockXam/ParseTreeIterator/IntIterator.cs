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
		
		public static int ProcessInt(RecycleParser.IntContext intNode){
            if (intNode.rawstorage() != null) {
                var fancy = ProcessRawStorage(intNode.rawstorage());
                return fancy.Get();
            }
            else if (intNode.INTNUM() != null && intNode.INTNUM().Count() != 0) {
                return int.Parse(intNode.GetText());
            }
            else if (intNode.@sizeof() != null) {
                if (intNode.@sizeof().cstorage() != null) {
                    return CardIterator.ProcessLocation(intNode.@sizeof().cstorage()).Count();
                }
                else if (intNode.@sizeof().memset() != null) {
                    return CardIterator.ProcessMemset(intNode.@sizeof().memset()).Length;
                }
                else if (intNode.@sizeof().var() != null){
                    var temp = VarIterator.Get(intNode.@sizeof().var());
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
                var coll = CardIterator.ProcessLocation(sum.cstorage());
                int total = 0;
                foreach (var c in coll.cardList.AllCards()) {
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
            else if (intNode.var() != null){
                return VarIterator.ProcessIntVar(intNode.var());
            }
            else {
                throw new InvalidDataException();
            }
		}

        public static List<int> ProcessRange(RecycleParser.RangeContext range){
            int int1 = ProcessInt(range.GetChild(2) as RecycleParser.IntContext);
            int int2 = ProcessInt(range.GetChild(4) as RecycleParser.IntContext);
            List<int> ret = new List<int>();
            for (int idx = int1; idx < int2; idx++){
                ret.Add(idx);
            }
            return ret;
        }

        public static FancyRawStorage ProcessRawStorage(RecycleParser.RawstorageContext raw){
            if (raw.GetChild(1).GetText() == "game") {
                if (raw.var() != null) {
                    String temp = VarIterator.ProcessStringVar(raw.var()[0]);
                    return new FancyRawStorage(CardGame.Instance.gameStorage, temp);
                }
                else {
                    return new FancyRawStorage(CardGame.Instance.gameStorage, raw.namegr().GetText());
                }
            }
            else if(raw.who() != null){
                if (raw.who().whot() != null){
                    var who = CardIterator.ProcessWho(raw.who()) as Team;
                    if (raw.namegr() != null){
                        return new FancyRawStorage(who.teamStorage, raw.namegr().GetText());
                    }
                    else{
                        var temp = VarIterator.ProcessStringVar(raw.var()[0]);
                        return new FancyRawStorage(who.teamStorage, temp);
                    }
                }
                else if (raw.who().whop() != null){
                    var who = CardIterator.ProcessWho(raw.who()) as Player;
                    if (raw.namegr() != null)
                    {
                        return new FancyRawStorage(who.storage, raw.namegr().GetText());
                    }
                    else
                    {
                        var temp = VarIterator.ProcessStringVar(raw.var()[0]);
                        return new FancyRawStorage(who.storage, temp);
                    }
                }
            }
            else{
                var who = VarIterator.Get(raw.var()[0]);
                if (who.GetType().Name == "Team"){
                    Team temp = who as Team;
                    if (raw.namegr() != null)
                    {
                        return new FancyRawStorage(temp.teamStorage, raw.namegr().GetText());
                    }
                    else
                    {
                        var str = VarIterator.ProcessStringVar(raw.var()[1]);
                        return new FancyRawStorage(temp.teamStorage, str);
                    }
                }
                else{
                    Player temp = who as Player;
                    if (raw.namegr() != null)
                    {
                        return new FancyRawStorage(temp.storage, raw.namegr().GetText());
                    }
                    else
                    {
                        var str = VarIterator.ProcessStringVar(raw.var()[1]);
                        return new FancyRawStorage(temp.storage, str);
                    }
                }
            }
            return null;
		}

        public static GameAction SetAction(RecycleParser.SetactionContext setAction){
            var bin = ProcessRawStorage(setAction.rawstorage());
            var setValue = ProcessInt(setAction.@int());
            return new IntAction(bin.storage, bin.key, setValue);
        }
		public static GameAction IncAction(RecycleParser.IncactionContext setAction){
            var bin = ProcessRawStorage(setAction.rawstorage());
            var setValue = ProcessInt(setAction.@int());
            var newVal = bin.Get() + setValue;
            return new IntAction(bin.storage, bin.key, newVal);
        }
        public static GameAction DecAction(RecycleParser.DecactionContext setAction) {
            var bin = ProcessRawStorage(setAction.rawstorage());
            var setValue = ProcessInt(setAction.@int());
            var newVal = bin.Get() - setValue;
            return new IntAction(bin.storage, bin.key, newVal);
        }
    }
}