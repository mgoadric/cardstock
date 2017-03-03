using System;

namespace CardStockXam.Scoring
{
    public abstract class Heuristic{
        public double Eval(World w)
        {
            var val = Get(w) * Weight();
            foreach (double d in Others()){
                val += d;
            }
            return val;
        }

        public abstract double Weight();
        public abstract double Get(World w);
        public virtual double[] Others() { return new double[0]; }
    }
}
