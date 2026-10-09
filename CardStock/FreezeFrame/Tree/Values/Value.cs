using System.Runtime.CompilerServices;

namespace CardStock.FreezeFrame.Tree.Values;

public enum ValueTypes
{
    Int,
    Boolean,
    String,
    Card,
    Player
}

/*public struct Value
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
}*/

public readonly struct Value
{
    public readonly ValueTypes ValueType;
    public readonly object Reference;
    public readonly int Data;

    public Value(ValueTypes type, object value)
    {
        this.ValueType = type;
        this.Reference = value;
    }

    public Value(int data)
    {
        this.Data = data;
        this.ValueType = ValueTypes.Int;
    }

    public Value(bool value)
    {
        this.Data = value ? 1 : 0;
        this.ValueType = ValueTypes.Boolean;
    }

    public int Int() => Data;
}