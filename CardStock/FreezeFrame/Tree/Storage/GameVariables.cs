using CardStock.FreezeFrame.Tree.Values;

namespace CardStock.FreezeFrame.Tree.Storage;

public class GameVariables
{
    private readonly Dictionary<string, Value> _variables = new();

    public GameVariables()
    {

    }

    public void Store(string key, Value value)
    {
        _variables[key] = value;
    }

    public Value Get(string key)
    {
        return _variables[key];
    }

    public bool IsPresent(string key)
    {
        return _variables.ContainsKey(key);
    }
}