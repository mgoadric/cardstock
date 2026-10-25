namespace CardStock.FreezeFrame.Tree.Numbers.Operands;

public class IntMultiplyNode : StaticParentNode, IntNode
{
    public IntMultiplyNode(IList<IGameNode> _children) : base(_children)
    {

    }

    public int GetInt(GameContext context)
    {
        var children = GetChildren().Cast<IntNode>();

        using var enumerator = children.GetEnumerator();
        if (!enumerator.MoveNext())
        {
            throw new InvalidOperationException("Multiplication requires at least one operand.");
        }

        var value = enumerator.Current.GetInt(context);
        while (enumerator.MoveNext())
        {
            value *= enumerator.Current.GetInt(context);
        }

        return value;
    }
}