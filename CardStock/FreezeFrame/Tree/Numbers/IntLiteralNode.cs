namespace CardStock.FreezeFrame.Tree.Numbers;

public class IntLiteralNode : IntNode
{
    private readonly int _value;

    public IntLiteralNode(int value)
    {
        _value = value;
    }

    public override int GetInt() => _value;
}