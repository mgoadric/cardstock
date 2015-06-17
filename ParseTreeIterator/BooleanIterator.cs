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
			return false;
		}
		
	}
}