using System;
using System.Collections.Generic;

namespace CardStock.Scoring
{
    public class World
    { // a world contains all pertinent information for heuristics
        public bool testing = false;

        public bool compiling = true;
        public bool hasShuffle = false;
        public bool hasChoice = false;
        public int numAIvsRnd = 0;
        public int numGames;
        public int numAIvsAI = 0;
        public double numAIWins;
        public int numPlayers;
        //parseengine 208
        public int wins;
        public double numFirstWins;
        public int numTies;

        private object thisLock = new object();

        //lessthanperfectplayers 82
        public List<double> variance = []; // difference between worst move and best move
        //could record individual values instead
        public List<double> moveScores = []; // raw movescores in order
        //lessthanperfectplayers 33-76
        public List<double> deepness = []; // difference between shallow eval and deep eval
        //currently lessthanperfect runs with deepness of 1

        //is this even reasonable? probably not
        public int numRules;

        //public List<List<double>>[] lead = new List<List<double>>[numPlayers]();
        public int[] winners;
        public List<List<double>>[] lead;

        public List<List<double>>[] AIvAI;
        public List<List<double>>[] AIvRnd;
        public List<double> average = []; //average move score

        public List<int> numTurns = [];

        public void AddNumTurns(int i)
        {
            lock (thisLock)
            {
                numTurns.Add(i);
            }

        }

        public void AddInfo(double vari, double avg, double mS){
            lock (thisLock) {
                variance.Add(vari);
                average.Add(avg);
                moveScores.Add(mS);
            }
        }


        public void SetRndVsAI(List<List<double>>[] l) {
            AIvRnd = l;
        }

        public void SetAIVsAI(List<List<double>>[] l) {
            AIvAI = l;
        }

        public void SetWinners(int[] w) {
            winners = w;
        }
    }
}
