namespace CardStock.FreezeFrame.Tree;

public interface IGameParent : IGameNode
{
    IList<IGameNode> GetChildren();
}