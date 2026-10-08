namespace CardStock.FreezeFrame.Tree.Flow;

/*
    Technically, this node is not placed at the start of a loop,
    but actually the end. This is because of this diagram.

    _ _ _ _ _ _ _ _ node

    then the node links back to the first _ at process, checking the conditional.
*/
public abstract class LoopNode : IGameNode
{
    private readonly int _loopStart;
    protected LoopNode(int loopStart)
    {
        _loopStart = loopStart;
    }

    public void Process(GameContext context)
    {
        if (Conditional())
        {
            context.AdvanceTo(_loopStart);
        }
    }

    public abstract bool Conditional();
}