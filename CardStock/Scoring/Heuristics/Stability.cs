using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CardStock.Scoring.Heuristics
{
    class Stability : Heuristic
    {
        public override double Get(World w)
        {
            // returns the degree to which relative player
            // ranks remain stable
            Console.WriteLine("Testing Stability");
			if (w.numAIvsAI == 0)
			{
				return 0;
			}
            int diff = 0;
            int total = 0;
            // get list of player ranks for each move
            List<double[]> rankings = [];
            // for each game
			for (int i = 0; i < w.winners.Length; i++)
			{
                // for num moves player 0 made in game
                for (int j = 0; j < w.AIvAI[i][0].Count; j++) {
                    List<double[]> l = [];

					// for each player
					for (int x = 0; x < w.AIvAI[i].Count; x++) {
                        // item = [movescore, player number]
                        double[] item = { w.AIvAI[i][x][j], (double)x };
                        l.Add(item);
                    }
                    // sort ranking by move score 
                    l.Sort((x,y) => x[0].CompareTo(y[0]));
                    double[] rank = new double[w.AIvAI[i].Count];
                    for (int r = 0; r < l.Count; r++) {
                        rank[r] = l[r][1];
                    }
                    rankings.Add(rank);
                }
            }
            Console.WriteLine("Calculations Complete");

            for (int i = 0; i < rankings.Count - 1; i++)
            {
                for (int j = 0; j < rankings[i].Length; j++)
                {
                    total += 1;
                    if (rankings[i][j] != rankings[i + 1][j])
                    {
                        diff += 1;
                    }
                }
            }
            // needs to return this on a bell curve where 
            // if diff / total = .5 return 1 and as approaches
            // either end return 0
            Console.WriteLine("Total in Stability is " + total);
            return 1 - ((double)diff / total);


        }

        public override double Weight()
        {
            return 0.5;
        }
    }
}
