using CardStock.CardEngine;
using CardStock.FreezeFrame.Tree.Game;
using CardStock.FreezeFrame.Tree.Numbers;
using CardStock.FreezeFrame.Tree.Strings;
using CardStock.Players;

namespace CardStock.FreezeFrame.Tree.Storage;

public class IntStorageNode : IntNode, StorageNode<int>
{
    private readonly OwnerNode<Owner> _owner;
    private readonly StringNode _key;
    public IntStorageNode(OwnerNode<Owner> owner, StringNode key)
    {
        this._owner = owner;
        this._key = key;
    }

    public int GetInt(GameContext context)
    {
        return GetStorage(context).Get();
    }

    public StorageReference<int> GetStorage(GameContext context)
    {
        var who = _owner.GetWho(context);

        return new StorageReference<int>(who.intBins, _key.GetString(context));
    }
}