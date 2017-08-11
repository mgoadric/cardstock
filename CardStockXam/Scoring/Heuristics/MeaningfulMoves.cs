using System;

namespace CardStockXam.Scoring.Heuristics
{
    class MeaningfulMoves : Heuristic{

        public override double Weight(){
            return 0.5;
        }
        // expect AI to win 100% of time, just calculate how much out of 100 they won
        public override double Get(World w){
            if (w.numAIvsRnd == 0) {
                return 0;
            } else {
                return (double) w.numAIWins / w.numAIvsRnd;
            }

        }
    }
}
