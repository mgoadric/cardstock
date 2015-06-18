using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using Antlr4.Runtime.Tree;

namespace ParseTreeIterator
{
	public class BooleanIterator{
		public static bool ProcessBoolean(CardLanguageParser.BooleanContext boolNode){
			Console.WriteLine("'" + boolNode.GetText() + "'");
			if (boolNode.GetText() == "()"){
				return true;
			}
			else if (boolNode.intop() != null){
				var intop = boolNode.intop();
				var intOne = boolNode.@int(0);
				var intTwo = boolNode.@int(1);
				if (intOne.GetText().Contains("any")){
					List<int> trueOne = IntIterator.ProcessListInt(intOne);
					int trueTwo = IntIterator.ProcessInt(intTwo);
					if (intop.COMPOP() != null){
						if (intop.COMPOP().GetText() == ">="){
							return trueOne.Exists(item => item >= trueTwo);
						}
					}
				}	
			}
			return false;
		}
		
	}
}