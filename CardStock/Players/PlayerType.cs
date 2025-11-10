using System;
using System.Collections.Generic;
using CardStock.Evaluation;
using CardStock.Players;

namespace CardStock.Players
{
    public enum PlayerType
    {
        RANDOM, PIPMC, MCTS, ISMCTS, PIPMCOLD, ONESECMCTS, NONE
    }

    public static class Extensions
{
        public static AIPlayer AI(this PlayerType type, Perspective perspective, DataCollector dc) {
            return type switch
            {
                PlayerType.RANDOM => new RandomPlayer(perspective, dc),
                PlayerType.PIPMC => new PIPMCPlayer(perspective, dc),
                PlayerType.MCTS => new MCTSPLayer(perspective, dc),
                PlayerType.ISMCTS => new ISMCTSPlayer(perspective, dc),
                PlayerType.PIPMCOLD => new PIPMCPlayerOld(perspective, dc),
                PlayerType.ONESECMCTS => new OneSecondMCTS(perspective, dc),
                _ => new RandomPlayer(perspective, dc),
            };
        }
       
}
}