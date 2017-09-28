using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CardStockXam.Scoring.Heuristics
{
    class Clarity : Heuristic
    {
        // degree to which correct choice is obvious - too low is confusing,
        // too high is boring

        // find degree to which chosen move's score deviates from 
        // average of all potential moves' scores
        public override double Get(World w)
        {
            double diff = 0;
            double total = 0;
            for (int i = 0; i < w.moveScores.Count; i++) {
                if (w.moveScores[i] - w.average[i] >= .3) {
                    diff += 1;
                }
                total += 1;
            }

            return 1 - ((double)diff / total);

        }

        public override double Weight()
        {
            return 0.5;
        }
    }
}
