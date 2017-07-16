﻿﻿using System;
using System.Diagnostics;
using Antlr4.Runtime.Tree;
using ParseTreeIterator;
using CardEngine;
using System.Collections.Generic;

namespace FreezeFrame
{
	public class GameIterator
	{
		public RecycleParser.GameContext game;
		Stack<Queue<IParseTree>> iterStack;
		HashSet<IParseTree> iteratingSet;
        public ParseOOPIterator parseoop;
        public CardGame instance;

		public GameIterator Clone(CardGame cg){
            var ret = new GameIterator (game, cg, false);
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

		public GameIterator (RecycleParser.GameContext g, CardGame mygame, bool fresh = true)
		{
			game = g;
            instance = mygame;
			iterStack = new Stack<Queue<IParseTree>>();
			iteratingSet = new HashSet<IParseTree>();
            parseoop = new ParseOOPIterator(this);

            if (fresh)
            {
                Debug.WriteLine("Processing declarations.");
                foreach (RecycleParser.DeclareContext declare in game.declare())
                {
                    parseoop.ProcessDeclare(declare);
                }
                Debug.WriteLine("Setting up game.");
                parseoop.ProcessSetup(game.setup()).ExecuteAll();
                iterStack.Push(new Queue<IParseTree>());
                var topLevel = iterStack.Peek();
                for (int i = 3; i < game.ChildCount - 2; ++i)
                {
                    topLevel.Enqueue(game.GetChild(i));
                }
            } 
		}

		public bool AdvanceToChoice(){
			while (iterStack.Count != 0 && !ProcessSubStage()) {
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
                        instance.PushPlayer();
                    } else if (text == "team") {
                        instance.PushTeam();
                    }
				}

				if (!parseoop.ProcessBoolean (stage.endcondition ().boolean ())) {
					Debug.WriteLine("Processing end of stage condition.");

					//Debug.WriteLine("Hit Boolean while!");
					iterStack.Push (new Queue<IParseTree> ());
					var topLevel = iterStack.Peek ();
                    Debug.WriteLine ("Current Player: " + instance.CurrentPlayer ().idx + ", " + instance.players[instance.CurrentPlayer().idx]);
                    Debug.WriteLine("Num players (gameiterator): " + instance.CurrentPlayer().playerList.Count);
                    foreach (var player in instance.players) {
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
							instance.CurrentPlayer ().Next ();
						} else if (text == "team") {
							instance.CurrentTeam ().Next ();
                            Debug.WriteLine("Next team is " + instance.CurrentTeam().Current());
						}
					}

				} else {
					PopCurrentNode ();

					if (iteratingSet.Contains (stage)) {
						iteratingSet.Remove (stage);
                        if (text == "player") {
                            instance.PopPlayer();
                        } else if (text == "team") {
                            instance.PopTeam();
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

