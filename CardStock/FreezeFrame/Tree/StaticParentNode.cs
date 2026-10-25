using System.Collections.ObjectModel;

namespace CardStock.FreezeFrame.Tree;

/*
    I was going to call it unmutable or readonly, but it is easier to just
    call it static, due to it being shorter. I cannot enforce it through the collection,
    but just dont add stuff please.
*/
public class StaticParentNode : IGameParent
{
    private readonly IList<IGameNode> _nodes;

    public StaticParentNode(IList<IGameNode> nodes)
    {
        _nodes = nodes;
    }

    public IList<IGameNode> GetChildren()
    {
        return _nodes;
    }
}