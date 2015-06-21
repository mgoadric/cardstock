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
					CardGame.Instance.CurrentPlayer().Next();
					for (int i = 4; i < stage.ChildCount - 1; ++i){
						ProcessSubStage(stage.GetChild(i));
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
			for (int i = 0; i < multigameaction.ChildCount; ++i){
				Console.WriteLine("gameaction");
				var gameaction = multigameaction.GetChild(i) as CardLanguageParser.GameactionContext;
				if (BooleanIterator.ProcessBoolean(gameaction.boolean())){
					Console.WriteLine("bool true");
					ProcessMultiActionChoice(gameaction.multiaction());
				}
			}
		}
		public static void ProcessMultiActionChoice(CardLanguageParser.MultiactionContext actions){
			for (int i = 0; i < actions.ChildCount; ++i){
				Console.WriteLine("action children");
				ProcessActionChoice(actions.GetChild(i)  as CardLanguageParser.ActionContext);
			}
		}
		public static void ProcessActionChoice(CardLanguageParser.ActionContext action){
			//Console.WriteLine("Execute:");
			//Console.WriteLine(action.GetText());
			var opts = ActionIterator.ProcessAction(action);
			var flatten = new List<GameActionCollection>();
			foreach (var a in opts){
				flatten.Add(new GameActionCollection{a});
			}
			
			if (flatten.Count != 0){
				CardGame.Instance.PlayerMakeChoice(flatten,CardGame.Instance.CurrentPlayer().idx);
			}
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