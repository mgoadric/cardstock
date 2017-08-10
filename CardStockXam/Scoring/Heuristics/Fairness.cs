using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardStockXam.Scoring.Heuristics
{
    class Fairness : Heuristic
    {
        // TODO divide by zero error here 
        public override double Get(World w)
        {
            
            int diff = Math.Abs(w.numFirstWins - w.numGames);
            if (w.numGames == 0)
            {
                Console.WriteLine("0 Games in fairness heuristic");
                return 0;
            }
            else
            {
                return 1 - (diff * 2 / w.numGames);
            }
        }

        public override double Weight()
        {
            return 0.5;
        }
    }
}
