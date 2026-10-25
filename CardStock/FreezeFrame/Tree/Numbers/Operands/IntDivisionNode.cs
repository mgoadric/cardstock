namespace CardStock.FreezeFrame.Tree.Numbers.Operands;

public class IntDivisionNode : IntNode
{
    private readonly IntNode _left, _right;
    public IntDivisionNode(IntNode left, IntNode right)
    {
        _left = left;
        _right = right;
    }

    public int GetInt(GameContext context)
    {
        int divisor = _right.GetInt(context);

        if (divisor == 0)
        {
            Console.WriteLine("Divison by 0 invalid.");
        }

        return _left.GetInt(context) / divisor;
    }
}