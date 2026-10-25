using CardStock.FreezeFrame.Tree.Collections;

namespace CardStock.FreezeFrame.Tree.Numbers.Operands;

public class IntSizeOfNode : IntNode
{
    private readonly CollectionNode _collection;

    public IntSizeOfNode(CollectionNode collection)
    {
        _collection = collection;
    }

    public int GetInt(GameContext context)
    {
        return _collection.GetCollection(context).Count();
    }
}