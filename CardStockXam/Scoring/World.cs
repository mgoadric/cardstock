using System;
using System.Collections.Generic;

namespace CardStockXam.Scoring
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
        public int numAIWins;
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

        //public List<List<double>>[] lead = new List<List<double>>[numPlayers]();
        public List<int> winners = new List<int>();
        public List<List<double>>[] lead;


        public double numTurns;

        //Heuristics to implement, but how?
        //interactivity
        //clarity

        public void PopulateLead()
        {
            if (lead == null)
            {
                lead = new List<List<double>>[numPlayers];
                for (int i = 0; i < lead.Length; i++)
                {
                    lead[i] = new List<List<double>>();
                    lead[i].Add(new List<double>());
                }
            }

        }



        public void GameOver(int winner)
        {
            winners.Add(winner);
            // getting ready for next game! i promise this makes sense 
            for (int i = 0; i < lead.Length; i++)
            {
                lead[i].Add(new List<double>());
            }

        }



        public void EvalOver()
        {
            // getting rid of one extra lead lists 
            for (int i = 0; i < lead.Length; i++)
            {
                if (lead[i][lead[i].Count - 1].Count == 0)
                {
                    lead[i].RemoveAt(lead[i].Count - 1);
                }
            }

        }
        public void Lead(int idx, double score)
        {
            lead[idx][lead[idx].Count - 1].Add(score);

        }
    }
}
