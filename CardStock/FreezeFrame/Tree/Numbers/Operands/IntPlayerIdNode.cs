using CardStock.CardEngine;
using CardStock.FreezeFrame.Tree.Game;

namespace CardStock.FreezeFrame.Tree.Numbers.Operands;

public class IntPlayerIdNode : IntNode
{
    private readonly PlayerNode _player;

    public IntPlayerIdNode(PlayerNode player)
    {
        _player = player;
    }

    public int GetInt(GameContext context)
    {
        return _player.GetWho(context).id + 1;
    }
}
