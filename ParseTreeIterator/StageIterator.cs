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
	public class StageIterator{
		public static void ProcessGame(CardLanguageParser.GameContext game){
			for (int i = 2; i < game.ChildCount - 1; ++i){
				ProcessSubStage(game.GetChild(i));
			}
		}
		public static void ProcessStage(CardLanguageParser.StageContext stage){
			CardGame.Instance.PushPlayer();
			if (stage.endcondition().boolean() != null){
				while (!BooleanIterator.ProcessBoolean(stage.endcondition().boolean())){
					Console.WriteLine("Hit Boolean while!");
					
					Console.WriteLine("Current Player: " + CardGame.Instance.CurrentPlayer().idx);
					for (int i = 4; i < stage.ChildCount - 1; ++i){
						ProcessSubStage(stage.GetChild(i));
					}
					if (stage.GetChild(2).GetText() == "player"){
						CardGame.Instance.CurrentPlayer().Next();
					}
					else if (stage.GetChild(2).GetText() == "team"){
						CardGame.Instance.CurrentTeam().Next();
					}
					
				}
			}
			CardGame.Instance.PopPlayer();
		}
		public static void ProcessSubStage(IParseTree sub){
			if (sub is CardLanguageParser.ComputermovesContext){
				Console.WriteLine("Comp Action");
				var comp = sub as CardLanguageParser.ComputermovesContext;
				var multigameaction = comp.multigameaction()  as CardLanguageParser.MultigameactionContext;
				for (int i = 0; i < multigameaction.ChildCount; ++i){
					Console.WriteLine("gameaction");
					var gameaction = multigameaction.GetChild(i) as CardLanguageParser.GameactionContext;
					if (BooleanIterator.ProcessBoolean(gameaction.boolean())){
						Console.WriteLine("bool true");
						ProcessMultiAction(gameaction.multiaction());
					}
				}
			}
			else if (sub is CardLanguageParser.StageContext){
				ProcessStage(sub as CardLanguageParser.StageContext);
			}
			else if (sub is CardLanguageParser.PlayermovesContext){
				var choice = sub as CardLanguageParser.PlayermovesContext;
				ProcessChoice(choice);
			}
		}
		public static void ProcessChoice(CardLanguageParser.PlayermovesContext playerMoves){
			var multigameaction = playerMoves.multigameaction()  as CardLanguageParser.MultigameactionContext;
			var allOptions = new List<GameActionCollection>();
			for (int i = 0; i < multigameaction.ChildCount; ++i){
				Console.WriteLine("gameaction");
				var gameaction = multigameaction.GetChild(i) as CardLanguageParser.GameactionContext;
				Console.WriteLine(gameaction.boolean().GetText());
				Console.WriteLine(BooleanIterator.ProcessBoolean(gameaction.boolean()));
				if (BooleanIterator.ProcessBoolean(gameaction.boolean())){
					allOptions.AddRange(ProcessMultiActionChoice(gameaction.multiaction()));
				}
			}
			if (allOptions.Count != 0){
				Console.WriteLine("Choice count:" + allOptions.Count);
				CardGame.Instance.PlayerMakeChoice(allOptions,CardGame.Instance.CurrentPlayer().idx);
			}
			else{
				Console.WriteLine("NO Choice Available");
			}
		}
		public static List<GameActionCollection> ProcessMultiActionChoice(CardLanguageParser.MultiactionContext actions){
			var allOptions = new List<GameActionCollection>();
			for (int i = 0; i < actions.ChildCount; ++i){
				Console.WriteLine("action children");
				var options = ProcessActionChoice(actions.GetChild(i)  as CardLanguageParser.ActionContext);
				var temp = new List<GameActionCollection>();
				if (allOptions.Count == 0){
					temp = options;
				}
				else{
					foreach (var additionalAction in options){
						foreach (var sourcePerm in allOptions){
							var copyPerm = new GameActionCollection();
							copyPerm.AddRange(sourcePerm);
							copyPerm.AddRange(additionalAction);
							temp.Add(copyPerm);
						}
					}
				}
				allOptions = temp;
			}
			
			return allOptions;
			
		}
		public static List<GameActionCollection> ProcessActionChoice(CardLanguageParser.ActionContext action){
			//Console.WriteLine("Execute:");
			//Console.WriteLine(action.GetText());
			var opts = ActionIterator.ProcessAction(action);
			var flatten = new List<GameActionCollection>();
			foreach (var a in opts){
				if (a is FancyCardMoveAction){
					var fa = a as FancyCardMoveAction;
					if (fa.startLocation.locIdentifier == "any"){
						foreach (var card in fa.startLocation.FilteredList().AllCards()){
							flatten.Add(new GameActionCollection{
								new CardMoveAction(card,fa.startLocation.cardList,fa.endLocation.cardList)
							});
						}	
					}
				}
				else{
					flatten.Add(new GameActionCollection{a});
				}
			}
			return flatten;
			
		}
		public static void ProcessMultiAction(CardLanguageParser.MultiactionContext actions){
			for (int i = 0; i < actions.ChildCount; ++i){
				Console.WriteLine("action children");
				ProcessAction(actions.GetChild(i)  as CardLanguageParser.ActionContext);
			}
		}
		public static void ProcessAction(CardLanguageParser.ActionContext action){
			//Console.WriteLine("Execute:");
			//Console.WriteLine(action.GetText());
			ActionIterator.ProcessAction(action).ExecuteAll();
		}
	}
}