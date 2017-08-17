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
    public class LessThanPerfectPlayer : GeneralPlayer
    {
		private static int numTests = 10; //previously 20
		private GameIterator gameContext;
		private List<double> leadList;
		public CardGames.GameType type;

		public LessThanPerfectPlayer(GameIterator m, CardGames.GameType type)
		{
			this.type = type;
			gameContext = m;
			this.leadList = new List<double>();
		}

		public int NumChoices(int items, Random rand, int idx){
			Debug.WriteLine("Passing new choice to LPP");

			Debug.WriteLine("AI making choice. items: " + items);

			/*if (items == 1)
			{
				return 0;
			}*/

			var results = new int[items];
			var total = new int[items];
			double[] wrs = new double[items];
			Debug.WriteLine("Start Monte");


            // can parallellize here TODO 


			for (int item = 0; item < items; ++item)
			{
                Debug.WriteLine("iterating over item: " + item);
				double numWon = 0;
				results[item] = 0;
                Parallel.For(0, numTests, i =>

                //for (int i = 0; i < numTests; ++i)//number of tests for certain decision
                {
                    Debug.WriteLine("****Made Switch**** : " + i);

                    // gets through clonesecret
                    CardGame cg = gameContext.instance.CloneSecret(idx);

                    for (int j = 0; j < cg.players.Count; j++)
                    {

                        Debug.WriteLine("in lpp for loop:" + j);
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


                    Debug.WriteLine("in lpp");

                    var cloneContext = gameContext.Clone(cg);
                    Debug.WriteLine("in lpp");
                    while (!cloneContext.AdvanceToChoice())
                    {
                        // caught here for sure
                        cloneContext.ProcessChoice();
                    }
                    // TODO make sure changes to processscore didn't screw this up
                    // figure this chunk out 
                    Debug.WriteLine("after advance to choice");

                    var winners = cloneContext.parseoop.ProcessScore(cloneContext.game.scoring());
                    Debug.WriteLine("past processscore");
                    total[item] = winners.Count;


                    for (int j = 0; j < winners.Count; ++j)
                    {
                        // if player is me
                        if (winners[j].Item2 == idx)
                        {
                            // add your rank to the results of this choice
                            results[item] += j;

                            int div = j + 1;
                            double lead = ((double)1) / div;
                            lock (this)
                            {
                                numWon += lead;
                            }
                            break;
                        }
                    }
                    Debug.WriteLine("in lpp");

                });
                Debug.WriteLine("Aggregated rank: " + results[item]);
                // stretch & shift this number depending on number of players

                // 
                wrs[item] = (((numWon) / (numTests)) * ((double)total[item] / (total[item] - 1))) - ((double)1 / ((total[item] - 1)));


				Debug.WriteLine("wrs " + wrs[item]);

			}
			Debug.WriteLine("End Monte");
			//Debug.WriteLine ("***Switch Back***");

			Debug.WriteLine("resetting game state");

			var tup = MinMaxIdx(results);
            if (gameContext.gameWorld != null)
            {
                //var max = results[tup.Item2] / total[tup.Item2];
                //var min = results[tup.Item1] / total[tup.Item1];
                var max = wrs[tup.Item1];
                var min = wrs[tup.Item2];

                var variance = Math.Abs(max - min);
                // TODO t
                gameContext.gameWorld.variance.Add(variance);
                if (type == CardGames.GameType.AllAI)
                {
                    
                    leadList.Add(max);
                }
			}
            Debug.WriteLine("AI Finished.");

            // This just returns item1 because ProcessScore returns a sorted list 
            // where the winner is rank 0 for either min/max games so don't change this.
            Debug.WriteLine("Item1: " + tup.Item1);
            return tup.Item1;
        }

        public override List<double> GetLead() {
            return leadList;
        }

        public override int MakeAction(List<GameActionCollection> possibles, Random rand, int idx)
        {

            return NumChoices(possibles.Count, rand, idx);
        }

        public override int MakeAction(JObject possibles, Random rand, int idx)
        {
            var items = (JArray)possibles["items"];
            return NumChoices(items.Count, rand, idx);
        }

        public static Tuple<int,int> MinMaxIdx(int[] input)
        {
            int min = int.MaxValue;
            int max = int.MinValue;
            int minIdx = -1;
            int maxIdx = -1;
            for (int i = 0; i < input.Length; ++i){
                if (input[i] > max){
                    max = input[i];
                    maxIdx = i;
                }
                if (input[i] < min){
                    min = input[i];
                    minIdx = i;
                }
            }
            return new Tuple<int, int>(minIdx, maxIdx);
        }
    }
}