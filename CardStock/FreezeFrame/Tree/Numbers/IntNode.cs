namespace CardStock.FreezeFrame.Tree.Numbers;

public class IntNode : IGameNode
{
    private readonly int _value;

    public IntNode(int value)
    {
        _value = value;
    }

    public void Process(GameContext context)
    {
        
    }

    public int GetInt()
    {
        return _value;
    }
}