using CardStock.FreezeFrame.Tree;

namespace CardStock.FreezeFrame.Actions;

public interface ExecutableActionNode : IGameNode
{
    void Execute(GameContext context);
}