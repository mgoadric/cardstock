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
        public static List<GameActionCollection> ProcessMultiaction(IParseTree sub)
        {
            var lst = new List<GameActionCollection>();

            if (sub is RecycleParser.MultiactionContext)
            {
                var multiaction = sub as RecycleParser.MultiactionContext;
                Debug.WriteLine(multiaction.GetType());
                if (multiaction.agg() != null)
                {
                    //List<GameAction> test = (List<CardEngine.GameAction>)VarIterator.ProcessAgg(multiaction.agg());
                    //Debug.WriteLine(test[0].GetType());
                    Debug.WriteLine("Processing multiaction aggregation.");
                    lst.Add(VarIterator.ProcessAgg(multiaction.agg()) as GameActionCollection);
                    //lst.AddRange((List<GameActionCollection>)VarIterator.ProcessAgg(multiaction.agg()));

                }
                else if (multiaction.let() != null)
                {
					Debug.WriteLine("Processing multiaction let statement.");
					lst.AddRange(VarIterator.ProcessLet(multiaction.let()));
                }
                else if (multiaction.GetChild(1).GetText() == "choice")
                {
					Debug.WriteLine("Processing multiaction choice block.");
					ProcessChoice(multiaction.condact());
                }
                else if (multiaction.GetChild(1).GetText() == "do")
                {
					Debug.WriteLine("Processing multiaction do statement.");
					ActionIterator.ProcessDo(multiaction.condact());
                }
            }
            else if (sub is RecycleParser.StageContext)
            {
				Debug.WriteLine("Processing stage.");
				ProcessStage(sub as RecycleParser.StageContext);
            }
            else if (sub is RecycleParser.Multiaction2Context)
            {
                //Debug.WriteLine("ur in processing multiaction2");
                var multi = sub as RecycleParser.Multiaction2Context;
                if (multi.agg() != null)
                {
					Debug.WriteLine("Processing multiaction2 aggregation.");
					lst.Add(VarIterator.ProcessAgg(multi.agg()) as GameActionCollection);
                }
                else if (multi.let() != null)
                {
					Debug.WriteLine("Processing multiaction2 let statement.");
					lst.AddRange(VarIterator.ProcessLet(multi.let()));
                }
                else
                {
					Debug.WriteLine("Processing multiaction2 do statement.");
					ActionIterator.ProcessDo(multi.condact());
                }
            }
            Debug.WriteLine("Returning list of game actions.");
            return lst;
        }


        // look at where "Put" is called 
        public static List<GameActionCollection> RecurseDo(RecycleParser.CondactContext cond){
            var all = new List<GameActionCollection>();
            // stack of iterating trees
            var stackTrees = new Stack<IteratingTree>();
            // iteratingtree = stack of iterable items (just has basic stack functionality) 
            //      -can store another iteratingtree, strings, or a key/value object
            //      -can copy
            var stackTree = new IteratingTree();
            // internal loop - where things are actually processed, not stored
            stackTree.Push(cond);
			// overarcing loop - stacktrees (another tree is created 
            //    for each ALTERNATIVE (any, etc) action
            //    so that all possible choices can be found
			stackTrees.Push(stackTree);
            var stackAct = new Stack<GameAction>();
            // iterate over stack of stacks
            while (stackTrees.Count != 0)
            {
                stackTree = stackTrees.Pop();
                Debug.WriteLine("Moving to next concurrent game tree");
                Debug.WriteLine("Number of concurrent game states: " + stackTrees.Count);
                // iterate over stack of iterable items
                while (stackTree.Count() != 0)
                {

                    var current = stackTree.Pop();
                    if (current.tree != null)
                    {
                        var currentTree = current.tree;
                        if (currentTree is RecycleParser.CondactContext)
                        {
                            var condact = currentTree as RecycleParser.CondactContext;
                            // if the boolean returns true (and exists), 
                            // push the resulting action/multiaction items
                            // on the current stack of iterable items
                            if (condact.boolean() == null || BooleanIterator.ProcessBoolean(condact.boolean()))
                            {
                                if (condact.action() != null)
                                {

                                    stackTree.Push(condact.action());
                                }
                                if (condact.multiaction2() != null)
                                {
                                    stackTree.Push(condact.multiaction2());
                                }
                            }
                        }

                        else if (currentTree is RecycleParser.Multiaction2Context)
                        {
							Debug.WriteLine("Finding game actions recursively in a multiaction2 statement.");

							var multi = currentTree as RecycleParser.Multiaction2Context;
                            // is any or and
                            if (multi.agg() != null)
                            {
                                Debug.WriteLine("multiaction context 2 agg pushed to stack");
                                stackTree.Push(multi.agg());
                            }
                            // is let 
                            else if (multi.let() != null)
                            {
                                stackTree.Push(multi.let());
                            }
                            else
                            { // is do
                              // push all condacts onto current stack
                              // to be processed
                                for (int i = multi.condact().Length - 1; i >= 0; i--)
                                {
                                    stackTree.Push(multi.condact()[i]);
                                }
                            }
                        }
                        else if (currentTree is RecycleParser.MultiactionContext){
							Debug.WriteLine("Finding game actions recursively in a multiaction.");
							// terrible terrible ! someday TODO make this not copy paste
							// included to allow multiactions after let statement 
							// if rewritten (to be actually recursive etc etc)
							// could streamline multi & multi2 to be the same thing
							var multi = currentTree as RecycleParser.MultiactionContext;
							if (multi.agg() != null)
							{
								stackTree.Push(multi.agg());
							}
							// is let 
							else if (multi.let() != null)
							{
								stackTree.Push(multi.let());
							}
							else
							{ // is do
							  // push all condacts onto current stack
							  // to be processed

								for (int i = multi.condact().Length - 1; i >= 0; i--)
								{
                                    Debug.WriteLine(multi.condact()[i].GetType());
									stackTree.Push(multi.condact()[i]);
								}
							}

						}
                        else if (currentTree is RecycleParser.AggContext)
                        {
							Debug.WriteLine("Finding game actions recursively in an aggregation statement.");

							var agg = currentTree as RecycleParser.AggContext;
                            var collection = VarIterator.ProcessCollection(agg.collection());
                            if (agg.GetChild(1).GetText() == "any")
                            {
                                // if there is something in the collection
                                if (collection.ToList().Count > 0)
                                {
                                    bool first = true;
                                    object firstItem = null;
                                    var vartext = agg.var().GetText();
                                    // add collection of obj to current stack 
                                    stackTree.Push(currentTree.GetChild(4));

                                    foreach (object item in collection)
                                    {
                                        // for first item in collection only
                                        if (first)
                                        {
                                            firstItem = item;
                                            VarIterator.Put(vartext, firstItem);
                                            first = false;
                                        }
                                        else
                                        {
                                            // push alternatives onto the stack
                                            // of game actions as 
                                            // an iterable item  
                                            //  (they are unexecutable as loop actions)
                                            // generate a copy of tree to use to
                                            //  process the results of choosing
                                            //  the next item in collection
                                         
                                            var newtree = stackTree.Copy();
                                            stackTrees.Push(newtree);
                                            Debug.WriteLine("pushed item: " + item);
                                            stackAct.Push(new LoopAction(vartext, item, newtree.level));
                                        }

                                    }
                                    // push first item to be processed (on current
                                    // Stack of game actions )
                                    Debug.WriteLine("pushed first item: " + firstItem);
                                    stackTree.level++;
                                    stackAct.Push(new LoopAction(vartext, firstItem, stackTree.level));
                                }
                            }
                            else
                            { //all
                                // push
                                //      "'C" (string)
                                //      [contents of statement] (contained
                                //        in another stack tree)
                                //      "'C", iteritem (key, value)

                                foreach (object item in collection)
                                {
                                    stackTree.Push(agg.var().GetText());
                                    stackTree.Push(currentTree.GetChild(4));
                                    stackTree.Push(agg.var().GetText(), item);
                                }
                            }
                        }
                        else if (currentTree is RecycleParser.LetContext)
                        {
							// push name of var, statement after var, name/value pair
							Debug.WriteLine("Finding game actions recursively in a let statement.");

							var let = currentTree as RecycleParser.LetContext;
                            var item = VarIterator.ProcessTyped(let.typed());
                            // old handling of let vars
                            /*stackTree.Push(let.var().GetText());
                            stackTree.Push(currentTree.GetChild(4));
                            stackTree.Push(let.var().GetText(), item);*/



                            VarIterator.Put(let.var().GetText(), item);
                            stackTree.Push(currentTree.GetChild(4));
                            stackTree.level++;
                            stackAct.Push(new LoopAction(let.var().GetText(), item, stackTree.level));
                        }
                        else if (currentTree is RecycleParser.ActionContext)
                        {
							Debug.WriteLine("Finding game actions recursively in an action. ");

							var actions = ActionIterator.ProcessAction(currentTree as RecycleParser.ActionContext);
                            foreach (GameAction action in actions)
                            {
                                stackAct.Push(action);
                                action.TempExecute();
                            }
                        }
                        else
                        {
                            Debug.WriteLine("failed to parse type " + current.GetType());
                        }
                    }
                    else
                    {//var context
                        
                        if (current.item != null)
                        {
                            Debug.WriteLine("Adding var in RecurseDo: " + current.varContext);
                            VarIterator.Put(current.varContext, current.item);
                        }
                        else
                        {
                            Debug.WriteLine("Removing var in RecurseDo: " + current.varContext);
                            VarIterator.Remove(current.varContext);
                        }
                    }
                }
                // end of loop over current stack of iteritems
                var coll = new GameActionCollection();
                foreach (GameAction act in stackAct.ToArray())
                {
                    // add everythign but loop actions to coll
                    if (!(act is LoopAction))
                    {
                        coll.Add(act);
                    }
                }

                while (stackAct.Count > 0 && !(stackAct.Peek() is LoopAction))
                {
                    var temp = stackAct.Pop();
                    temp.Undo();
                }
                if (coll.Count > 0)
                {
                    // puts game action collection back in stack order 
                    // adds list of actions to overall choice list to be returned 
                    coll.Reverse();
                    all.Add(coll);
                }

                // if there are still loopactions,
                //   remove the current one, 
                var currentLevel = 0;
                if (stackAct.Count > 0)
                {
                    var loop = stackAct.Pop() as LoopAction;
                    currentLevel = loop.level;
                    Debug.WriteLine("pop & remove : " + loop.item);

                    VarIterator.Remove(loop.var);
                }
                // undo everything (until
                bool unwinding = true;
                while (unwinding)
                {
                    // "normal" - item before is loopaction & same level
                    // up one level - item before is loopaction & different level
                    // up one level - items need to be undone before finding loopaction, but is different level
                    // up n levels - 

                    while (stackAct.Count > 0 && !(stackAct.Peek() is LoopAction))
                    {
                        stackAct.Pop().Undo();
                    }
                    if (stackAct.Count > 0)
                    {
                        var loop = stackAct.Peek() as LoopAction;

                        Debug.WriteLine("peek + add : " + loop.item);
                        if (loop.level == currentLevel)
                        {
                            VarIterator.Put(loop.var, loop.item);
                            unwinding = false;
                        }
                        else
                        {
                            stackAct.Pop();
                            currentLevel = loop.level;
                        }

                    }
                    else
                    {
                        unwinding = false;
                    }


                }
            
            }
            return all;
        }

        public static void ProcessChoice(RecycleParser.CondactContext[] choices)
        {
            Debug.WriteLine("Processing choice.");
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
                Console.WriteLine("processed choices");
                Debug.WriteLine("Choice count:" + allOptions.Count);
                CardGame.Instance.PlayerMakeChoice(allOptions, CardGame.Instance.CurrentPlayer().idx);
                Console.WriteLine("player choice made");
            }
            else{ Debug.WriteLine("NO Choice Available");}
		}

        public static List<GameActionCollection> ProcessCondactChoice(RecycleParser.CondactContext cond)
        {
			Debug.WriteLine("Processing conditional action choice.");

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