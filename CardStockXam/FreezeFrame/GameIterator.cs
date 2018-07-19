﻿﻿using System;
using System.Diagnostics;
using Antlr4.Runtime.Tree;
using CardEngine;
using System.Collections.Generic;
using CardStockXam.Scoring;
namespace FreezeFrame
{
	public class GameIterator
	{
		public RecycleParser.GameContext rules;
		Stack<Queue<IParseTree>> iterStack;
		HashSet<IParseTree> iteratingSet;
        public ParseOOPIterator parseoop;
        public CardGame game;
        public World gameWorld;

		public GameIterator Clone(CardGame cg){
            // CHANGED HERE TODO 
            var ret = new GameIterator (rules, cg, gameWorld, false);
			var revStack = new Stack<Queue<IParseTree>> ();
			foreach (var i in iterStack) {
				revStack.Push (i);
			}
			foreach (var queue in revStack) {
				var newQueue = new Queue<IParseTree> ();
				foreach (var thing in queue) {
					newQueue.Enqueue (thing);
				}

				ret.iterStack.Push (newQueue);
			}
			foreach (var node in iteratingSet) {
				ret.iteratingSet.Add (node);
			}
			return ret;
		}

		public GameIterator (RecycleParser.GameContext context, CardGame mygame, World gameWorld, bool fresh = true)
		{
            this.gameWorld = gameWorld;
			rules = context;
            game = mygame;
			iterStack = new Stack<Queue<IParseTree>>();
			iteratingSet = new HashSet<IParseTree>();
            parseoop = new ParseOOPIterator(this);

            if (fresh)
            {
                Debug.WriteLine("Processing declarations.");
                foreach (RecycleParser.DeclareContext declare in rules.declare())
                {
                    parseoop.ProcessDeclare(declare);
                }
                Debug.WriteLine("Setting up game.");
                parseoop.ProcessSetup(rules.setup()).ExecuteAll();
                iterStack.Push(new Queue<IParseTree>());
                var topLevel = iterStack.Peek();
                for (int i = 3; i < rules.ChildCount - 2; ++i)
                {
                    topLevel.Enqueue(rules.GetChild(i));
                }
            } 
		}

		public bool AdvanceToChoice(){
            int count = 0;
			while (iterStack.Count != 0 && !ProcessSubStage()) {
                count++;
                if (count > 500) {
                    Console.WriteLine("Game stuck in loop");
                    return true; // game stuck in loop
                }
			}
			if (iterStack.Count == 0) {
				return true; // game over
			}
            Debug.WriteLine(iterStack.Count);
			return false; // interupted by player decision
		}

		public IParseTree CurrentNode(){
			var ret =  iterStack.Peek ().Peek ();
			return ret;
		}

		public void PopCurrentNode(){
            
			iterStack.Peek ().Dequeue ();
			if (iterStack.Peek ().Count == 0) {
                Debug.WriteLine("Popped current node");
                // TODO only popped here
				iterStack.Pop ();
                //Console.WriteLine(iterStack.Peek());
                Debug.WriteLine(iterStack.Count);
			}
		}

		public bool ProcessSubStage(){
            Debug.WriteLine("Processing substage.");
			var sub = CurrentNode ();
            if (sub.ChildCount > 1 && sub.GetChild(1).GetText() == "choice") { return true; }

            // Time to parse it
            else if (sub is RecycleParser.StageContext){
                //EvalGameLead(); TODO
                var allowedToRun = ProcessStage(sub as RecycleParser.StageContext);
                if (allowedToRun){
                    Debug.WriteLine("Is a stage.");
                    iteratingSet.Add(sub);
                }
            }
            else if (sub is RecycleParser.MultiactionContext){
                PopCurrentNode();
                Debug.WriteLine("Is a multiaction.");
                parseoop.ProcessMultiaction(sub as RecycleParser.MultiactionContext);
            }
            else if (sub is RecycleParser.Multiaction2Context){
                PopCurrentNode();
                Debug.WriteLine("Is a multiaction2.");
                parseoop.ProcessMultiaction(sub as RecycleParser.Multiaction2Context);
            }
            //setup and declare already handled
            else if (sub is RecycleParser.SetupContext){
                PopCurrentNode();
                //SetupIterator.ProcessSetup(sub as RecycleParser.SetupContext);
            }
            else if (sub is RecycleParser.DeclareContext){
                PopCurrentNode();
            }
            else {
                Debug.WriteLine(sub.GetType());
                throw new NotSupportedException();
            }
            return false;
		}

		public void ProcessChoice(){
			var sub = CurrentNode ();
			var choice = sub as RecycleParser.MultiactionContext;
			Debug.WriteLine("trying to process choice (in processchoice)");
			parseoop.ProcessChoice(choice.condact());
			PopCurrentNode ();
		}

		//this just queues the appropriate actions if condition is met, doesn't execute
		public bool ProcessStage(RecycleParser.StageContext stage){
            string text = stage.GetChild(2).GetText();
			if (stage.endcondition().boolean() != null){

				if (!iteratingSet.Contains (stage)) {
                    if (text == "player")
                    {
                        game.PushPlayer();
                    } else if (text == "team") {
                        game.PushTeam();
                    }
				}

				if (!parseoop.ProcessBoolean (stage.endcondition ().boolean ())) {
					Debug.WriteLine("Processing end of stage condition.");

					//Debug.WriteLine("Hit Boolean while!");
					iterStack.Push (new Queue<IParseTree> ());
					var topLevel = iterStack.Peek ();
                    Debug.WriteLine ("Current Player: " + game.CurrentPlayer().idx + ", " + game.players[game.CurrentPlayer().idx]);
                    Debug.WriteLine("Num players (gameiterator): " + game.CurrentPlayer().memberList.Count);
                    foreach (var player in game.players) {
						//Console.WriteLine ("HANDSIZE: " + player.cardBins ["{hidden}HAND"].Count);
					}
					for (int i = 4; i < stage.ChildCount - 1; ++i) {
						//TimeStep.Instance.treeLoc.Push(i - 4);
						//Debug.WriteLine (TimeStep.Instance);
						//ProcessSubStage(stage.GetChild(i));
						topLevel.Enqueue (stage.GetChild (i));
                        Debug.WriteLine("Child enqueued: " + stage.GetChild(i).GetText());
						//TimeStep.Instance.treeLoc.Pop();
					}
					if (iteratingSet.Contains (stage)) {
						if (text == "player") {
							game.CurrentPlayer ().Next ();
						} else if (text == "team") {
							game.CurrentTeam ().Next ();
                            Debug.WriteLine("Next team is " + game.CurrentTeam().Current());
						}
					}

				} else {
					PopCurrentNode ();

					if (iteratingSet.Contains (stage)) {
						iteratingSet.Remove (stage);
                        if (text == "player") {
                            game.PopPlayer();
                        } else if (text == "team") {
                            game.PopTeam();
                        }
						
					}
					return false;
				}
			}
			return true;
			//instance.PopPlayer();
		}
    }
}

