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

        private List<double> leadList;
        private CardGames.GameType type;
 
		public PIPMCPlayer(GameIterator m, CardGames.GameType type, int idx)
		{
			gameContext = m;
            numPlayers = gameContext.instance.players.Count;
            this.idx = idx;

            this.leadList = new List<double>();
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
            
			Debug.WriteLine("Passing new choice to PIPMC");
			Debug.WriteLine("AI making choice. items: " + items);

            var rankSum = new int[items];
            var inverseRankSum = new double[items];

            Debug.WriteLine("Start Monte");

            // can parallellize here TODO 
            // FOR EACH POSSIBLE MOVE

            for (int item = 0; item < items; ++item)
            {
                Debug.WriteLine("iterating over item: " + item);

                inverseRankSum[item] = 0;
                rankSum[item] = 0;

                Parallel.For(0, NUMTESTS, i =>   //number of tests for certain decision
                {
                    Debug.WriteLine("****Made Switch**** : " + i);

                    // gets through clonesecret
                    CardGame cg = gameContext.instance.CloneSecret(idx);

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

                    Debug.WriteLine("past processscore");

                    // TODO record everyone's ranks at all potential moves so can give to scoretracker
                    for (int j = 0; j < numPlayers; ++j)
                    {
                        // if player is me
                        if (winners[j].Item2 == idx)
                        {

                            // add your rank to the results of this choice
                            lock (this)
                            {
                                rankSum[item] += j;
                                inverseRankSum[item] += ((double)1) / (j + 1);
                            }

                            break;
                        }
                    }
                    Debug.WriteLine("in PIPMC");

                });

            }

			Debug.WriteLine("End Monte");
			Debug.WriteLine("resetting game state");

            // FIND BEST (and worst) MOVE TO MAKE
            var tup = MinMaxIdx(rankSum);

            Debug.WriteLine("Item1: " + tup.Item1);

            RecordHeuristics(items, inverseRankSum, tup.Item1, tup.Item2);
 
            Debug.WriteLine("AI Finished.");

            // This just returns item1 because ProcessScore returns a sorted list 
            // where the winner is rank 0 for either min/max games so don't change this.

            return tup.Item1;
        }

        public static Tuple<int, int> MinMaxIdx(int[] input)
        {
            int min = int.MaxValue;
            int max = int.MinValue;
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
        public void RecordHeuristics(int items, double[] inverseRankSum, int bestIndex, int worstIndex) {
            double[] wrs = new double[items];

            for (int item = 0; item < items; ++item)
            {
                wrs[item] = (((inverseRankSum[item]) / (NUMTESTS)) * ((double)numPlayers / (numPlayers - 1))) -
                    ((double)1 / ((numPlayers - 1)));
            }

            if (gameContext.gameWorld != null)
            {
                var max = wrs[bestIndex];
                var min = wrs[worstIndex];

                double avg = 0;
                for (int i = 0; i < wrs.Length; i++)
                {
                    avg += wrs[i];
                }
                avg /= (double)wrs.Length;

                var variance = Math.Abs(max - min);

                gameContext.gameWorld.AddInfo(variance, avg, wrs[bestIndex]);

                if (type == CardGames.GameType.AllAI)
                {
                    leadList.Add(max);

                    Debug.WriteLine("P" + idx + ":" + max);
                }
            }
        }

        // Used by the Heuristic Scorer to track the AI's heuristic rank throughout the game
        public override List<double> GetLead()
        {
            return leadList;
        }


    }


}