using System;

namespace CardStockXam.Scoring.Heuristics
{
    class Variance : Heuristic{
        private double killerMove = 0.0;//maximum difference in scores
        private double killerWeight = 0.2;

        public override double Weight()
        {
            return 0.5;
        }

        public override double Get(World w){
            var total = 0.0;
            Console.WriteLine("Start variance");
            foreach (double d in w.variance){
                Console.WriteLine(d);
                total += d;
                killerMove = Math.Max(killerMove, d);
            }
            Console.WriteLine("End variance");
            return total / w.variance.Count;
        }

        public override double[] Others(){
            return new double[] {killerMove * killerWeight};
        }
    }
}
