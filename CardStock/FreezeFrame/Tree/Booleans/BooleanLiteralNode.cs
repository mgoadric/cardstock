namespace CardStock.FreezeFrame.Tree.Booleans;

public class BooleanLiteralNode(bool _value) : BooleanNode
{
    public bool GetBoolean()
    {
        return _value;
    }
}