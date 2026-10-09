using CardStock.FreezeFrame.Tree.Storage;

namespace CardStock.FreezeFrame.Tree.State;

public class MoveStackLocalNode : IGameNode
{
    public void Process(GameContext context)
    {
        GameStack stack = context.Stack();
        GameStack local = context.Local();

        context.Assert(stack.Size() > 0, "Stack must not be empty to move to stack.");

        local.Push(stack.Pop());
    }
}