namespace CardStock.FreezeFrame.Tree.Numbers.Operands;

public class IntSubtractionNode : IntNode
{
    private readonly IntNode _left, _right;
    public IntSubtractionNode(IntNode left, IntNode right)
    {
        _left = left;
        _right = right;
    }

    public int GetInt(GameContext context)
    {
        return _left.GetInt(context) - _right.GetInt(context);
    }
}