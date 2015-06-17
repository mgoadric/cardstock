using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using Antlr4.Runtime.Tree;

namespace ParseTreeIterator
{
	public class StageIterator{
		public static void ProcessStage(CardLanguageParser.StageContext stage){
			if (stage.endcondition().GetChild(2).GetText() == "game"){
				int start = 0;
				int end = IntIterator.ProcessInt(stage.endcondition().@int());
				while (start < end){
					for (int i = 4; i < stage.ChildCount - 1; ++i){
						ProcessSubStage(stage.GetChild(i));
					}
					start++;
				}
			}
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
		}
		public static void ProcessMultiAction(CardLanguageParser.MultiactionContext actions){
			for (int i = 0; i < actions.ChildCount; ++i){
				Console.WriteLine("action children");
				ProcessAction(actions.GetChild(i)  as CardLanguageParser.ActionContext);
			}
		}
		public static void ProcessAction(CardLanguageParser.ActionContext action){
			Console.WriteLine("Execute:");
			Console.WriteLine(action.GetText());
			ActionIterator.ProcessAction(action);
		}
	}
}