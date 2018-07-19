﻿﻿﻿﻿using System;
using System.Collections.Generic;
using CardEngine;
using System.Diagnostics;
using FreezeFrame;
using System.Threading.Tasks;

namespace Players
{
    public class PIPMCPlayer : AIPlayer
    {
        private static int NUMTESTS = 10; //previously 20
        private int idx;
         
        public PIPMCPlayer(GameIterator m, int idx) : base(m)
		{
            this.idx = idx;
        }

        public override int MakeAction(List<GameActionCollection> possibles, Random rand)
        {
            return NumChoices(possibles.Count, rand);
        }

		public int NumChoices(int items, Random rand){
            
			Debug.WriteLine("PIPMC making choice. items: " + items);

            var inverseRankSum = new double[items];

            Debug.WriteLine("Start Monte");

            // can parallellize here TODO ?
            // FOR EACH POSSIBLE MOVE

            for (int item = 0; item < items; ++item)
            {
                Debug.WriteLine("iterating over item: " + item);

                inverseRankSum[item] = 0;

                Parallel.For(0, NUMTESTS, i =>   //number of tests for certain decision
                {
                    Debug.WriteLine("****Made Switch**** : " + i);

                    // get new possible world through clonesecret
                    CardGame cg = gameContext.game.CloneSecret(idx);
                    var cloneContext = gameContext.Clone(cg);

                    // Assign the AI players for rollout game, with the 
                    // selected item chosen first when you get your turn
                    for (int j = 0; j < numPlayers; j++)
                    {

                        Debug.WriteLine("in PIPMC for loop:" + j);

                        if (j == idx)
                        {
                            cg.players[j].decision = new PredictablePlayer(cloneContext, item);
                        }
                        else
                        {
                            cg.players[j].decision = new RandomPlayer(cloneContext);
                        }
                    }

                    Debug.WriteLine("Playing a simulated game");

                    while (!cloneContext.AdvanceToChoice())
                    {
                        cloneContext.ProcessChoice();
                    }

                    Debug.WriteLine("Simulated Game is Over");

                    // ProcessScore returns a sorted list 
                    // where the winner is rank 0 for either min/max games.
                    var winners = cloneContext.parseoop.ProcessScore(cloneContext.rules.scoring());

                    Debug.WriteLine("past ProcessScore");

                    // TODO record everyone's ranks at all potential moves 
                    // so can give to scoretracker ??
                    for (int j = 0; j < numPlayers; ++j)
                    {
                        // if player is me
                        if (winners[j].Item2 == idx)
                        {

                            // add your rank to the results of this choice
                            lock (this)
                            {
                                inverseRankSum[item] += (((double)1) / (j + 1)) / NUMTESTS;
                            }

                            break;
                        }
                    }

                    Debug.WriteLine("saved the inverseRankSum");
                });
            }

			Debug.WriteLine("End Monte");

            // FIND BEST (and worst) MOVE TO MAKE
            var tup = MinMaxIdx(inverseRankSum);

            Debug.WriteLine("Max invRankSum: " + tup.Item2);
            Debug.WriteLine("PIPMC Finished.");

            // Record info for heuristic evaluation
            RecordHeuristics(inverseRankSum);

            return tup.Item2;
        }
    }
}