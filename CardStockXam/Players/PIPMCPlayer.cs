using CardEngine;
using FreezeFrame;
using Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardStockXam.Players
{
    public class PIPMCPlayer : AIPlayer
    {
        private static int NUMTESTS = 10; //previously 20

        public PIPMCPlayer(Perspective perspective) : base(perspective) { }

        public override int MakeAction(int numMoves)
        {

            double[][] inverseRankSum = new double[perspective.NumberOfPlayers()][];
            for (int i = 0; i < perspective.NumberOfPlayers(); i++)
            {
                inverseRankSum[i] = new double[numMoves];
            }
            // can parallellize here TODO ?
            // FOR EACH POSSIBLE MOVE


            for (int move = 0; move < numMoves; ++move)
            {
                //inverseRankSum[move] = 0;

                Parallel.For(0, NUMTESTS, i =>   //number of tests for certain decision
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

                            inverseRankSum[winners[j].Item2][move] += (((double)1) / (topRank + 1)) / NUMTESTS;
                        }
                    }

                });
            }

            // FIND BEST (and worst) MOVE TO MAKE
            var tup = MinMaxIdx(inverseRankSum[perspective.GetIdx()]);

            // Record info for heuristic evaluation
            RecordHeuristics(inverseRankSum);

            return tup.Item2;
        }
    }
}
