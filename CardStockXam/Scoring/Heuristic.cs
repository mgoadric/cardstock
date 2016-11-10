using System;

namespace CardStockXam.Scoring
{
    public abstract class Heuristic{
        public double eval(World w)
        {
            return get(w) * weight();
        }

        public abstract double weight();
        public abstract double get(World w);
    }
}
