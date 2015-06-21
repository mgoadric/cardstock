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
					int trueTwo = IntIterator.ProcessListInt(intTwo)[0];
					if (intop.COMPOP() != null){
						if (intop.COMPOP().GetText() == ">="){
							return trueOne.Exists(item => item >= trueTwo);
						}
						else if (intop.COMPOP().GetText() == ">"){
							return trueOne.Exists(item => item > trueTwo);
						}
					}
				}
				else if (intOne.GetText().Contains("all")){
					List<int> trueOne = IntIterator.ProcessListInt(intOne);
					int trueTwo = IntIterator.ProcessListInt(intTwo)[0];
					if (intop.COMPOP() != null){
						if (intop.COMPOP().GetText() == "<="){
							return trueOne.All(item => item <= trueTwo);
						}
						else if (intop.COMPOP().GetText() == ">"){
							return trueOne.All(item => item > trueTwo);
						}
					}
				}
				else{//single comparison
					int trueOne = IntIterator.ProcessListInt(intOne)[0];
					int trueTwo = IntIterator.ProcessListInt(intTwo)[0];
					if (intop.EQOP() != null){
						if (intop.EQOP().GetText() == "=="){
							return trueOne == trueTwo;
						}
						else if (intop.EQOP().GetText() == "!="){
							return trueOne != trueTwo;
						}
					}
				}
			}
			else if (boolNode.UNOP() != null){
				//NOT (...)
				return ! ProcessBoolean(boolNode.boolean(0));
			}
			else if (boolNode.BOOLOP() != null){
				if (boolNode.BOOLOP().GetText() == "or"){
					bool flag = false;
					foreach (var boolean in boolNode.boolean()){
						
						flag |= ProcessBoolean(boolean);
					}
					return flag;
				}
				else if (boolNode.BOOLOP().GetText() == "and"){
					bool flag = true;
					foreach (var boolean in boolNode.boolean()){
						Console.WriteLine(boolean.GetText());
						flag &= ProcessBoolean(boolean);
					}
					return flag;
				}
			}
			return false;
		}
		
	}
}