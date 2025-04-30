using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CardStock.Scoring.Heuristics
{
    class Depth : Heuristic
    {
        public override double Get(World w)
        {
            if (w.deepness.Count == 0) { return 0; }
            double tot = 0.0;
            if (w.testing) { Debug.WriteLine("Start depth"); }
            foreach (double d in w.deepness) {
                if (w.testing) { Debug.WriteLine(d); }
                tot += d;
            }
            if (w.testing) { Debug.WriteLine("End depth"); }
            return tot / w.deepness.Count;
        }

        public override double Weight()
        {
            return 0.5;
        }
    }
}
