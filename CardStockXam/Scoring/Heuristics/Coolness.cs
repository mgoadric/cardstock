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
			// needs to return this where 
			// if diff / total = .5 return 1 and as approaches
			// either end return 0
			return 1 - ((double)diff / total);


        }

        public override double Weight()
        {
            return 0.5;
        }
    }
}
