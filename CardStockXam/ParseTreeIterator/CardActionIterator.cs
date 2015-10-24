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
		public static GameActionCollection ProcessCopy(RecycleParser.CopyactionContext copy){
			var ret = new GameActionCollection();
			if (copy.ChildCount == 4){
				//Explicit Repeat
				var count = copy.GetChild(3).GetText();
				if (count == "all"){//copy all
					//forbidden for now
				}
				else{//copy x number of times
					var explicitCount = int.Parse(count);
					for (int i = 0; i < explicitCount; ++i){
						 
					}
				}
			}
			else{
				//Do once
				var cardOne = CardIterator.ProcessCard(copy.card());
				var cardTwo = CardIterator.ProcessCard(copy.cardm());
				foreach (var card1 in cardOne){
					foreach (var card2 in cardTwo){
						ret.Add(new FancyCardCopyAction(card1,card2));
					}
				}
			}
			return ret;
		}
		public static GameActionCollection ProcessRemove(RecycleParser.RemoveactionContext removeAction){
			var ret = new GameActionCollection();
			
			//Do once
			var cardOne = CardIterator.ProcessCard(removeAction.cardm());
			foreach (var card1 in cardOne){
				ret.Add(new FancyRemoveAction(card1));
			}
			
			return ret;
		}
		public static GameActionCollection ProcessMove(RecycleParser.MoveactionContext move){
			var ret = new GameActionCollection();
			if (move.ChildCount == 4){
				//Explicit Repeat
				var count = move.GetChild(3).GetText();
				if (count == "all"){//move all
					
					var cardOne = CardIterator.ProcessCard(move.cardp(0));
					var cardTwo = CardIterator.ProcessCard(move.cardp(1));
					foreach (var card1 in cardOne){
						for (int i = 0; i < card1.FilteredCount(); ++i){
							foreach (var card2 in cardTwo){
								ret.Add(new FancyCardMoveAction(card1,card2));
							}
						}
					}
				}
				else{//move x number of times
					var explicitCount = int.Parse(count);
					var cardOne = CardIterator.ProcessCard(move.cardp(0));
					var cardTwo = CardIterator.ProcessCard(move.cardp(1));
					
					foreach (var card1 in cardOne){
						for (int i = 0; i < explicitCount; ++i){
							foreach (var card2 in cardTwo){
								ret.Add(new FancyCardMoveAction(card1,card2));
							}
						}
					}
					
				}
			}
			else{
				//Do once
				var cardOne = CardIterator.ProcessCard(move.cardp(0));
				var cardTwo = CardIterator.ProcessCard(move.cardp(1));
				foreach (var card1 in cardOne){
					foreach (var card2 in cardTwo){
						ret.Add(new FancyCardMoveAction(card1,card2));
					}
				}
				
			}
			return ret;
		}
		
	}
}