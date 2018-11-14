using System;
using System.Collections.Generic;
using CardEngine;
using System.Diagnostics;
using FreezeFrame;
using System.Threading.Tasks;
using CardStockXam.Scoring;

namespace Players
{
    public class PIPMCSinglePlayer : AIPlayer
    {
        private static int NUMTESTS = 10; //previously 20

        public PIPMCSinglePlayer(Perspective perspective) : base(perspective) { }


        public override int MakeAction(int numChoices)
        {
            // SetupPrivateGame sets "privategame" equal to actualgame.clonesecret(idx) and
            // sets "privateiterator" equal to actualgameiterator.clone()
            (CardGame privategame, GameIterator privateiterator) = perspective.GetPrivateGame();
            int idx = perspective.GetIdx();

            Debug.WriteLine("PIPMC making choice. items: " + numChoices);

            double[][] inverseRankSum = new double[perspective.NumberOfPlayers()][];
            for (int i = 0; i < perspective.NumberOfPlayers(); i++)
            {
                inverseRankSum[i] = new double[numChoices];
            }

            Debug.WriteLine("Start Monte");

            // can parallellize here TODO ?
            // FOR EACH POSSIBLE MOVE


            for (int move = 0; move < numChoices; ++move)
            {
                Debug.WriteLine("iterating over item: " + move);

                Parallel.For(0, NUMTESTS, i =>   //number of tests for certain decision
                {
                    Debug.WriteLine("****Made Switch**** : " + i);

                    // JUST USING ONE CLONE SECRETGAME, CLONED FOR EACH MOVE
                    CardGame cg = privategame.Clone();
                    GameIterator cloneContext = privateiterator.Clone(cg);

                    // Make the chosen move
                    List<GameActionCollection> allOptions = cloneContext.BuildOptions();
                    allOptions[move].ExecuteAll();
                    cloneContext.PopCurrentNode();

                    // Assign the AI players for rollout game
                    for (int j = 0; j < numPlayers; j++)
                    {
                        cg.players[j].decision = new RandomPlayer(perspective);
                    }

                    Debug.WriteLine("Playing a simulated game");

                    while (!cloneContext.AdvanceToChoice())
                    {
                        cloneContext.ProcessChoice();
                    }

                    Debug.WriteLine("Simulated Game is Over");

                    // ProcessScore returns a sorted list 
                    // where the winner is rank 0 for either min/max games.
                    var winners = cloneContext.ProcessScore();

                    Debug.WriteLine("past ProcessScore");



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