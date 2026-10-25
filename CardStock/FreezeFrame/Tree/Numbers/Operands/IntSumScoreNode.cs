using CardStock.CardEngine;
using CardStock.FreezeFrame.Tree.Collections;
using CardStock.FreezeFrame.Tree.Storage;

namespace CardStock.FreezeFrame.Tree.Numbers.Operands;

public sealed class IntSumScoreNode : IntNode
{
    private readonly CollectionNode _collection;
    private readonly StorageNode<PointMap> _scoring;

    public IntSumScoreNode(CollectionNode collection, StorageNode<PointMap> scoring)
    {
        _collection = collection;
        _scoring = scoring;
    }

    public int GetInt(GameContext context)
    {
        var scoring = _scoring.GetStorage(context).Get();
        var total = 0;

        foreach (var item in _collection.GetCollection(context))
        {
            if (item is not Card card)
            {
                throw new InvalidDataException("Collection sum requires cards.");
            }

            total += scoring.GetScore(card);
        }

        return total;
    }
}
