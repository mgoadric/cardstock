namespace CardStock.FreezeFrame.Tree.Values;

public enum ValueTypes
{
    Int,
    Boolean,
    String,
    Card,
    Player
}

public struct Value
{
    public readonly ValueTypes ValueType;
    public readonly int IntData;
    public readonly object? ReferenceData;

    public Value(int value)
    {
        ValueType = ValueTypes.Int;
        IntData = value;
        ReferenceData = null;
    }

    public Value(ValueTypes valueType, object? data)
    {
        ValueType = valueType;
        IntData = 0;
        ReferenceData = data;
    }

    public int Int() => IntData;
}