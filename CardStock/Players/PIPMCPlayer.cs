using System.Diagnostics;
using CardStock.CardEngine;
using CardStock.FreezeFrame;
using CardStock.Evaluation;
using CardStock.FreezeFrame.Actions;

namespace CardStock.Players
{
    public class PIPMCPlayer(Perspective perspective, DataCollector dc) : AIPlayer(perspective, dc)
    {

        private int[] completed;

        private readonly double[][] moveRanks = new double[perspective.NumberOfPlayers()][];
        private readonly double[][] moveScores = new double[perspective.NumberOfPlayers()][];
        private readonly double[][] moveWins = new double[perspective.NumberOfPlayers()][];

        private readonly Tuple<CardGame, GameIterator>[] determinizations = new Tuple<CardGame, GameIterator>[dc.exp.numSamples];

        public override void Explore(List<string> allData)
        {

            completed = new int[numChoices];

            for (int i = 0; i < numPlayers; i++)
            {
                moveRanks[i] = new double[numChoices];
                moveScores[i] = new double[numChoices];
                moveWins[i] = new double[numChoices];
            }

            // MAKE THIS MANY DETERMINIZATIONS
            for (int det = 0; det < dc.exp.numSamples; det++)
            {
                determinizations[det] = perspective.GetPrivateGame();
            }

            for (int i = 0; i < dc.exp.numSamples; i++)
            {
                int det = i / numChoices % dc.exp.numSamples;
                int move = i % numChoices;

                RunSimulation(det, move);
            }
        }

        public override int ChooseOption()
        {
            for (int i = 0; i < numPlayers; i++)
            {
                for (int m = 0; m < numChoices; m++)
                {
                    moveScores[i][m] /= completed[m];
                    moveRanks[i][m] /= completed[m];
                    moveWins[i][m] /= completed[m];
                }
            }

            // FIND BEST (and worst) MOVE TO MAKE
            //var (_, max) = MinMaxIdx(moveScores[perspective.GetIdx()], numChoices);
            var (_, max) = MinMaxIdx(moveWins[perspective.GetIdx()], numChoices);

            //Console.WriteLine("{0}", string.Join(", ", moveWins[perspective.GetIdx()][..numChoices]));
            //Console.WriteLine(perspective.GetIdx() + " choosing move " + max);

            // Record info for heuristic evaluation
            dc.RecordHeuristics(moveScores, moveRanks, perspective.GetIdx());

            // NEW SCORE (highest is best)
            return max;
        }


        public void RunSimulation(int det, int move)
        {
            CardGame cg = determinizations[det].Item1.Clone();
            GameIterator cloneContext = determinizations[det].Item2.Clone(cg);

            // Make the chosen move
            (List<GameActionCollection> allOptions, _) = cloneContext.BuildOptions();
            allOptions[move].ExecuteAll();
            cloneContext.PopCurrentNode();

            // Assign the AI players for rollout game, with the 
            // selected item chosen first when you get your turn
            cg.WipePlayers();

            // Play the game until termination or CHOICELIMIT reached
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
            var results = cloneContext.ProcessScore();
            var mult = cloneContext.ProcessDirection();
            int[,] ranks = DataCollector.FindRanks(results, mult);
            lock (this)
            {
                for (int j = 0; j < numPlayers; ++j)
                {
                    // OLD RANK BASED 
                    moveRanks[j][move] += ranks[j, 0];

                    // NEW VALUE BASED
                    moveScores[j][move] += results[j] * mult;

                    // EVEN NEWER WIN BASED
                    moveWins[j][move] += ranks[j, 0] == 0 ? 1 : 0;
                }
                completed[move]++;
            }
        }
    }
}