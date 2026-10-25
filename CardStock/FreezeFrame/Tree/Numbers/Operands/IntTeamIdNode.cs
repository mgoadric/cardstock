using CardStock.CardEngine;
using CardStock.FreezeFrame.Tree.Game;

namespace CardStock.FreezeFrame.Tree.Numbers.Operands;

public sealed class IntTeamIdNode : IntNode
{
    private readonly TeamNode _teamNode;

    public IntTeamIdNode(TeamNode teamNode)
    {
        _teamNode = teamNode;
    }

    public int GetInt(GameContext context)
    {
        return _teamNode.GetWho(context).id;
    }
}
