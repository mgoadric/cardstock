namespace CardStock.FreezeFrame.Tree.Collections;

public class TeamCollectionNode : CollectionNode
{
    public IEnumerable<object> GetCollection(GameContext context)
    {
        return context.Game().teams;
    }
}