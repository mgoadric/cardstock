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
                if (Math.Abs(w.moveScores[i] - w.average[i]) >= .4) {
                    diff += 1;
                }
                total += 1;
            }

			

			// threshold so that approaches 1 as diff/total approaches .5 & approaches 0 as diff/total approaches 0 or 1
			double threshold = .5;
			double result = (double)diff / total;
			double slope;
			double score;

			if (result <= threshold)
			{
				slope = (double)(1.0 / threshold);
				score = slope * result;
			}
			else
			{
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
