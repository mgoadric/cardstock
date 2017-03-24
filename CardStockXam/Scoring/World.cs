using System;
using System.Collections.Generic;

namespace CardStockXam.Scoring
{
    public class World{ // a world contains all pertinent information for heuristics
        public bool testing = false;

        public bool compiling = true;
        public bool hasShuffle = false;
        public bool hasChoice = false;

        public int numGames;

        public int numAIWins;
        public int numRndWins;

        //parseengine 208
        public int wins;
        public int numFirstWins;
        public int numTies;

        //lessthanperfectplayers 82
        public List<double> variance = new List<double>(); // difference between worst move and best move
        //could record individual values instead

        //lessthanperfectplayers 33-76
        public List<double> deepness = new List<double>(); // difference between shallow eval and deep eval
        //currently lessthanperfect runs with deepness of 1

        //is this even reasonable? probably not
        public int numRules;

        public double numTurns;

        //Heuristics to implement, but how?
            //interactivity
            //clarity

        public World() { }

        public void GameEnds() { } //TODO cleanup for next game

    }
}
