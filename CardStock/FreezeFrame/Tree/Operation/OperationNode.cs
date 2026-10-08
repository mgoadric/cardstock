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

        // operate, then push the result to the top of the stack.
        Operate(stack, context);
        local.Push(stack.Pop());
    }

    public abstract void Operate(GameStack stack, GameContext context);
}