using System;

namespace CardStockXam.Scoring
{
    public class World{ // a world contains all pertinent information for heuristics
        public int numGames;

        public bool hasShuffle;
        public bool hasChoice;
        public bool hasWinner;

        public int numAIWins;
        public int numRndWins;

        public int numFirstWins;

        public double[] variance; // difference between worst move and best move

        public double[] deepness; // difference between shallow eval and deep eval

        public int numRules;

        public int numTies;

        public double numTurns;

        //Heuristics to implement, but how?
            //interactivity
            //clarity

        public World() { }

    }
}
