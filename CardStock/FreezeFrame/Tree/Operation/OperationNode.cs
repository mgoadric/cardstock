using CardStock.FreezeFrame.Tree.Storage;
using CardStock.FreezeFrame.Tree.Values;

namespace CardStock.FreezeFrame.Tree.Operation;

public abstract class OperationNode : IGameNode
{
    public void Process(GameContext context)
    {
        // this node is called AFTER pushing to the stack.
        // this will be ensured.

        GameStack stack = context.Stack();
        context.Assert(stack.Size() >= 2, "Ensure stack has childs to operate on.");
        GameStack local = context.Local();

        Operate(stack, local, context);
    }

    public abstract void Operate(
        GameStack stack,
        GameStack local,
        GameContext context
    );
}