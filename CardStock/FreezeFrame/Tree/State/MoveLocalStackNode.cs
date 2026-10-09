using CardStock.FreezeFrame.Tree.Storage;

namespace CardStock.FreezeFrame.Tree.State;

/*
    Moves top local to top of stack
*/
public class MoveLocalStackNode : IGameNode
{
    public void Process(GameContext context)
    {
        GameStack stack = context.Stack();
        GameStack local = context.Local();

        context.Assert(local.Size() > 0, "Local must not be empty to move to stack.");

        stack.Push(local.Pop());
    }
}