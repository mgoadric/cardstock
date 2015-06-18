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
	public class CardIterator{
		public static FancyCardLocation ProcessCard(CardLanguageParser.CardContext card){
			return new FancyCardLocation(new CardListCollection(),card.GetChild(1).GetText());
		}
		
	}
}