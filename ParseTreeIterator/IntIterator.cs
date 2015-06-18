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
		public static int ProcessInt(CardLanguageParser.IntContext intNode){
			if (intNode.INTNUM() != null){
				return int.Parse(intNode.GetText());
			}
			return 0;
		}
		public static List<int> ProcessListInt(CardLanguageParser.IntContext intNode){
			var raw = intNode.rawstorage();
			var ret = new List<int>();
			if (raw.who2() != null){
				if (raw.who2().posq() != null){
					if (raw.who2().posq().GetText() == "any"){
						if (raw.GetChild(2).GetText() == "team"){
							foreach (var team in CardGame.Instance.teams){
								ret.Add(team.teamStorage[raw.namegr().GetText()]);
							}
						}
					}
				}
			}
			return ret;
		}
		
	}
}