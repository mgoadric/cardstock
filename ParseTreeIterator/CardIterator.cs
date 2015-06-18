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
			return new FancyCardLocation{cardList = new CardListCollection(),locIdentifier=card.GetChild(1).GetText()};
		}
		public static FancyCardLocation ProcessLocation(CardLanguageParser.LocstorageContext loc){
			if (loc.who() != null){
				return new FancyCardLocation{
					cardList=CardGame.Instance.tableCards[loc.namegr().GetText()]
				};
			}
			return null;
		}
		
	}
}