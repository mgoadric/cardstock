namespace CardStock.FreezeFrame.Tree.Collections;

public class PlayerCollectionNode : CollectionNode
{
    public IEnumerable<object> GetCollection(GameContext context)
    {
        return context.Game().players;
    }
}