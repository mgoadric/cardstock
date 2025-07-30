using System;

namespace CardStock.Scoring.Heuristics
{
    public abstract class Heuristic{
        public double Eval(World w)
        {
            var val = Get(w) * Weight();
            if (double.IsNaN(val)) { val = 0; }
            foreach (double d in Others()){
                if (!double.IsNaN(d)) { val += d; }
            }
            return val;
        }

        public abstract double Weight();
        public abstract double Get(World w);
        public virtual double[] Others() { return Array.Empty<double>(); }
    }
}

