using System;
using System.Collections.Generic;
using CardStock.Players;

namespace CardStock.Players
{
    public enum PlayerType
    {
        RANDOM, PIPMC, MCTS, ISMCTS, PIPMCNEW, ONESECMCTS
    }

    public static class Extensions
{
        public static AIPlayer AI(this PlayerType type, Perspective perspective) {
            switch (type)
            {
                case PlayerType.RANDOM:
                    return new RandomPlayer(perspective);
                case PlayerType.PIPMC:
                    return new PIPMCPlayer(perspective);
                case PlayerType.MCTS:
                    return new MCTSPLayer(perspective);
                case PlayerType.ISMCTS:
                    return new ISMCTSPlayer(perspective);
                case PlayerType.PIPMCNEW:
                    return new PIPMCPlayerNew(perspective);
                case PlayerType.ONESECMCTS:
                    return new OneSecondMCTS(perspective);
                default:
                    return new RandomPlayer(perspective);
            }
        }
       
}
}