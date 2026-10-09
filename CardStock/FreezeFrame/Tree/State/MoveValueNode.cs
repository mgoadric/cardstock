using CardStock.FreezeFrame.Tree.Storage;
using CardStock.FreezeFrame.Tree.Values;

namespace CardStock.FreezeFrame.Tree.State;

/*
    Moves variable from Variables to top of locals.
*/
public class MoveValueNode : IGameNode
{
    private readonly string _variableKey;

    public MoveValueNode(string key)
    {
        this._variableKey = key;
    }

    public void Process(GameContext context)
    {
        GameVariables variables = context.Variables();
        GameStack local = context.Local();

        context.Assert(variables.IsPresent(_variableKey), "Value with key '" + _variableKey + "' is null");

        Value value = variables.Get(_variableKey);

        local.Push(value);
    }
}