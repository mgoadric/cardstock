using CardStock.CardEngine;
using CardStock.FreezeFrame.Tree.Collections;
using CardStock.FreezeFrame.Tree.Storage;

namespace CardStock.FreezeFrame.Tree.Numbers.Operands;

public class IntScoreMaxNode : IntNode
{
    private readonly CardLocationNode _location;
    private readonly StorageNode<PointMap> _scoring;

    public IntScoreMaxNode(CardLocationNode collection, StorageNode<PointMap> scoring)
    {
        _location = collection;
        _scoring = scoring;
    }

    public int GetInt(GameContext context)
    {
        var maximum = -1;
        var scoring = _scoring.GetStorage(context).Get();

        foreach (var item in _location.GetLocation().cardList.AllCards())
        {
            if (item is not Card card)
            {
                throw new InvalidDataException("Score maximum requires cards.");
            }

            maximum = Math.Max(maximum, scoring.GetScore(card));
        }

        return maximum;
    }
}
