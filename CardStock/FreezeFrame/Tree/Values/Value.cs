namespace CardStock.FreezeFrame.Tree.Values;

public enum ValueType
{
    Int,
    Boolean,
    String,
    Card,
    Player
}

public struct Value
{
    public readonly ValueType ValueType;
    public object Data;

    public Value(ValueType valueType, object data)
    {
        this.ValueType = valueType;
        this.Data = data;
    }

    public int Int()
    {
        return (int)Data;
    }
}