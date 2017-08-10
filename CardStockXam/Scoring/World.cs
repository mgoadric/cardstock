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
        public int numPlayers;
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

        public List<List<double>> leadP1 = new List<List<double>>();
        public List<List<double>> leadP2 = new List<List<double>>();
        public List<bool> winners = new List<bool>();

        public double numTurns;

        //Heuristics to implement, but how?
            //interactivity
            //clarity

        public World(){
            leadP1.Add(new List<double>());
            leadP2.Add(new List<double>());
        }

        public void GameOver(int winner){
            leadP1.Add(new List<double>());
            leadP2.Add(new List<double>());
            winners.Add(winner == 0 ? true : false);
        }

        public void EvalOver(){
            if (leadP1[leadP1.Count - 1].Count == 0) { leadP1.RemoveAt(leadP1.Count - 1); }
            if (leadP2[leadP2.Count - 1].Count == 0) { leadP2.RemoveAt(leadP2.Count - 1); }
        }
        public List<double> Lead(int idx){
            var l = idx == 0 ? leadP1 : leadP2;
            return l[l.Count - 1]; }
    }
}
