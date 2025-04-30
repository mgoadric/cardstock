﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardStock.Scoring.Heuristics
{
    class ExcessRules : Heuristic
    {
        // could measure number of turns vs amount of time it takes per turn to measure complexity in some way 
        int maxRules = 100; //TODO, idk what right number is
        int divisor = 25; //TODO this either

        public override double Get(World w)
        {
            int excessRules = w.numRules - maxRules;
            if (excessRules > 0) { return Math.Max(1.0 - (excessRules / divisor), 0);}
            return 1.0;
        }

        public override double Weight()
        {
            return 0.2;
        }
    }
}
