using System;
using System.Collections.Generic;
using CardStock.Players;

namespace CardStock.Players
{
    public enum PlayerType
    {
        RANDOM, PIPMC, MCTS, ISMCTS, PIPMCOLD, ONESECMCTS
    }

    public static class Extensions
{
        public static AIPlayer AI(this PlayerType type, Perspective perspective) {
            return type switch
            {
                PlayerType.RANDOM => new RandomPlayer(perspective),
                PlayerType.PIPMC => new PIPMCPlayer(perspective),
                PlayerType.MCTS => new MCTSPLayer(perspective),
                PlayerType.ISMCTS => new ISMCTSPlayer(perspective),
                PlayerType.PIPMCOLD => new PIPMCPlayerOld(perspective),
                PlayerType.ONESECMCTS => new OneSecondMCTS(perspective),
                _ => new RandomPlayer(perspective),
            };
        }
       
}
}