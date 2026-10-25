namespace CardStock.FreezeFrame.Tree.Numbers.Operands;

public class IntExponentNode : IntNode
{
    private readonly IntNode _left, _right;

    public IntExponentNode(IntNode left, IntNode right)
    {
        _left = left;
        _right = right;
    }

    public int GetInt(GameContext context)
    {
        return Convert.ToInt32(Math.Pow(_left.GetInt(context), _right.GetInt(context)));
    }
}