using CardStock.FreezeFrame.Actions;

namespace CardStock.FreezeFrame.Tree.Actions;

public interface ActionSupplierNode : IGameNode
{
    GameAction GetAction(GameContext context);
}