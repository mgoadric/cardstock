namespace CardStock.FreezeFrame.Tree.Storage;

public interface StorageNode<T> : IGameNode
{
    StorageReference<T> GetStorage(GameContext context);
}