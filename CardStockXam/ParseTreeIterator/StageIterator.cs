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

using Analytics;
using CardStockXam.CardEngine;
using CardStockXam;

namespace ParseTreeIterator
{
	public class StageIterator{
		public static void ProcessGame(RecycleParser.GameContext game){
			SetupIterator.ProcessSetup(game.setup()).ExecuteAll();
			
			for (int i = 3; i < game.ChildCount - 2; ++i){
				ProcessMultiaction(game.GetChild(i));
			}
		}
		public static void ProcessStage(RecycleParser.StageContext stage){
			CardGame.Instance.PushPlayer();
			if (stage.endcondition().boolean() != null){
				TimeStep.Instance.timeStep.Push(0);
				while (!BooleanIterator.ProcessBoolean(stage.endcondition().boolean())){
                    if (Scorer.gameWorld != null) { Scorer.gameWorld.numTurns++; }
					StageCount.Instance.IncCount(stage);
					TimeStep.Instance.timeStep.Push(TimeStep.Instance.timeStep.Pop() + 1);
					Debug.WriteLine("Current Player: " + CardGame.Instance.CurrentPlayer().idx);
                    
                    CardGame.Instance.WriteToFile("t:" + CardGame.Instance.CurrentPlayer().idx);
                    foreach (var player in CardGame.Instance.players) {
						Debug.WriteLine("HANDSIZE: " + player.cardBins["HAND"].Count);
					}
					for (int i = 4; i < stage.ChildCount - 1; ++i){
						TimeStep.Instance.treeLoc.Push(i - 4);
						Debug.WriteLine(TimeStep.Instance);
						ProcessMultiaction(stage.GetChild(i));
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
		public static List<GameActionCollection> ProcessMultiaction(IParseTree sub){
            var lst = new List<GameActionCollection>();
			if (sub is RecycleParser.MultiactionContext){
                var multiaction = sub as RecycleParser.MultiactionContext;
                if (multiaction.agg() != null)
                {
                    //List<GameAction> test = (List<CardEngine.GameAction>)VarIterator.ProcessAgg(multiaction.agg());
                    //Console.WriteLine(test[0].GetType());
                    Console.WriteLine("ur in processing multiaction");
                    lst.AddRange((List<GameActionCollection>)VarIterator.ProcessAgg(multiaction.agg()));

                }
                else if (multiaction.let() != null)
                {
                    lst.AddRange(VarIterator.ProcessLet(multiaction.let()));
                }
                else if (multiaction.GetChild(1).GetText() == "choice")
                {
                    ProcessChoice(multiaction.condact());
                }
                else if (multiaction.GetChild(1).GetText() == "do")
                {
                    ActionIterator.ProcessDo(multiaction.condact());
                }
            }
            else if (sub is RecycleParser.StageContext)
            {
                ProcessStage(sub as RecycleParser.StageContext);
            }
            else if (sub is RecycleParser.Multiaction2Context)
            {
				//Console.WriteLine("ur in processing multiaction2");
                var multi = sub as RecycleParser.Multiaction2Context;
                if (multi.agg() != null)
                {
                    lst.Add(VarIterator.ProcessAgg(multi.agg()) as GameActionCollection);
                }
                else if (multi.let() != null)
                {
                    lst.AddRange(VarIterator.ProcessLet(multi.let()));
                }
                else
                {
                    ActionIterator.ProcessDo(multi.condact());
                }
            }
            return lst;
        }
        public static List<GameActionCollection> RecurseDo(RecycleParser.CondactContext cond){
            var all = new List<GameActionCollection>();
            var stackTrees = new Stack<IteratingTree>();
            var stackTree = new IteratingTree();
            stackTree.Push(cond);
            stackTrees.Push(stackTree);
            var stackAct = new Stack<GameAction>();
            while (stackTrees.Count != 0) {
                stackTree = stackTrees.Pop();

                while (stackTree.Count() != 0) {
                    var current = stackTree.Pop();
                    if (current.tree != null) {
                        var currentTree = current.tree;
                        if (currentTree is RecycleParser.CondactContext) {
                            var condact = currentTree as RecycleParser.CondactContext;
                            if (condact.boolean() == null || BooleanIterator.ProcessBoolean(condact.boolean())) {
                                if (condact.action() != null) {
                                    stackTree.Push(condact.action());
                                }
                                if (condact.multiaction2() != null) {
                                    stackTree.Push(condact.multiaction2());
                                }
                            }
                        }
                        else if (currentTree is RecycleParser.Multiaction2Context) {
                            var multi = currentTree as RecycleParser.Multiaction2Context;
                            if (multi.agg() != null) {
                                stackTree.Push(multi.agg());
                            }
                            else if (multi.let() != null) {
                                stackTree.Push(multi.let());
                            }
                            else {//do
                                for (int i = multi.condact().Length - 1; i >= 0; i--) {
                                    stackTree.Push(multi.condact()[i]);
                                }
                            }
                        }
                        else if (currentTree is RecycleParser.AggContext) {
                            var agg = currentTree as RecycleParser.AggContext;
                            var collection = VarIterator.ProcessCollection(agg.collection());
                            if (agg.GetChild(1).GetText() == "any") {
                                if (collection.ToList().Count > 0){
                                    bool first = true;
                                    object firstItem = null;
                                    var vartext = agg.var().GetText();

                                    stackTree.Push(currentTree.GetChild(4));
                                    var idx = 0;
                                    foreach (object item in collection){
                                        if (first){
                                            firstItem = item;
                                            VarIterator.Put(vartext, firstItem);
                                            first = false;
                                        }
                                        else{
                                            var newtree = stackTree.Copy();
                                            stackTrees.Push(newtree);
                                            stackAct.Push(new LoopAction(vartext, item));
                                        }
                                        idx++;
                                    }
                                    stackAct.Push(new LoopAction(vartext, firstItem));
                                }
                            }
                            else { //all
                                foreach (object item in collection) {
                                    stackTree.Push(agg.var().GetText());
                                    stackTree.Push(currentTree.GetChild(4));
                                    stackTree.Push(agg.var().GetText(), item);
                                }
                            }
                        }
                        else if (currentTree is RecycleParser.LetContext) {
                            var let = currentTree as RecycleParser.LetContext;
                            var item = VarIterator.ProcessTyped(let.typed());
                            stackTree.Push(let.var().GetText());
                            stackTree.Push(currentTree.GetChild(4));
                            stackTree.Push(let.var().GetText(), item);
                        }
                        else if (currentTree is RecycleParser.ActionContext) {
                            var actions = ActionIterator.ProcessAction(currentTree as RecycleParser.ActionContext);
                            foreach (GameAction action in actions) {
                                stackAct.Push(action);
                                action.TempExecute();
                            }
                        }
                        else {
                            Console.WriteLine("failed to parse type " + current.GetType());
                        }
                    }
                    else{//var context
                        if (current.item != null){
                            VarIterator.Put(current.varContext, current.item);
                        } else{
                            VarIterator.Remove(current.varContext);
                        }
                    }
                }
                var coll = new GameActionCollection();
                foreach (GameAction act in stackAct.ToArray()) {
                    if (!(act is LoopAction)){
                        coll.Add(act);
                    }
                }

                while (stackAct.Count > 0 && !(stackAct.Peek() is LoopAction)) {
                    var temp = stackAct.Pop();
                    temp.Undo();
                }
                if (coll.Count > 0)
                {
                    coll.Reverse();
                    all.Add(coll);
                }
                if (stackAct.Count > 0){
                    var loop = stackAct.Pop() as LoopAction;
                    VarIterator.Remove(loop.var);
                }
                while (stackAct.Count > 0 && !(stackAct.Peek() is LoopAction)){
                    stackAct.Pop().Undo();
                }
                if (stackAct.Count > 0){
                    var loop = stackAct.Peek() as LoopAction;
                    VarIterator.Put(loop.var, loop.item);
                }
            }
            return all;
        }

        public static void ProcessChoice(RecycleParser.CondactContext[] choices)
        {
            var allOptions = new List<GameActionCollection>();
            for (int i = 0; i < choices.Length; ++i)
            {
                var gacs = RecurseDo(choices[i]);
                if (gacs.Count > 0){
                    allOptions.AddRange(gacs);
                }
            }
            //BranchingFactor.Instance.AddCount(allOptions.Count, CardGame.Instance.CurrentPlayer().idx);
            if (allOptions.Count != 0){
                Debug.WriteLine("Choice count:" + allOptions.Count);
                CardGame.Instance.PlayerMakeChoice(allOptions, CardGame.Instance.CurrentPlayer().idx);
            }
            else{ Debug.WriteLine("NO Choice Available");}
		}

        public static List<GameActionCollection> ProcessCondactChoice(RecycleParser.CondactContext cond)
        {
            var allOptions = new List<GameActionCollection>();
            bool condition = true;
            if (cond.boolean() != null){
                condition = BooleanIterator.ProcessBoolean(cond.boolean());
            }
            if (condition){
                if (cond.multiaction2() != null)
                {
                    allOptions.AddRange(ProcessMultiaction(cond.multiaction2()));
                }
                else if (cond.action() != null)
                {
                    allOptions.Add(ActionIterator.ProcessAction(cond.action()));
                }
            }
            return allOptions;
        }
    }
}