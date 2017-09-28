using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CardStockXam.Scoring.Heuristics
{
    class Randomness : Heuristic
    {
        public override double Get(World w)
        {
            return 0;
        }

        public override double Weight()
        {
            return 0.5;
        }
    }
}
