namespace CardStock.FreezeFrame.Tree.Numbers.Operands;

public class IntTriangularNode : IntNode
{
    private readonly IntNode _node;

    public IntTriangularNode(IntNode node)
    {
        _node = node;
    }

    public int GetInt(GameContext context)
    {
        int value = _node.GetInt(context);

        return (value * (value + 1)) / 2;
    }
}