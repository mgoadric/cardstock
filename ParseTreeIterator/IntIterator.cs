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
	public class IntIterator{
		public static int ProcessInt(CardLanguageParser.IntContext intNode){
			if (intNode.INTNUM() != null){
				return int.Parse(intNode.GetText());
			}
			return 0;
		}
		
	}
}