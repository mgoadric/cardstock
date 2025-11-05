using System.Diagnostics;
using CardStock.CardEngine;
using CardStock.FreezeFrame;
using CardStock.Evaluation;

namespace CardStock.Players
{
    public class PIPMCPlayer(Perspective perspective) : AIPlayer(perspective)
    {

        private int[] completed;

        private readonly double[][] rankSum = new double[perspective.NumberOfPlayers()][];
        private readonly double[][] scoreSum = new double[perspective.NumberOfPlayers()][];

        private readonly Tuple<CardGame, GameIterator>[] determinizations = new Tuple<CardGame, GameIterator>[GameSimulator.NUMSAMPLES];

        public override void Explore()
        {
            completed = new int[numChoices];

            for (int i = 0; i < perspective.NumberOfPlayers(); i++)
            {
                rankSum[i] = new double[numChoices];
                scoreSum[i] = new double[numChoices];
            }

            // MAKE THIS MANY DETERMINIZATIONS
            for (int det = 0; det < GameSimulator.NUMSAMPLES; det++)
            {
                determinizations[det] = perspective.GetPrivateGame();
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
        }

        public override int ChooseOption()
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
            var (_, max) = MinMaxIdx(scoreSum[perspective.GetIdx()]);

            //Console.WriteLine(perspective.GetIdx() + " choosing move " + max);
            //Console.WriteLine("{0}", string.Join(", ", scoreSum[perspective.GetIdx()]));

            // Record info for heuristic evaluation
            dc.RecordHeuristics(scoreSum, rankSum, perspective.GetIdx());

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
                cg.players[j].decision = null;
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
            var (results, mult) = cloneContext.ProcessScore();
            int[,] ranks = DataCollector.FindRanks(results, mult);
            lock (this)
            {
                for (int j = 0; j < numPlayers; ++j)
                {
                    // OLD RANK BASED 
                    rankSum[j][move] += ranks[j,0];

                    // NEW VALUE BASED
                    scoreSum[j][move] += results[j] * mult;

                }
                completed[move]++;
            }
        }
    }
}

