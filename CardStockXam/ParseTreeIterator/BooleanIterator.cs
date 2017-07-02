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
        public static bool ProcessBoolean(RecycleParser.BooleanContext boolNode) {
            if (boolNode.intop() != null) {
        
                var intop = boolNode.intop();
                var intOne = boolNode.@int(0);
                var intTwo = boolNode.@int(1);
                int trueOne = IntIterator.ProcessInt(intOne);
                int trueTwo = IntIterator.ProcessInt(intTwo);
                if (intop.EQOP() != null) {
                    string text = intop.EQOP().GetText();
                    if (text == "==") {
                        return trueOne == trueTwo;
                    }
                    else if (text == "!=") {
                        return trueOne != trueTwo;
                    }
                }
                else if (intop.COMPOP() != null) {
                    string text = intop.COMPOP().GetText();
                    if (text == ">") {
                        return trueOne > trueTwo;
                    }
                    else if (text == ">=") {
                        return trueOne >= trueTwo;
                    }
                    else if (text == "<") {
                        return trueOne < trueTwo;
                    }
                    else if (text == "<="){
                        return trueOne <= trueTwo;
                    }
                }
            }
			else if (boolNode.UNOP() != null){
				return ! ProcessBoolean(boolNode.boolean(0));
			}
			else if (boolNode.BOOLOP() != null){
                string text = boolNode.BOOLOP().GetText();
				if (text == "or"){
					bool flag = false;
					foreach (var boolean in boolNode.boolean()){
						flag |= ProcessBoolean(boolean);
                        if (flag){
                            return flag;
                        }
					}
					return flag;
				}
				else if (text == "and"){
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
				var str1 = CardIterator.ProcessCardatt(boolNode.attrcomp().cardatt(0));
				var str2 = CardIterator.ProcessCardatt(boolNode.attrcomp().cardatt(1));
                Debug.WriteLine(boolNode.GetText());
                Debug.WriteLine(str1 + ", " + str2);
				if (boolNode.attrcomp().EQOP().GetText() == "=="){
                    return str1 == str2;
				}
				else{// == "!="
                    return str1 != str2;
				}
			}
            else if (boolNode.EQOP() != null){
                bool eq = false;
                if (boolNode.EQOP().GetText() == "=="){
                    eq = true;
                }
                if (boolNode.card() != null){
                    var card1 = CardIterator.ProcessCard(boolNode.card()[0]);
                    var card2 = CardIterator.ProcessCard(boolNode.card()[1]);
                    return eq == card1.Equals(card2);
                }
                else if (boolNode.whop() != null){
                    var p1 = CardIterator.ProcessWhop(boolNode.whop()[0]);
                    var p2 = CardIterator.ProcessWhop(boolNode.whop()[1]);
                    return eq == p1.Equals(p2);
                }
                else if (boolNode.whot() != null){
                    var t1 = CardIterator.ProcessWhot(boolNode.whot()[0]);
                    var t2 = CardIterator.ProcessWhot(boolNode.whot()[1]);
                    return eq == t1.Equals(t2);
                }
            }
            else if (boolNode.agg() != null){
                return (bool) VarIterator.ProcessAgg(boolNode.agg());
            }
            throw new NotSupportedException();
		}
		
	}
}