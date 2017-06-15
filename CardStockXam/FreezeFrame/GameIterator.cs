using System;
using System.Diagnostics;
using Antlr4.Runtime.Tree;
using ParseTreeIterator;
using CardEngine;
using Analytics;
using System.Collections.Generic;
using System.Text;
using CardStockXam;

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
        private Random rand;
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
            
			//iterStack.Push(new Queue<IParseTree>());

		}
		public GameIterator (RecycleParser.GameContext g)
		{
			game = g;
            Console.Out.WriteLine("Processing declarations.");
            foreach (RecycleParser.DeclareContext declare in game.declare()){
                VarIterator.ProcessDeclare(declare);
            }
            Console.Out.WriteLine("Setting up game.");
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
            Console.WriteLine("Processing substage.");
			var sub = CurrentNode ();
            if (sub.ChildCount > 1 && sub.GetChild(1).GetText() == "choice") { return true; }
            else if (sub is RecycleParser.StageContext){
                //EvalGameLead(); TODO
                var allowedToRun = ProcessStage(sub as RecycleParser.StageContext);
                if (allowedToRun){
                    Console.WriteLine("Is a stage.");
                    iteratingSet.Add(sub);
                }
            }
            else if (sub is RecycleParser.MultiactionContext){
                PopCurrentNode();
                Console.WriteLine("Is a multiaction.");
                StageIterator.ProcessMultiaction(sub as RecycleParser.MultiactionContext);
            }
            else if (sub is RecycleParser.Multiaction2Context){
                PopCurrentNode();
                Console.WriteLine("Is a multiaction2.");
                StageIterator.ProcessMultiaction(sub as RecycleParser.Multiaction2Context);
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
					Console.WriteLine("Processing end of stage condition.");

					//Console.WriteLine("Hit Boolean while!");
					if (shouldInc) {
						StageCount.Instance.IncCount (stage);
						TimeStep.Instance.timeStep.Push (TimeStep.Instance.timeStep.Pop () + 1);
					}
					iterStack.Push (new Queue<IParseTree> ());
					var topLevel = iterStack.Peek ();
					Console.WriteLine ("Current Player: " + CardGame.Instance.CurrentPlayer ().idx);
					foreach (var player in CardGame.Instance.players) {
						Console.WriteLine ("HANDSIZE: " + player.cardBins ["{hidden}HAND"].Count);
					}
					for (int i = 4; i < stage.ChildCount - 1; ++i) {
						//TimeStep.Instance.treeLoc.Push(i - 4);
						//Debug.WriteLine (TimeStep.Instance);
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
        /* TODO
        public void EvalGameLead(){
            if (Scorer.gameWorld != null){
                var allOptions = new List<GameActionCollection>();
                for (int i = 0; i < choices.Length; ++i)
                {
                    var gacs = StageIterator.RecurseDo(choices[i]);
                    if (gacs.Count > 0)
                    {
                        allOptions.AddRange(gacs);
                    }
                }
                //BranchingFactor.Instance.AddCount(allOptions.Count, CardGame.Instance.CurrentPlayer().idx);
                if (allOptions.Count != 0){
                    Scorer.gameWorld.lead.Add(CheckAction(allOptions));
                }
                
            }
        }

        public double CheckAction(List<GameActionCollection> items)
        {
            if (items.Count == 1)
            {
                return 0;
            }
            CardEngine.CardGame.preserved = CardEngine.CardGame.Instance;


            var results = new int[items.Count];
            Debug.WriteLine("Start Monte");
            for (int item = 0; item < items.Count; ++item)
            {
                results[item] = 0;
                CardGame.Instance = CardGame.preserved.Clone();
                var flag = true;
                foreach (var player in CardGame.Instance.players){
                    player.decision = new Players.GeneralPlayer();
                }
                    var preservedIterator = ParseEngine.currentIterator;
                    var cloneContext = ParseEngine.currentIterator.Clone();
                    ParseEngine.currentIterator = cloneContext;
                    while (!cloneContext.AdvanceToChoice()){
                        cloneContext.ProcessChoice();
                    }
                    var winners = ScoreIterator.ProcessScore(ParseEngine.currentTree.scoring());
                    for (int j = 0; j < winners.Count; ++j){
                        if (winners[j].Item2 == 0){
                            results[item] += j;
                        }
                    }

                    ParseEngine.currentIterator = preservedIterator;

            }
            Debug.WriteLine("End Monte");
            //Debug.WriteLine ("***Switch Back***");
            CardGame.Instance = CardGame.preserved;
            var typeOfGame = ParseEngine.currentTree.scoring().GetChild(2).GetText();
            return GetAvg(results);
        }
        public static double GetAvg(int[] input)
        {
            int tot = 0;
            foreach (int val in input){
                tot += val;
            }
            return tot / input.Length;
        }*/
    }
}

