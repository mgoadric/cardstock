﻿using System;
using System.Collections.Generic;
using CardEngine;
using CardStockXam.Scoring;
using FreezeFrame;

namespace Players
{
    /********
     * An abstract class to be subclassed for all of the AIPlayers. It will 
     * know the number of players in the game, have a Perspective which
     * privatizes the hidden aspects of the game from this player, and 
     * a List that can track the player's estimates of their current
     * game position
     */
	public abstract class AIPlayer 
	{
        protected int numPlayers;
        protected Perspective perspective;
        protected List<double> leadList = new List<double>();

        public AIPlayer(Perspective perspective)
        {
            this.perspective = perspective;
            numPlayers = perspective.NumberOfPlayers();
        }

        /********
         * This is the critical method that needs to be overridden in any subclass
         * of AIPlayer. When a choice is found in the game, the number of potential 
         * GameActions will be passed in. The AIPlayer
         * is expected to return an int which is the index of their chosen move.
         */
        public abstract int MakeAction(int numChoices);

        public static Tuple<int, int> MinMaxIdx(double[] input)
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
            return new Tuple<int, int>(minIdx, maxIdx);
        }

        // CODE FOR UPDATING STATISTICS FOR HEURISTICS
        public void RecordHeuristics(double[][] rankSums) 
        {
            if (perspective.GetWorld() != null)
            {
                double[] rankSum = rankSums[perspective.GetIdx()];
                double[] myLeadView = new double[rankSums.Length];

                // WHAT DOES WRS stand for?
                double[] wrs = new double[rankSum.Length];

                for (int item = 0; item < rankSum.Length; ++item)
                {
                    wrs[item] = ((numPlayers - 1) - rankSum[item]) /
                        (numPlayers - 1);
                }

                (var minidx, var maxidx) = MinMaxIdx(rankSum);
                var best = wrs[minidx];
                var worst = wrs[maxidx];

                double avg = 0;
                for (int i = 0; i < wrs.Length; i++)
                {
                    avg += wrs[i];
                }
                avg /= (double)wrs.Length;

                var variance = Math.Abs(best - worst);

                perspective.GetWorld().AddInfo(variance, avg, wrs[minidx]);
                for (int i = 0; i < myLeadView.Length; i++) {
                    myLeadView[i] = ((numPlayers - 1) - rankSums[i][minidx]) /
                        (numPlayers - 1);
                    //Console.WriteLine("Converted " + rankSums[i][maxidx] + " into " + myLeadView[i]);
                }
                perspective.AddLeadsList(new Tuple<int, double[]>(perspective.GetIdx(), myLeadView));
                perspective.AddSpreadList(new Tuple<int, double>(perspective.GetIdx(), variance));

                leadList.Add(best);
            }
        }

        public virtual List<double> GetLead()
        {
            return leadList;
        }

	}
}

