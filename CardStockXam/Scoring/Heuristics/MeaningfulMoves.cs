using System;

namespace CardStockXam.Scoring.Heuristics
{
    class MeaningfulMoves : Heuristic{

        public override double Weight()
        {
            return 0.5;
        }

        public override double Get(World w){

            return w.numAIWins / (w.numRndWins + w.numAIWins);
        }
    }
}
