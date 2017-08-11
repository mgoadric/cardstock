using System;
using System.Diagnostics;

namespace CardStockXam.Scoring.Heuristics
{
    class Drama : Heuristic
    {


        // TODO check this out 


        /* threshold is .5
        * if the winner's choices never drop below .5, drama should be 0
        * otherwise, use function in phd paper to find drama */

        public override double Get(World w)

        {
            return 0;
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
