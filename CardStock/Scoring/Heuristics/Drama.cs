﻿using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CardStock.Scoring.Heuristics
{
    class Drama : Heuristic
    {

        private float threshold = 0.5f;
        // TODO check this out  SHOULD THIS BE BASED ON NUMBER OF PLAYERS?
        // RIGHT NOW BASED ON BEING IN TOP HALF
        // DOES NOT WORK FOR GAMES WITH ONE WINNER, ELSE IN SECOND LIKE AGRAM

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
            for (int i = 0; i < w.winners.Length; i++)
            {
                for (int j = 0; j < w.AIvAI[i][w.winners[i]].Count; j++)
                {
                    if (w.AIvAI[i][w.winners[i]][j] < threshold)
                    {
                        difference += (Math.Sqrt(threshold - w.AIvAI[i][w.winners[i]][j]));
                        total += 1;
                    }
                }
            }
            Debug.WriteLine("diff: " + difference);
            return (double)difference / total;
        }
            /*

			// todo difficult to balance drama & decisiveness 
			// should evaluate the degree to which the
			// winner of each game suffers a negative lead:

            // use formula from 109
            double tot = 0;
            int numEvaluated = 0;
            for (int i = 0; i < w.leadP1.Count; i++){
                double innerTot = 0;
                int count = 0;
                int idx = 0;
                int idy = 0;
                if (i >= w.winners.Count) { break; }
                // list of bools, true if p1 won false if p2 won
                bool winner = w.winners[i];
                bool unbroken = true;
                var curP1 = w.leadP1[i];
                var curP2 = w.leadP2[i];//TODO, only ai has
                while (unbroken){
                    if (idx >= curP1.Count || idy >= curP2.Count) { break; }
                    double v1 = curP1[idx];
                    double v2 = curP2[idy];
                    if (winner){
                        if (v1 < v2) { innerTot += v2 - v1; count++; }
                    }
                    else{
                        if (v2 < v1) { innerTot += v1 - v2; count++; }
                    }
                    idx++;
                    idy++;
                }
                if (count > 0){
                    tot += innerTot / count;
                    numEvaluated++;
                }
            }
            if (numEvaluated == 0){
                Debug.WriteLine("nothing evaluated");
                return 0.0;
            }
            return tot / numEvaluated * 4;*/
    

    public override double Weight()
        {
            return 0.25;
        }

    }
}
