using System.Diagnostics;
using CardStock.CardEngine;
using CardStock.FreezeFrame;

namespace CardStock.Players
{
    public class PIPMCPlayerNew(Perspective perspective) : AIPlayer(perspective)
    {
        private static readonly int NUMTESTS = 1000; //previously 20
        private static readonly int NUMSAMPLES = 10;

        public override int MakeAction(int numMoves)
        {

            double[][] rankSum = new double[perspective.NumberOfPlayers()][];
            for (int i = 0; i < perspective.NumberOfPlayers(); i++)
            {
                rankSum[i] = new double[numMoves];
            }
            
            // https://stackoverflow.com/questions/16376191/measuring-code-execution-time-in-this-code
            Stopwatch stopwatch = Stopwatch.StartNew(); 

            // FOR EACH POSSIBLE MOVE
            for (int move = 0; move < numMoves; ++move)
            {
                // MAKE THIS MANY DETERMINIZATIONS
                for (int det = 0; det < NUMSAMPLES; det++)
                {

                    (CardGame cgo, GameIterator cloneContexto) = perspective.GetPrivateGame();

                    // AND RUN THIS MANY ROLLOUTS
                    Parallel.For(0, NUMTESTS / NUMSAMPLES, i =>   //number of tests for certain decision
                    {

                        CardGame cg = cgo.Clone();
                        GameIterator cloneContext = cloneContexto.Clone(cg);

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

                        // Play the game until termination
                        while (!cloneContext.AdvanceToChoice())
                        {
                            cloneContext.ProcessChoice();
                        }

                        // ProcessScore returns a sorted list 
                        // where the winner is rank 0 for either min/max games.
                        var winners = cloneContext.ProcessScore();

                        int topRank = 0;
                        lock (this)
                        {
                            for (int j = 0; j < numPlayers; ++j)
                            {

                                if (j != 0 && winners[j].Item1 != winners[j - 1].Item1)
                                {
                                    topRank = j;
                                }

                                rankSum[winners[j].Item2][move] += (double)topRank / NUMTESTS;
                            }
                        }

                    });
                }
            }

            // FIND BEST (and worst) MOVE TO MAKE
            var tup = MinMaxIdx(rankSum[perspective.GetIdx()]);

            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            Console.WriteLine("Player " + perspective.GetIdx() + " picked " + tup.Item1);
            Console.WriteLine("{0}", string.Join(", ", rankSum[perspective.GetIdx()]));

            // Record info for heuristic evaluation
            RecordHeuristics(rankSum);

            return tup.Item1;
        }
    }
}
