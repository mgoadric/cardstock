using CardStock.FreezeFrame.Tree.Values;

namespace CardStock.FreezeFrame.Tree.State;

public class PushNode : IGameNode
{
    private readonly Value _value;

    public PushNode(Value value)
    {
        this._value = value;
    }

    public void Process(GameContext context)
    {
        context.Stack().Push(_value);
    }
}