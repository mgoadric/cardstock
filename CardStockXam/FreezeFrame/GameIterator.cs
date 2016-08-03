using System;
using System.Diagnostics;
using Antlr4.Runtime.Tree;
using ParseTreeIterator;
using CardEngine;
using Analytics;
using System.Collections.Generic;
using System.Text;

namespace FreezeFrame
{
	public class GameIterator
	{
		RecycleParser.GameContext game;
		Stack<Queue<IParseTree>> iterStack;
		HashSet<IParseTree> iteratingSet;
		bool shouldInc = true;
		public int decisionBranch = -1;
		public int decisionIdx = -1;
        //public StringBuilder recorder;

		public GameIterator Clone(){
			var ret = new GameIterator (game,false);
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
			ret.decisionBranch = decisionBranch;
			ret.decisionIdx = decisionIdx;
			return ret;
		}
		public GameIterator(RecycleParser.GameContext g, Boolean f){
			game = g;
			iterStack = new Stack<Queue<IParseTree>> ();
			iteratingSet = new HashSet<IParseTree> ();
			shouldInc = false;
            
			iterStack.Push(new Queue<IParseTree>());

		}
		public GameIterator (RecycleParser.GameContext g)
		{
			game = g;
            foreach (RecycleParser.DeclareContext declare in game.declare()){
                SetupIterator.ProcessDeclare(declare);
            }
			SetupIterator.ProcessSetup(game.setup()).ExecuteAll();
			iterStack = new Stack<Queue<IParseTree>> ();
			iteratingSet = new HashSet<IParseTree> ();
			iterStack.Push(new Queue<IParseTree>());
			var topLevel = iterStack.Peek ();
			for (int i = 3; i < game.ChildCount - 2; ++i){
				topLevel.Enqueue (game.GetChild (i));
			}
		}
		public bool AdvanceToChoice(){
			while (iterStack.Count != 0 && !ProcessSubStage()) {
				
			}
			if (iterStack.Count == 0) {
				return true;//game over
			}
			return false;//interupted by player decision
		}
		public IParseTree CurrentNode(){
			
			var ret =  iterStack.Peek ().Peek ();
			return ret;
		}
		public void PopCurrentNode(){
			iterStack.Peek ().Dequeue ();
			if (iterStack.Peek ().Count == 0) {
				iterStack.Pop ();
			}

		}
		public bool ProcessSubStage(){
			var sub = CurrentNode () as RecycleParser.MultiactionContext;
            StageIterator.ProcessSubStage(sub);
            if (sub.GetChild(1).GetText() == "choice"){ return true; }
			return false;
		}
		public void ProcessChoice(){
			var sub = CurrentNode ();
			var choice = sub as RecycleParser.MultiactionContext;
			StageIterator.ProcessChoice(choice.condact());
			PopCurrentNode ();
		}
		//this just queues the appropriate actions if condition is met, doesn't execute
		public bool ProcessStage(RecycleParser.StageContext stage){

			if (stage.endcondition().boolean() != null){

				if (!iteratingSet.Contains (stage)) {
					CardGame.Instance.PushPlayer ();
					if (shouldInc) {
						TimeStep.Instance.timeStep.Push (0);
					}
				}

				if (!BooleanIterator.ProcessBoolean (stage.endcondition ().boolean ())) {
					//Console.WriteLine("Hit Boolean while!");
					if (shouldInc) {
						StageCount.Instance.IncCount (stage);
						TimeStep.Instance.timeStep.Push (TimeStep.Instance.timeStep.Pop () + 1);
					}
					iterStack.Push (new Queue<IParseTree> ());
					var topLevel = iterStack.Peek ();
					Debug.WriteLine ("Current Player: " + CardGame.Instance.CurrentPlayer ().idx);
					foreach (var player in CardGame.Instance.players) {
						Debug.WriteLine ("HANDSIZE: " + player.cardBins ["{hidden}HAND"].Count);
					}
					for (int i = 4; i < stage.ChildCount - 1; ++i) {
						//TimeStep.Instance.treeLoc.Push(i - 4);
						Debug.WriteLine (TimeStep.Instance);
						//ProcessSubStage(stage.GetChild(i));
						topLevel.Enqueue (stage.GetChild (i));
						//TimeStep.Instance.treeLoc.Pop();
					}
					if (iteratingSet.Contains (stage)) {
						if (stage.GetChild (2).GetText () == "player") {
							CardGame.Instance.CurrentPlayer ().Next ();
						} else if (stage.GetChild (2).GetText () == "team") {
							CardGame.Instance.CurrentTeam ().Next ();
						}
					}

				} else {
					PopCurrentNode ();

					if (iteratingSet.Contains (stage)) {
						iteratingSet.Remove (stage);
						if (shouldInc) {
							TimeStep.Instance.timeStep.Pop ();
						}
						CardGame.Instance.PopPlayer ();
					}
					return false;
				}
				//TimeStep.Instance.timeStep.Pop();
			}
			return true;
			//CardGame.Instance.PopPlayer();
		}
        //public override String ToString() {
        //    return recorder.ToString();
        //}
    }
}

