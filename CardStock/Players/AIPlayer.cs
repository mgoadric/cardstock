﻿using System.Diagnostics;
using System.Runtime.CompilerServices;
using CardStock.Evaluation;

namespace CardStock.Players
{
    /********
     * An abstract class to be subclassed for all of the AIPlayers. It will 
     * know the number of players in the game, have a Perspective which
     * privatizes the hidden aspects of the game from this player, and 
     * a List that can track the player's estimates of their current
     * game position
     */
	public abstract class AIPlayer(Perspective perspective, DataCollector dc)
    {
        // SHOULD WE ABSTRACT EVEN MORE, A PLAYER vs AN AI PLAYER, SO WE CAN HAVE RANDOM, OR HUMAN, NOT AI???
        protected int numPlayers = perspective.NumberOfPlayers();
        protected Perspective perspective = perspective;
        protected Stopwatch stopwatch = new();
        public DataCollector dc = dc;

        public int numChoices;

        /********
         * These are the critical method that needs to be overridden in any subclass
         * of AIPlayer. When a choice is found in the game, the number of potential 
         * GameActions will be passed in to Explore. This method could be stopped early
         * based on a time budget.
         */
        public abstract void Explore();

        public void ExploreOptions()
        {
            if (dc is not null)
            {
                // https://stackoverflow.com/questions/16376191/measuring-code-execution-time-in-this-code
                stopwatch.Restart();
                Explore();
                stopwatch.Stop();
                dc.AddTime(stopwatch.ElapsedMilliseconds);
                //Console.WriteLine("Time: " + stopwatch.ElapsedMilliseconds);
            }
            else
            {
                Explore();
            }
        }

        /*********
        * For Choose, The AIPlayer
        * is expected to return an int which is the index of their chosen move.
        */
        public int Choose()
        {
            int choice = ChooseOption();
            dc?.AddChoices(new Tuple<int, int, int>(perspective.GetIdx(), numChoices, choice));
            return choice;
        }

        public abstract int ChooseOption();

        public static (int min, int max) MinMaxIdx(double[] input)
        {
            double min = double.MaxValue;
            double max = double.MinValue;
            int minIdx = -1;
            int maxIdx = -1;
            for (int i = 0; i < input.Length; ++i)
            {
                if (input[i] > max)
                {
                    max = input[i];
                    maxIdx = i;
                }
                if (input[i] < min)
                {
                    min = input[i];
                    minIdx = i;
                }
            }
            return (minIdx, maxIdx);
        }

        public static double Normalize(double value, double min, double max)
        {
            return (value - min) / (max - min);
        }
	}
}

