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
	public class CardActionIterator{
		public static GameActionCollection ProcessCopy(CardLanguageParser.CopyactionContext copy){
			if (copy.ChildCount == 4){
				//Explicit Repeat
				var count = copy.GetChild(3).GetText();
				if (count == "all"){//copy all
					
				}
				else{//copy x number of times
					var explicitCount = int.Parse(count);
					for (int i = 0; i < explicitCount; ++i){
						 
					}
				}
			}
			else{
				//Do once
				var cardOne;
			}
		}
		
	}
}