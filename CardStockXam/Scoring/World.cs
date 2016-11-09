using System;

namespace CardStockXam.Scoring
{
    public class World{ // a world contains all pertinent information for heuristics
        public int numAIWins;
        public int numRndWins;
        public double[] variance;
        public World() { }

    }
}
