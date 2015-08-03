using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using Antlr4.Runtime.Tree;
using CardEngine;

using Analytics;

namespace ParseTreeIterator
{
	public class StageIterator{
		public static void ProcessGame(RecycleParser.GameContext game){

			// process setup
			SetupIterator.ProcessSetup(game.setup()).ExecuteAll();
			
			for (int i = 3; i < game.ChildCount - 2; ++i){
				ProcessSubStage(game.GetChild(i));
			}
			
			// process scoring TODO
			
			
		}
		public static void ProcessStage(RecycleParser.StageContext stage){
			CardGame.Instance.PushPlayer();
			if (stage.endcondition().boolean() != null){
				TimeStep.Instance.timeStep.Push(0);
				while (!BooleanIterator.ProcessBoolean(stage.endcondition().boolean())){
					//Console.WriteLine("Hit Boolean while!");
					StageCount.Instance.IncCount(stage);
					TimeStep.Instance.timeStep.Push(TimeStep.Instance.timeStep.Pop() + 1);
					Console.WriteLine("Current Player: " + CardGame.Instance.CurrentPlayer().idx);
					foreach (var player in CardGame.Instance.players) {
						Console.WriteLine("HANDSIZE: " + player.cardBins["HAND"].Count);
					}
					for (int i = 4; i < stage.ChildCount - 1; ++i){
						TimeStep.Instance.treeLoc.Push(i - 4);
						Console.WriteLine(TimeStep.Instance);
						ProcessSubStage(stage.GetChild(i));
						TimeStep.Instance.treeLoc.Pop();
					}
					if (stage.GetChild(2).GetText() == "player"){
						CardGame.Instance.CurrentPlayer().Next();
					}
					else if (stage.GetChild(2).GetText() == "team"){
						CardGame.Instance.CurrentTeam().Next();
					}
					
				}
				TimeStep.Instance.timeStep.Pop();
			}
			CardGame.Instance.PopPlayer();
		}
		public static void ProcessSubStage(IParseTree sub){
			if (sub is RecycleParser.ComputermovesContext){
				//Console.WriteLine("Comp Action");
				var comp = sub as RecycleParser.ComputermovesContext;
				var multigameaction = comp.multigameaction()  as RecycleParser.MultigameactionContext;
				for (int i = 0; i < multigameaction.ChildCount; ++i){
					//Console.WriteLine("gameaction");
					var gameaction = multigameaction.GetChild(i) as RecycleParser.GameactionContext;
					if (BooleanIterator.ProcessBoolean(gameaction.boolean())){
						//Console.WriteLine("bool true");
						ProcessMultiAction(gameaction.multiaction());
					}
				}
			}
			else if (sub is RecycleParser.StageContext){
				ProcessStage(sub as RecycleParser.StageContext);
			}
			else if (sub is RecycleParser.PlayermovesContext){
				var choice = sub as RecycleParser.PlayermovesContext;
				ProcessChoice(choice);
			}
		}
		public static void ProcessChoice(RecycleParser.PlayermovesContext playerMoves){
			var multigameaction = playerMoves.multigameaction()  as RecycleParser.MultigameactionContext;
			var allOptions = new List<GameActionCollection>();
			for (int i = 0; i < multigameaction.ChildCount; ++i){
				//Console.WriteLine("gameaction");
				var gameaction = multigameaction.GetChild(i) as RecycleParser.GameactionContext;
				//Console.WriteLine(gameaction.boolean().GetText());
				//Console.WriteLine(BooleanIterator.ProcessBoolean(gameaction.boolean()));
				if (BooleanIterator.ProcessBoolean(gameaction.boolean())){
					allOptions.AddRange(ProcessMultiActionChoice(gameaction.multiaction()));
				}
			}
			BranchingFactor.Instance.AddCount(allOptions.Count,CardGame.Instance.CurrentPlayer().idx);
			if (allOptions.Count != 0){
				Console.WriteLine("Choice count:" + allOptions.Count);
				CardGame.Instance.PlayerMakeChoice(allOptions,CardGame.Instance.CurrentPlayer().idx);
			}
			else{
				Console.WriteLine("NO Choice Available");
			}
		}
		public static List<GameActionCollection> ProcessMultiActionChoice(RecycleParser.MultiactionContext actions){
			var allOptions = new List<GameActionCollection>();
			for (int i = 0; i < actions.ChildCount; ++i){
				//Console.WriteLine("action children");
				var options = ProcessActionChoice(actions.GetChild(i)  as RecycleParser.ActionContext);
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
			Console.WriteLine("MultiActionChoiceCount:" + allOptions.Count);
			return allOptions;
			
		}
		public static List<GameActionCollection> ProcessActionChoice(RecycleParser.ActionContext action){
			//Console.WriteLine("Execute:");
			//Console.WriteLine(action.GetText());
			var opts = ActionIterator.ProcessAction(action);
			//Console.WriteLine("orig:" + opts.Count);
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
					else{
						flatten.Add(new GameActionCollection{
							fa
						});
					}
				}
				else{
					flatten.Add(new GameActionCollection{a});
				}
			}
			Console.WriteLine("Flatten:" + flatten.Count);
			return flatten;
			
		}
		public static void ProcessMultiAction(RecycleParser.MultiactionContext actions){
			for (int i = 0; i < actions.ChildCount; ++i){
				//Console.WriteLine("action children");
				ProcessAction(actions.GetChild(i)  as RecycleParser.ActionContext);
			}
		}
		public static void ProcessAction(RecycleParser.ActionContext action){
			//Console.WriteLine("Execute:");
			//Console.WriteLine(action.GetText());
			ActionIterator.ProcessAction(action).ExecuteAll();
		}
	}
}