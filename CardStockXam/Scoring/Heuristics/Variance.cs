using System;

namespace CardStockXam.Scoring.Heuristics
{
    class Variance : Heuristic{
        private double killerMove = 0.0;//maximum difference in scores
        private double killerWeight = 0.2;

        public override double Weight()
        {
            return 0.85;
        }

        public override double Get(World w) {
            double total = 0.0;
            foreach (double d in w.variance) {
                total += d;
                killerMove = Math.Max(killerMove, d);
            }
            return total / w.variance.Count;
        }

        public override double[] Others(){
            return new double[] {killerMove * killerWeight};
        }
    }
}
