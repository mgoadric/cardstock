using System;
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

        public int NumChoices(int items, Random rand, int idx){
            if (items == 1)
			{
				return 0;
			}
			CardEngine.CardGame.preserved = CardEngine.CardGame.Instance;


			var results = new int[items];
			var total = new int[items];
			double[] wrs = new double[items];
			Debug.WriteLine("Start Monte");
            // CAUGHT IN LOOP HERE TODO 
			for (int item = 0; item < items; ++item)
			{
				double numWon = 0;
				int numTotal = 0;
				results[item] = 0;
				for (int i = 0; i < numTests; ++i)//number of tests for certain decision
				{
					Debug.WriteLine("****Made Switch****");
                    // gets through clonesecret
					CardGame.Instance = CardGame.preserved.CloneSecret(idx);

					var flag = true;
					foreach (var player in CardGame.Instance.players)
					{
						if (flag)
						{
							flag = false;
							player.decision = new PredictablePlayer();
							((PredictablePlayer)player.decision).toChoose = item;

						}
						else
						{
							player.decision = new Players.GeneralPlayer();
						}
					}
					Console.WriteLine("in lpp");

					var preservedIterator = ParseEngine.currentIterator;
					var cloneContext = ParseEngine.currentIterator.Clone();
					ParseEngine.currentIterator = cloneContext;
					while (!cloneContext.AdvanceToChoice())
					{
                        // caught here for sure
						cloneContext.ProcessChoice();
					}
					// TODO make sure changes to processscore didn't screw this up
					// figure this chunk out 
					Console.WriteLine("in lpp");

					var winners = ScoreIterator.ProcessScore(ParseEngine.currentTree.scoring());
                    Console.WriteLine("past processscore");
					total[item] = winners.Count;
					numTotal++;

					for (int j = 0; j < winners.Count; ++j)
					{
                        // if player is player 0 (me)
						if (winners[j].Item2 == idx)
						{
                            // add your rank to the results of this choice
							results[item] += j;
							int div = winners.Count - j;
                            // adds a smaller number to numWon as 
                            // you come ahead of more players 
							double lead = ((double)1) / div;
							numWon += lead;
							break;
						}
					}
					Console.WriteLine("in lpp");

					ParseEngine.currentIterator = preservedIterator;
				}
				wrs[item] = (double)numWon / numTotal;
			}
			Debug.WriteLine("End Monte");
			//Debug.WriteLine ("***Switch Back***");
			CardGame.Instance = CardGame.preserved;
			Console.WriteLine("resetting game state");

			var typeOfGame = ParseEngine.currentTree.scoring().GetChild(2).GetText();
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
				Scorer.gameWorld.Lead(CardGame.Instance.currentPlayer.Peek().idx).Add(max);

			}
			if (typeOfGame == "min")
			{
				return tup.Item1;
			}
			else
			{
				return tup.Item2;
			}
        }

        public LessThanPerfectPlayer()
        {
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