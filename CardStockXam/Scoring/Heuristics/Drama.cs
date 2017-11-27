using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CardStockXam.Scoring.Heuristics
{
    class Drama : Heuristic
    {
		/* threshold is .5
        * if the winner's choices never drop below .5, drama should be 0
        * otherwise, use function in phd paper to find drama */

		public override double Get(World w)

        {
            double difference = 0;
            double total = 0;
            if (w.numAIvsAI == 0) {
                return 0;
            }
            for (int i = 0; i < w.winners.Length; i++) {
                for (int j = 0; j < w.AIvAI[i][w.winners[i]].Count; j++)
                {
                    if (w.AIvAI[i][w.winners[i]][j] < .5) {
                        difference += (Math.Sqrt(.5 - w.AIvAI[i][w.winners[i]][j]));
                        total += 1;
                    }
                }
            }
            Debug.WriteLine("diff: " + difference);
            return (double)difference / total;
        }
    

    public override double Weight()
        {
            return 0.25;
        }

    }
}
