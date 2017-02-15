using System;

namespace CardStockXam.Scoring.Heuristics
{
    class GameLength : Heuristic
    {
        int minLength = 5; //TODO
        int maxLength = 100; //TODO, idk what right number is
        int divisor = 25; //TODO this either

        public override double Get(World w)
        {
            if (w.numTurns > minLength){
                if (w.numTurns > maxLength){
                    return Math.Max(1.0 - ((w.numTurns - maxLength) / divisor), 0);
                }
                return 1.0;
            }
            return 1.0 - ((minLength - w.numTurns) / minLength);
        }

        public override double Weight()
        {
            return 0.2;
        }
    }
}
