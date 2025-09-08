using System;
using System.Linq;

namespace CardStockXam.Scoring.Heuristics
{
    class MeaningfulMoves : Heuristic{

        public override double Weight(){
            return 0.5;
        }

        // w.variance is a list of the difference between
        // the highest and lowest scored moves for each AI 
        // player (in a random order)


      
        public override double Get(World w)
        {
            return ((double)w.variance.Sum() / w.variance.Count);

        }
    }
}
