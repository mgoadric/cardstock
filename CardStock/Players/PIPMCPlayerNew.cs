using System.Diagnostics;
using CardStock.CardEngine;
using CardStock.FreezeFrame;

namespace CardStock.Players
{
    public class PIPMCPlayerNew(Perspective perspective) : AIPlayer(perspective)
    {
        private static readonly int NUMTESTS = 1000; //previously 20
        private static readonly int NUMSAMPLES = 10;

        private int[] completed;

        private double[][] rankSum;
        private double[][] scoreSum;

        public override void Explore()
        {
            // https://stackoverflow.com/questions/16376191/measuring-code-execution-time-in-this-code
            Stopwatch stopwatch = Stopwatch.StartNew();
            completed = new int[numChoices];

            rankSum = new double[perspective.NumberOfPlayers()][];
            for (int i = 0; i < perspective.NumberOfPlayers(); i++)
            {
                rankSum[i] = new double[numChoices];
            }

            scoreSum = new double[perspective.NumberOfPlayers()][];
            for (int i = 0; i < perspective.NumberOfPlayers(); i++)
            {
                scoreSum[i] = new double[numChoices];
            }

            // MAKE THIS MANY DETERMINIZATIONS
            List<Tuple<CardGame, GameIterator>> determinizations = [];
            for (int det = 0; det < NUMSAMPLES; det++)
            {
                determinizations.Add(perspective.GetPrivateGame());
            }

            // FOR EACH POSSIBLE MOVE
            for (int i = 0; i < NUMTESTS / NUMSAMPLES; i++)
            {
                // USE THIS MANY DETERMINIZATIONS
                for (int det = 0; det < NUMSAMPLES; det++)
                {
                    // AND RUN THIS MANY ROLLOUTS
                    Parallel.For(0, numChoices, move =>   //number of tests for certain decision
                    {

                        CardGame cg = determinizations[det].Item1.Clone();
                        GameIterator cloneContext = determinizations[det].Item2.Clone(cg);

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

                        // Play the game until termination  WHAT ABOUT NONTERMINAL GAMES???
                        // Do a cutoff like ParseEngine does at 200???
                        // WHO WINS IN THOSE GAMES??
                        int count = 0;
                        while (!cloneContext.AdvanceToChoice())
                        {
                            cloneContext.ProcessChoice();
                            count++;
                            if (count > GameSimulator.CHOICELIMIT)
                            {
                                break;
                            }
                        }

                        // ProcessScore returns a sorted list 
                        // where the winner is rank 0 for either min/max games.
                        var (winners, mult) = cloneContext.ProcessScore();

                        int topRank = 0;
                        lock (this)
                        {
                            for (int j = 0; j < numPlayers; ++j)
                            {
                                if (j != 0 && winners[j].Item1 != winners[j - 1].Item1)
                                {
                                    topRank = j;
                                }

                                // OLD RANK BASED 
                                rankSum[winners[j].Item2][move] += (double)topRank;

                                // NEW VALUE BASED
                                scoreSum[winners[j].Item2][move] += (double)winners[j].Item1 * mult;

                            }
                            completed[move]++;
                        }

                    });
                }
            }
            stopwatch.Stop();
            Console.WriteLine("Time: " + stopwatch.ElapsedMilliseconds);
            Console.WriteLine("{0}", string.Join(", ", completed));
        }
        
        public override int Choose() {
            for (int i = 0; i < numPlayers; i++)
            {
                for (int m = 0; m < numChoices; m++)
                {
                    scoreSum[i][m] /= completed[m];
                    rankSum[i][m] /= completed[m];
                }
            }

            // FIND BEST (and worst) MOVE TO MAKE
            var tup = MinMaxIdx(scoreSum[perspective.GetIdx()]);
            
            Console.WriteLine(perspective.GetIdx() + " choosing move " + tup.Item2);
            Console.WriteLine("{0}", string.Join(", ", scoreSum[perspective.GetIdx()]));

            // Record info for heuristic evaluation
            RecordHeuristics(rankSum);

            // NEW SCORE (highest is best)
            return tup.Item2;
        }
    }
}
