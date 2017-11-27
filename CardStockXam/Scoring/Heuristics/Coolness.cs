using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CardStockXam.Scoring.Heuristics
{
    class Coolness : Heuristic
    {
        public override double Get(World w)
        {
            // returns proportion of num times
            // move score decreased in subsequent moves

            // captures 'coolness' - measure of degree to which
            // players are forced to make moves that harm their position
            if (w.numAIvsAI == 0) {
                return 0;
            }
            int diff = 0;
            int total = 0;
            // for each game
			for (int i = 0; i < w.winners.Length; i++)
			{
                // for each player
				for (int j = 0; j < w.AIvAI[i].Count; j++)
				{
					// for each move
					for (int x = 0; x < w.AIvAI[i][j].Count - 1; x++)
					{
                        total += 1;
                        if (w.AIvAI[i][j][x] > w.AIvAI[i][j][x + 1]){
                            diff += 1;
                        }
						
					}
					//Console.Write("\n");


				}
			}
			// threshold so that approaches 1 as diff/total approaches .5 & approaches 0 as diff/total approaches 0 or 1
			double threshold = .5;
            double result = (double)diff / total;
            double slope;
            double score;
            
            if (result <= threshold) {
                slope = (double)(1.0 / threshold);
                score = slope * result;
            } else {
                slope = (double)(0 - 1) / (1 - threshold);
                score = (slope * result) - slope;
            }
            return score;
			
			

        }

        public override double Weight()
        {
            return 0.5;
        }
    }
}
