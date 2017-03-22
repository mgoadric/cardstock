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

        public LessThanPerfectPlayer()
        {
        }
        public override int MakeAction(List<GameActionCollection> possibles, Random rand)
        {

            return rand.Next(0, possibles.Count);
        }
        public override int MakeAction(JObject possibles, Random rand)
        {
            var items = (JArray)possibles["items"];
            if (items.Count == 1)
            {
                return 0;
            }
            CardEngine.CardGame.preserved = CardEngine.CardGame.Instance;


            var results = new int[items.Count];
            Debug.WriteLine("Start Monte");
            for (int item = 0; item < items.Count; ++item)
            {
                results[item] = 0;
                for (int i = 0; i < numTests; ++i)//number of tests for certain decision
                {
                    Debug.WriteLine("****Made Switch****");

                    CardEngine.CardGame.Instance = CardEngine.CardGame.preserved.CloneSecret(0);//What is this??

                    var flag = true;
                    foreach (var player in CardEngine.CardGame.Instance.players)
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
                    var preservedIterator = ParseEngine.currentIterator;
                    var cloneContext = ParseEngine.currentIterator.Clone();
                    ParseEngine.currentIterator = cloneContext;
                    while (!cloneContext.AdvanceToChoice()){
                        cloneContext.ProcessChoice();
                    }
                    var winners = ScoreIterator.ProcessScore(ParseEngine.currentTree.scoring());
                    for (int j = 0; j < winners.Count; ++j)
                    {
                        if (winners[j].Item2 == 0)
                        {
                            results[item] += j;
                        }
                    }

                    ParseEngine.currentIterator = preservedIterator;
                }

            }
            Debug.WriteLine("End Monte");
            //Debug.WriteLine ("***Switch Back***");
            CardGame.Instance = CardGame.preserved;
            var typeOfGame = ParseEngine.currentTree.scoring().GetChild(2).GetText();
            var tup = MinMaxIdx(results);
            if (Scorer.gameWorld != null) {
                var variance = Math.Abs(tup.Item2 - tup.Item1);
                Scorer.gameWorld.variance.Add(variance);
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