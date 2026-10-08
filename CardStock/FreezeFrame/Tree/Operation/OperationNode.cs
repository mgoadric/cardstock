namespace CardStock.FreezeFrame.Tree.Operation;

public class OperationNode : IGameNode
{
    public void Process(GameContext context)
    {
        // this node is called AFTER pushing to the stack.
        // this will be ensured.
    }
}