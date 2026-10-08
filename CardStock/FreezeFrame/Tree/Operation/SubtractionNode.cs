using CardStock.FreezeFrame.Tree.Storage;
using CardStock.FreezeFrame.Tree.Values;

namespace CardStock.FreezeFrame.Tree.Operation;

public class SubtractionNode : OperationNode
{
    public override void Operate(GameStack stack, GameStack local, GameContext context)
    {
        Value first = stack.Pop();
        Value second = stack.Pop();

        context.Assert(first.ValueType == Values.ValueTypes.Int, "Subtraction requires value to be integer.");
        context.Assert(first.ValueType == second.ValueType, "Subtraction requires both values must be the same type integer.");

        //second.Data = second.Int() - first.Int();
    }
}