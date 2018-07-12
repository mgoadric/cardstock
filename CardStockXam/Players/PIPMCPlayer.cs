﻿﻿﻿﻿using System;
using System.Collections.Generic;
using CardEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using FreezeFrame;
using ParseTreeIterator;
using CardStockXam;
using System.Threading.Tasks;

namespace Players
{
    public class PIPMCPlayer : GeneralPlayer
    {
        private static int NUMTESTS = 10; //previously 20

		private GameIterator gameContext;
        private int numPlayers;
        private int idx;

        private CardGames.GameType type;
 
		public PIPMCPlayer(GameIterator m, CardGames.GameType type, int idx)
		{
			gameContext = m;
            numPlayers = gameContext.instance.players.Count;
            this.idx = idx;

            this.type = type;
        }

        public override int MakeAction(List<GameActionCollection> possibles, Random rand)
        {
            
            return NumChoices(possibles.Count, rand);
        }

        public override int MakeAction(JObject possibles, Random rand)
        {
            var items = (JArray)possibles["items"];
            return NumChoices(items.Count, rand);
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
                    CardGame cg = gameContext.instance.CloneSecret(idx);

                    // Assign the AI players for rollout game, with the 
                    // selected item chosen first when you get your turn
                    for (int j = 0; j < cg.players.Count; j++)
                    {

                        Debug.WriteLine("in PIPMC for loop:" + j);

                        if (j == idx)
                        {
                            Debug.WriteLine("Player turn: " + cg.CurrentPlayer().idx);
                            Debug.WriteLine("Predictable player choice set: " + item);

                            cg.players[j].decision = new PredictablePlayer()
                            {
                                toChoose = item
                            };
                        }
                        else
                        {
                            cg.players[j].decision = new Players.GeneralPlayer();
                        }
                    }

                    Debug.WriteLine("in PIPMC");

                    var cloneContext = gameContext.Clone(cg);

                    Debug.WriteLine("Playing a simulated game");

                    while (!cloneContext.AdvanceToChoice())
                    {
                        cloneContext.ProcessChoice();
                    }

                    Debug.WriteLine("Simulated Game is Over");

                    // ProcessScore returns a sorted list 
                    // where the winner is rank 0 for either min/max games.
                    var winners = cloneContext.parseoop.ProcessScore(cloneContext.game.scoring());

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
                                inverseRankSum[item] += ((double)1) / (j + 1);
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
            Debug.WriteLine("AI Finished.");

            // Record info for heuristic evaluation
            RecordHeuristics(inverseRankSum);

            return tup.Item2;
        }

        public static Tuple<int, int> MinMaxIdx(double[] input)
        {
            double min = double.MaxValue;
            double max = double.MinValue;
            int minIdx = -1;
            int maxIdx = -1;
            for (int i = 0; i < input.Length; ++i)
            {
                if (input[i] > max)
                {
                    max = input[i];
                    maxIdx = i;
                }
                if (input[i] < min)
                {
                    min = input[i];
                    minIdx = i;
                }
            }
            return new Tuple<int, int>(minIdx, maxIdx);
        }

        // CODE FOR UPDATING STATISTICS FOR HEURISTICS
        public void RecordHeuristics(double[] inverseRankSum) {
            if (gameContext.gameWorld != null)
            {
                // WHAT DOES WRS stand for?
                double[] wrs = new double[inverseRankSum.Length];

                for (int item = 0; item < inverseRankSum.Length; ++item)
                {
                    wrs[item] = (((inverseRankSum[item]) / (NUMTESTS)) * ((double)numPlayers / (numPlayers - 1))) -
                        ((double)1 / ((numPlayers - 1)));
                }

                var tup = MinMaxIdx(inverseRankSum);
                var max = wrs[tup.Item2];
                var min = wrs[tup.Item1];

                double avg = 0;
                for (int i = 0; i < wrs.Length; i++)
                {
                    avg += wrs[i];
                }
                avg /= (double)wrs.Length;

                var variance = Math.Abs(max - min);

                gameContext.gameWorld.AddInfo(variance, avg, wrs[tup.Item2]);
                leadList.Add(max);
            }
        }
    }
}