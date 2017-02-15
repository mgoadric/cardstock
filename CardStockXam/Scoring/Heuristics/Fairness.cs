using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardStockXam.Scoring.Heuristics
{
    class Fairness : Heuristic
    {
        public override double Get(World w)
        {
            int diff = Math.Abs(w.numFirstWins - w.numGames);
            return 1 - (diff * 2 / w.numGames);
        }

        public override double Weight()
        {
            return 0.5;
        }
    }
}
