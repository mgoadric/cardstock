using System;
using System.Diagnostics;
using System.Linq;
namespace CardStock.Scoring.Heuristics
{
    class GameLength : Heuristic
    {
        // Anna should fix this 
        int minLength = 5; //TODO
        int maxLength = 100; //TODO, idk what right number is
        int divisor = 25; //TODO this either

        // if you figure out complexity,
        // you can figure out how long a game should be and then 
        // determine if it is too long/short
        // use the formula in the phd paper 

        public override double Get(World w)
        {
            Debug.WriteLine("Num turns: " + w.numTurns);
            int sum = w.numTurns.Sum();
            double avg = sum / w.numGames;

            return 1.0 - ((minLength - sum) / minLength);
        }

        public override double Weight()
        {
            return 0.2;
        }
    }
}
