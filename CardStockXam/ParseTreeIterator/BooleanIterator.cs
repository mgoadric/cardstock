using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics;
using Antlr4.Runtime.Tree;

namespace ParseTreeIterator
{
	public class BooleanIterator{
		public static bool ProcessBoolean(RecycleParser.BooleanContext boolNode){
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
					if (intop.EQOP() != null){
						if (intop.EQOP().GetText() == "=="){
							
							return trueOne.Exists(item => item == trueTwo);
						}
						else if (intop.EQOP().GetText() == "!="){
							return trueOne.Exists(item => item != trueTwo);
						}
					}
					if (intop.COMPOP() != null){
						if (intop.COMPOP().GetText() == "<="){
							return trueOne.Exists(item => item <= trueTwo);
						}
						else if (intop.COMPOP().GetText() == ">"){
							return trueOne.Exists(item => item > trueTwo);
						}
						else if (intop.COMPOP().GetText() == ">="){
							return trueOne.Exists(item => item >= trueTwo);
						}
						else if (intop.COMPOP().GetText() == "<"){
							return trueOne.Exists(item => item < trueTwo);
						}
					}
				}
				else if (intOne.GetText().Contains("all")){
					List<int> trueOne = IntIterator.ProcessListInt(intOne);
					int trueTwo = IntIterator.ProcessListInt(intTwo)[0];
					if (intop.EQOP() != null){
						if (intop.EQOP().GetText() == "=="){
							
							//Console.Write("\n");
							return trueOne.All(item => item == trueTwo);
						}
						else if (intop.EQOP().GetText() == "!="){
							return trueOne.All(item => item != trueTwo);
						}
					}
					if (intop.COMPOP() != null){
						if (intop.COMPOP().GetText() == "<="){
							
							return trueOne.All(item => item <= trueTwo);
						}
						else if (intop.COMPOP().GetText() == ">"){
							return trueOne.All(item => item > trueTwo);
						}
						else if (intop.COMPOP().GetText() == ">="){
							return trueOne.All(item => item >= trueTwo);
						}
						else if (intop.COMPOP().GetText() == "<"){
							return trueOne.All(item => item < trueTwo);
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
					else if (intop.COMPOP() != null){
						if (intop.COMPOP().GetText() == "<="){
							return trueOne <= trueTwo;
						}
						else if (intop.COMPOP().GetText() == ">"){
							return trueOne > trueTwo;
						}
						else if (intop.COMPOP().GetText() == ">="){
							return trueOne >= trueTwo;
						}
						else if (intop.COMPOP().GetText() == "<"){
							return trueOne < trueTwo;
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
						flag &= ProcessBoolean(boolean);
						if (!flag){
							return flag;
						}
					}
					return flag;
				}
			}
			else if (boolNode.attrcomp() != null){
				var lst1 = ProcessAtt(boolNode.attrcomp().cardatt(0));
				var lst2 = ProcessAtt(boolNode.attrcomp().cardatt(1));
				if (boolNode.attrcomp().EQOP().GetText() == "=="){
					return lst1.Intersect(lst2).Count() >= 1;
				}
				else{// == "!="
					return lst1.Intersect(lst2).Count() == 0;
				}
			}
			return false;
		}
		public static  List<string> ProcessAtt(RecycleParser.CardattContext cAtt){
			List<string> ret = new List<string>();
			if (cAtt.ChildCount == 1){
				ret.Add(cAtt.GetText());
			}
			else{//We're ignoring 'each' here, not iterating over a deck
				var lstOfCards = CardIterator.ProcessCard(cAtt.card());
				foreach (var fLoc in lstOfCards){
					foreach (var card in fLoc.FilteredList().AllCards()){
						ret.Add(card.ReadAttribute(cAtt.name().GetText()));
					}
				}
				
			}
			return ret;
		}
		
	}
}