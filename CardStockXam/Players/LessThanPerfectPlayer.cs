﻿﻿﻿﻿using System;
using System.Collections.Generic;
using CardEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using FreezeFrame;
using ParseTreeIterator;
using CardStockXam;

namespace Players
{
    public class LessThanPerfectPlayer : GeneralPlayer
    {
        private static int numTests = 10; //previously 20
        private GameIterator gameContext;

		public LessThanPerfectPlayer(GameIterator m)
		{
			gameContext = m;
		}

		public int NumChoices(int items, Random rand, int idx){
			Debug.WriteLine("Passing new choice to LPP");

			ParseEngine.expstat.logging = false;
			Console.WriteLine("AI making choice. items: " + items);

			if (items == 1)
			{
                ParseEngine.expstat.logging = true;
				return 0;
			}

			var results = new int[items];
			var total = new int[items];
			double[] wrs = new double[items];
			Debug.WriteLine("Start Monte");
			for (int item = 0; item < items; ++item)
			{
                Debug.WriteLine("iterating over item: " + item);
				double numWon = 0;
				results[item] = 0;
				for (int i = 0; i < numTests; ++i)//number of tests for certain decision
				{
					Debug.WriteLine("****Made Switch**** : " + i);

                    // gets through clonesecret
					CardGame cg = gameContext.instance.CloneSecret(idx);

                    for (int j = 0; j < cg.players.Count; j++)
                    {
                        
                        Debug.WriteLine("in lpp for loop:" + j);
                        if (j == idx) {
							Debug.WriteLine("Player turn: " + cg.CurrentPlayer().idx);
							Debug.WriteLine("Predictable player choice set: " + item);

                            cg.players[j].decision = new PredictablePlayer()
                            {
						     	toChoose = item
                            };
                        }
                         else {
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

					var winners = cloneContext.parseoop.ProcessScore(ParseEngine.currentTree.scoring());
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
							numWon += lead;
							break;
						}
					}
					Debug.WriteLine("in lpp");

				}
                Debug.WriteLine("Aggregated rank: " + results[item]);
				wrs[item] = (double)numWon / numTests;
                Debug.WriteLine("wrs " + wrs[item]);

			}
			Debug.WriteLine("End Monte");
			//Debug.WriteLine ("***Switch Back***");

			Debug.WriteLine("resetting game state");

			var tup = MinMaxIdx(results);
			if (Scorer.gameWorld != null)
			{
				//var max = results[tup.Item2] / total[tup.Item2];
				//var min = results[tup.Item1] / total[tup.Item1];
				var max = 0.0;
				var min = 1.0;
				foreach (double d in wrs)
				{
					max = Math.Max(max, d);
					min = Math.Min(min, d);
				}
				var variance = Math.Abs(max - min);
				Scorer.gameWorld.variance.Add(variance);
				Scorer.gameWorld.Lead(gameContext.instance.currentPlayer.Peek().idx).Add(max);

			}
            ParseEngine.expstat.logging = true;
            Debug.WriteLine("AI Finished.");

            // This just returns item1 because ProcessScore returns a sorted list 
            // where the winner is rank 0 for either min/max games so don't change this.
            Debug.WriteLine("Item1: " + tup.Item1);
            return tup.Item1;
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