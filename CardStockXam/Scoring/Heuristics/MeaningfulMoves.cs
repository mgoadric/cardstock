using System;

namespace CardStockXam.Scoring.Heuristics
{
    class MeaningfulMoves : Heuristic{

        public override double weight()
        {
            return 0.5;
        }

        public override double get(World w){
            return w.numAIWins / w.numRndWins;
        }
    }
}
