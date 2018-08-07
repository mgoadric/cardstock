﻿using CardEngine;
using FreezeFrame;
using Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardStockXam.Players
{
    public class PIPMCPlayer : AIPlayer
    {
        private static int NUMTESTS = 10; //previously 20

        public PIPMCPlayer(Perspective perspective) : base(perspective) { }

        public override int MakeAction(int numMoves)
        {

            var inverseRankSum = new double[numMoves];

            // can parallellize here TODO ?
            // FOR EACH POSSIBLE MOVE


            for (int move = 0; move < numMoves; ++move)
            {
                inverseRankSum[move] = 0;

                Parallel.For(0, NUMTESTS, i =>   //number of tests for certain decision
                {
                    // USE A SEPERATE CLONESECRET FOR EACH GAME
                    (CardGame cg, GameIterator cloneContext) = perspective.GetPrivateGame();

                    // Make the chosen move
                    List<GameActionCollection> allOptions = cloneContext.BuildOptions();
                    allOptions[move].ExecuteAll();
                    cloneContext.PopCurrentNode();

                    // Assign the AI players for rollout game, with the 
                    // selected item chosen first when you get your turn
                    for (int j = 0; j < numPlayers; j++)
                    {
                        cg.players[j].decision = new RandomPlayer(perspective);
                    }

                    while (!cloneContext.AdvanceToChoice())
                    {
                        cloneContext.ProcessChoice();
                    }

                    // ProcessScore returns a sorted list 
                    // where the winner is rank 0 for either min/max games.
                    var winners = cloneContext.ProcessScore();

                    // TODO record everyone's ranks at all potential moves 
                    // so can give to scoretracker ??
                    for (int j = 0; j < numPlayers; ++j)
                    {
                        // if player is me
                        if (winners[j].Item2 == perspective.GetIdx())
                        {

                            // add your rank to the results of this choice
                            lock (this)
                            {
                                inverseRankSum[move] += (((double)1) / (j + 1)) / NUMTESTS;
                            }

                            break;
                        }
                    }

                });
            }

            // FIND BEST (and worst) MOVE TO MAKE
            var tup = MinMaxIdx(inverseRankSum);

            // Record info for heuristic evaluation
            RecordHeuristics(inverseRankSum);

            return tup.Item2;
        }
    }
}
