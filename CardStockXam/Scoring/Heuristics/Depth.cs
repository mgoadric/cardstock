using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardStockXam.Scoring.Heuristics
{
    class Depth : Heuristic
    {
        public override double Get(World w)
        {
            if (w.deepness.Count == 0) { return 0; }
            double tot = 0.0;
            foreach (double d in w.deepness){
                tot += d;
            }
            return tot / w.deepness.Count;
        }

        public override double Weight()
        {
            return 0.5;
        }
    }
}
