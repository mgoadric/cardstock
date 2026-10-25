namespace CardStock.FreezeFrame.Tree.Numbers.State;

public class IntVarNode : IntNode
{
    private readonly string _key;

    public IntVarNode(string key)
    {
        _key = key;
    }

    public int GetInt(GameContext context)
    {
        var temp = context.GetIterator().variables.Get(_key);

        // convert to a switch to try and help a bit with speed. Source is ProcessIntVar
        return temp switch
        {
            StorageReference<int> reference => reference.Get(),
            int v => v,
            _ => throw new Exception("Not an Integer!")
        };
    }
}