using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics;
using Antlr4.Runtime.Tree;
using CardEngine;

namespace ParseTreeIterator
{
	public class CardActionIterator{
        public static GameAction ProcessCopy(RecycleParser.CopyactionContext copy) { //TODO fix this for real
            Debug.WriteLine(copy.GetText());
            var cardOne = CardIterator.ProcessCard(copy.GetChild(1) as RecycleParser.CardContext);
            
            if (cardOne.Count() == 0) {
                Debug.WriteLine(copy.GetText());
                CardIterator.ProcessCard(copy.GetChild(1) as RecycleParser.CardContext);
                return null;
            }
            var cardTwo = CardIterator.ProcessCard(copy.GetChild(2) as RecycleParser.CardContext);
            return new FancyCardCopyAction(cardOne, cardTwo);
        }

		public static GameAction ProcessRemove(RecycleParser.RemoveactionContext removeAction){
			var cardOne = CardIterator.ProcessCard(removeAction.card());
			return new FancyRemoveAction(cardOne);
		}
        public static GameAction ProcessMove(RecycleParser.MoveactionContext move) {
            var cardOne = CardIterator.ProcessCard(move.GetChild(1) as RecycleParser.CardContext);
            var cardTwo = CardIterator.ProcessCard(move.GetChild(2) as RecycleParser.CardContext);
            return new FancyCardMoveAction(cardOne, cardTwo);
        }

        internal static GameAction ProcessShuffle(FancyCardLocation locations)
        {
            return new ShuffleAction(locations);
        }
    }
}