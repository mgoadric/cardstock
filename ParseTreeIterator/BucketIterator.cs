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
	public class BucketIterator{
		public static CardCollection ProcessLocation(CardLanguageParser.LocstorageContext location){
			if (location.who() != null){
				return CardGame.Instance.tableCards[location.name().GetText()];
			}
			return null;
		}
		
	}
}