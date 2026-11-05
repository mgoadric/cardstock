using CardStock.FreezeFrame.Actions;

namespace CardStock.FreezeFrame.Tree.Actions.Aggregation;

public class SingleActionAggregationNode : ActionAggregationNode
{
    private readonly ActionSupplierNode _node;

    public SingleActionAggregationNode(ActionSupplierNode node)
    {
        _node = node;
    }

    public IList<GameActionCollection> GetActions(GameContext context)
    {
        return new List<GameActionCollection> { new GameActionCollection { _node.GetAction(context) } };
    }
}