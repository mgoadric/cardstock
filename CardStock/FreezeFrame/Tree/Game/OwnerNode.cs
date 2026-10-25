using CardStock.CardEngine;

namespace CardStock.FreezeFrame.Tree.Game;

public interface OwnerNode<out T> : IGameNode where T : Owner
{
    Owner GetWho(GameContext context);
}