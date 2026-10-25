using CardStock.CardEngine;

namespace CardStock.FreezeFrame.Tree.Cards;

public interface CardNode : IGameNode
{
    Card GetCard(GameContext context);
}