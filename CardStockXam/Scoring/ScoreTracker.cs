using System;
using System.Collections.Generic;
namespace CardStockXam.Scoring
{
    public class ScoreTracker
    {
        
        public List<List<int[]>> moveRanks;

        public void Fill(int numGames, int numPlayers) {
            moveRanks = new List<List<int[]>>();
            for (int i = 0; i < numGames; i++) {
                moveRanks.Add(new List<int[]>());
            }

        }


        // store all players ranks at all taken moves 

        public void StoreRanks(List<double> scores, int game)
        {
            List<double> copy = new List<double>();
            copy.AddRange(scores);
            scores.Sort();
            int[] ranks = new int[scores.Count];
            for (int i = 0; i < scores.Count; i++) {
                ranks[i] = copy.IndexOf(scores[i]);
            }
            moveRanks[game].Add(ranks);
        }

        // return ranks for each move of a player in a game 
        public int[] GetPlayerRanks(int game, int playerIdx) 
        {
            return moveRanks[game][playerIdx];

        }

        public List<int[]> GetAllRanks(int game) {
            return moveRanks[game];
        }
    }
}
