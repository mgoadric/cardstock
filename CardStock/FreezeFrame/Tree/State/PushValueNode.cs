using CardStock.FreezeFrame.Tree.Values;

namespace CardStock.FreezeFrame.Tree.State;

public class PushValueNode : IGameNode
{
    private readonly Value _value;

    public PushValueNode(Value value)
    {
        this._value = value;
    }

    public void Process(GameContext context)
    {
        context.Stack().Push(_value);
    }
}