using System.Diagnostics;
using CardStock.CardEngine;
using CardStock.FreezeFrame;
using CardStock.Evaluation;

namespace CardStock.Players
{
    public class PIPMCPlayerNew(Perspective perspective) : AIPlayer(perspective)
    {

        private int[] completed;

        private double[][] rankSum;
        private double[][] scoreSum;

        private List<Tuple<CardGame, GameIterator>> determinizations;

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
            determinizations = [];
            for (int det = 0; det < GameSimulator.NUMSAMPLES; det++)
            {
                determinizations.Add(perspective.GetPrivateGame());
            }

            // FOR EACH POSSIBLE MOVE
            for (int i = 0; i < GameSimulator.NUMTESTS / GameSimulator.NUMSAMPLES; i++)
            {
                // USE THIS MANY DETERMINIZATIONS
                for (int det = 0; det < GameSimulator.NUMSAMPLES; det++)
                {
                    // AND RUN THIS MANY ROLLOUTS
                    Parallel.For(0, numChoices, move =>   //number of tests for certain decision
                    {

                        RunSimulation(det, move);

                    });
                }
            }
            stopwatch.Stop();
            Console.WriteLine("Time: " + stopwatch.ElapsedMilliseconds);
        }

        public override int Choose()
        {
            for (int i = 0; i < numPlayers; i++)
            {
                for (int m = 0; m < numChoices; m++)
                {
                    scoreSum[i][m] /= completed[m];
                    rankSum[i][m] /= completed[m];
                }
            }

            // FIND BEST (and worst) MOVE TO MAKE
            var (min, max) = MinMaxIdx(scoreSum[perspective.GetIdx()]);

            Console.WriteLine(perspective.GetIdx() + " choosing move " + max);
            Console.WriteLine("{0}", string.Join(", ", scoreSum[perspective.GetIdx()]));

            // Record info for heuristic evaluation
            RecordHeuristics(rankSum);

            // NEW SCORE (highest is best)
            return max;
        }


        public void RunSimulation(int det, int move)
        {
            CardGame cg = determinizations[det].Item1.Clone();
            GameIterator cloneContext = determinizations[det].Item2.Clone(cg);

            // Make the chosen move
            cloneContext.BuildOptions()[move].ExecuteAll();
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
        }
    }
}

