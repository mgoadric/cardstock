namespace CardStock.FreezeFrame.Tree.Numbers.Operands;

public class IntFibNode : IntNode
{
    private readonly IntNode _node;

    public IntFibNode(IntNode node)
    {
        _node = node;
    }

    public int GetInt(GameContext context)
    {
        int value = _node.GetInt(context);

        return Convert.ToInt32(
            (Math.Pow((1 + Math.Sqrt(5)) / 2, value)
            - Math.Pow((1 - Math.Sqrt(5)) / 2, value)) / Math.Sqrt(5)
        );
    }
}