namespace CardStock.FreezeFrame.Tree.Booleans;

public interface BooleanNode : IGameNode
{
    public static readonly BooleanNode TRUE = new BooleanLiteralNode(true);
    public static readonly BooleanNode FALSE = new BooleanLiteralNode(false);

    bool GetBoolean();
}