using System;

namespace CardStockXam.Scoring.Heuristics
{
    class Variance : Heuristic{

        public override double weight()
        {
            return 0.5;
        }

        public override double get(World w){//TODO
            foreach (double d in w.variance){
                
            }
            return 0.0;
        }
    }
}
