using CardStock.FreezeFrame.Actions;

namespace CardStock.FreezeFrame.Tree.Actions;

public class MultiActionNode : ExecutableActionNode
{
    private readonly IList<ExecutableActionNode> _nodes;

    public MultiActionNode(IList<ExecutableActionNode> nodes)
    {
        _nodes = nodes;
    }

    public void Execute(GameContext context)
    {
        foreach (ExecutableActionNode node in _nodes)
        {
            node.Execute(context);
        }
    }
}