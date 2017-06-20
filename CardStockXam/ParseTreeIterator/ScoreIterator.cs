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
	public class ScoreIterator{
		public static List<Tuple<int,int>> ProcessScore(RecycleParser.ScoringContext scoreMethod){
			var ret = new List<Tuple<int, int>>();

			CardGame.Instance.PushPlayer();
			CardGame.Instance.CurrentPlayer().idx = 0;
			for (int i = 0; i < CardGame.Instance.players.Count; ++i) {
				var working = IntIterator.ProcessInt (scoreMethod.@int ());
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
    }
}