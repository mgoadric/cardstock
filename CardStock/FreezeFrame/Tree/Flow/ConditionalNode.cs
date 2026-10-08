namespace CardStock.FreezeFrame.Tree.Flow;

public abstract class ConditionalNode : IGameNode
{
    private readonly int _jumpEnd;

    public ConditionalNode(int jumpEnd)
    {
        this._jumpEnd = jumpEnd;
    }

    public void Process(GameContext context)
    {
        // this means we advance if the conditional is not met.
        if (!Conditional())
        {
            context.AdvanceTo(_jumpEnd);
        }
    }

    public abstract bool Conditional();
}