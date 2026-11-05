using CardStock.FreezeFrame.Tree;
using CardStock.FreezeFrame.Tree.Booleans;

namespace CardStock.FreezeFrame.Actions.Conditional;

public class ConditionalExecutableNode : ExecutableActionNode
{
    private readonly BooleanNode _conditional;
    private readonly ExecutableActionNode _node;

    public void Execute(GameContext context)
    {
        if (_conditional.GetBoolean())
        {
            _node.Execute(context);
        }
    }
}