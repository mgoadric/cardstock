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
            Console.WriteLine("Num turns: " + w.numTurns);
            if (w.numTurns > minLength){
                if (w.numTurns > maxLength){
                    var ret = 1.0 - ((w.numTurns - maxLength) / divisor);
                    Console.WriteLine("returning " + ret + " from gamelength");
                    return Math.Max(ret, 0);
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
