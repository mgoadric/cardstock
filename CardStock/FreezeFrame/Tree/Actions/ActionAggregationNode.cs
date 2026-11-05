using CardStock.FreezeFrame.Actions;
using CardStock.FreezeFrame.Tree.Collections;

namespace CardStock.FreezeFrame.Tree.Actions;

public interface ActionAggregationNode
{
    public IList<GameActionCollection> GetActions(GameContext context);
}