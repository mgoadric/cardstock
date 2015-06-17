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
	public class ActionIterator{
		public static void ProcessAction(CardLanguageParser.ActionContext actionNode){
			if (actionNode.loccreate() != null){
				var locAction = actionNode.loccreate() as CardLanguageParser.LoccreateContext;
				if (locAction.obj().GetText() == "game"){
					for (int i = 3; i < locAction.ChildCount; ++i){
						var locDef = locAction.GetChild(i) as CardLanguageParser.LocationdefContext;
						var binName = locDef.name().GetText();
						CardGame.Instance.tableCards.AddKey(binName);
						if (locDef.GetChild(2).GetText() == "Stack"){
							CardGame.Instance.tableCards[binName] = new CardStackCollection();
						}
						else if (locDef.GetChild(2).GetText() == "List"){
							CardGame.Instance.tableCards[binName] = new CardListCollection();
						}
						else if (locDef.GetChild(2).GetText() == "Queue"){
							CardGame.Instance.tableCards[binName] = new CardQueueCollection();
						}
						else{
							throw new System.ArgumentException("Unsuported Card bin type");
						}
					}
				}
			}
			else if (actionNode.storagecreate() != null){
				var stoAction = actionNode.storagecreate();
				if (stoAction.obj().GetText() == "game"){
					int namegrCnt = (stoAction.ChildCount - 5)/2 + 1;
					for (int i = 0; i < namegrCnt; ++i){
						var namegr = stoAction.namegr(i);
						var name = namegr.GetText();
						CardGame.Instance.gameStorage.AddKey(name);
						
					}
				}
			}
		}
		
	}
}