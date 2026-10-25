using CardStock.FreezeFrame.Tree.Collections;
using CardStock.FreezeFrame.Tree.Storage;

namespace CardStock.FreezeFrame.Tree.Numbers.Operands;

public class IntAggregateStorageNode : StaticParentNode, IntNode
{
    public IntAggregateStorageNode(IList<IGameNode> nodes) : base(nodes)
    {

    }

    public int GetInt(GameContext context)
    {
        var children = GetChildren().Cast<StorageNode<int>>();

        using var enumerator = children.GetEnumerator();
        if (!enumerator.MoveNext())
        {
            throw new InvalidOperationException("Addition requires at least one operand.");
        }

        var value = enumerator.Current.GetStorage(context).Get();
        while (enumerator.MoveNext())
        {
            value += enumerator.Current.GetStorage(context).Get();
        }

        return value;
    }
}
