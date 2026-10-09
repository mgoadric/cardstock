using CardStock.FreezeFrame.Tree.Storage;

namespace CardStock.FreezeFrame.Tree.State;

/*
    Takes the top of Local and stores it into variables.
*/
public class StoreValueNode : IGameNode
{
    private readonly string _variableKey;

    public StoreValueNode(string key)
    {
        _variableKey = key;
    }

    public void Process(GameContext context)
    {
        GameStack local = context.Local();
        GameVariables variables = context.Variables();

        context.Assert(local.Size() > 0, "Must be a value on local to move to variable pos '" + _variableKey + "'");

        variables.Store(_variableKey, local.Pop());
    }
}