using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardStock.Scoring.Heuristics
{
    class Reasonable : Heuristic //criteria that must be true for games
    {
        
        public override double Get(World w)
        {
            if (w.compiling && w.hasShuffle && w.hasChoice){
                return 1.0;
            }
            return 0.0;
        }

        public override double Weight()
        {
            return 1;
        }
    }
}
