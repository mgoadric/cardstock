using CardStock.CardEngine;
using CardStock.FreezeFrame.Tree.Cards;
using CardStock.FreezeFrame.Tree.Storage;

namespace CardStock.FreezeFrame.Tree.Numbers.Operands;

public class IntCardScoreNode : IntNode
{
    private readonly CardNode _cardNode;
    private readonly StorageNode<PointMap> _scoring;

    public IntCardScoreNode(CardNode cardNode, StorageNode<PointMap> scoring)
    {
        _cardNode = cardNode;
        _scoring = scoring;
    }

    public int GetInt(GameContext context)
    {
        return _scoring.GetStorage(context).Get().GetScore(_cardNode.GetCard(context));
    }
}
