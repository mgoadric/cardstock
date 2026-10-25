using CardStock.CardEngine;
using CardStock.FreezeFrame.Tree.Collections;
using CardStock.FreezeFrame.Tree.Storage;

namespace CardStock.FreezeFrame.Tree.Numbers.Operands;

public class IntScoreMinNode : IntNode
{
    private readonly CardLocationNode _location;
    private readonly StorageNode<PointMap> _scoring;


    public IntScoreMinNode(CardLocationNode collection, StorageNode<PointMap> scoring)
    {
        _location = collection;
        _scoring = scoring;
    }

    public int GetInt(GameContext context)
    {
        var minimum = int.MaxValue;
        var scoring = _scoring.GetStorage(context).Get();

        foreach (var item in _location.GetLocation().cardList.AllCards())
        {
            if (item is not Card card)
            {
                throw new InvalidDataException("Score minimum requires cards.");
            }

            minimum = Math.Min(minimum, scoring.GetScore(card));
        }

        return minimum;
    }
}
