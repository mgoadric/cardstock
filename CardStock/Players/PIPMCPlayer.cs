using System.Diagnostics;
using CardStock.CardEngine;
using CardStock.FreezeFrame;
using CardStock.Evaluation;

namespace CardStock.Players
{
    public class PIPMCPlayer(Perspective perspective) : AIPlayer(perspective)
    {

        private double[][] rankSum;

        public override void Explore()
        {

            // https://stackoverflow.com/questions/16376191/measuring-code-execution-time-in-this-code
            Stopwatch stopwatch = Stopwatch.StartNew();

            rankSum = new double[perspective.NumberOfPlayers()][];
            for (int i = 0; i < perspective.NumberOfPlayers(); i++)
            {
                rankSum[i] = new double[numChoices];
            }

            // can parallellize here TODO ?
            // FOR EACH POSSIBLE MOVE
            for (int move = 0; move < numChoices; ++move)
            {

                Parallel.For(0, GameSimulator.NUMTESTS, i =>   //number of tests for certain decision
                {
                    // USE A SEPERATE CLONESECRET FOR EACH GAME
                    (CardGame cg, GameIterator cloneContext) = perspective.GetPrivateGame();

                    // Make the chosen move
                    List<GameActionCollection> allOptions = cloneContext.BuildOptions();
                    allOptions[move].ExecuteAll();
                    cloneContext.PopCurrentNode();

                    // Assign the AI players for rollout game, with the 
                    // selected item chosen first when you get your turn
                    for (int j = 0; j < numPlayers; j++)
                    {
                        cg.players[j].decision = new RandomPlayer(perspective);
                    }

                    while (!cloneContext.AdvanceToChoice())
                    {
                        cloneContext.ProcessChoice();
                    }

                    // ProcessScore returns a sorted list 
                    // where the winner is rank 0 for either min/max games.
                    var (results, mult) = cloneContext.ProcessScore();
                    int[] ranks = DataCollector.FindRanks(results, mult);
                    lock (this)
                    {
                        for (int j = 0; j < numPlayers; ++j)
                        {
                            // OLD RANK BASED 
                            rankSum[j][move] += ranks[j];

                        }
                    }
                });
            }
            stopwatch.Stop();
            Console.WriteLine("Time: " + stopwatch.ElapsedMilliseconds);

        }
        
        public override int ChooseOption() {
            // FIND BEST (and worst) MOVE TO MAKE
            var (min, max) = MinMaxIdx(rankSum[perspective.GetIdx()]);

            Console.WriteLine(perspective.GetIdx() + " chose " + min);
            Debug.WriteLine("{0}", string.Join(", ", rankSum[perspective.GetIdx()]));

            // Record info for heuristic evaluation
            RecordHeuristics(rankSum);

            return min;
        }
    }
}
