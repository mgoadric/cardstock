namespace CardStock.FreezeFrame.Tree.Collections;

public interface CollectionNode : IGameNode
{
    IEnumerable<object> GetCollection(GameContext context);
}