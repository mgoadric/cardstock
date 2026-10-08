using CardStock.FreezeFrame.Tree.Storage;
using CardStock.FreezeFrame.Tree.Values;

namespace CardStock.FreezeFrame.Tree.Operation;

public class AdditionNode : OperationNode
{
    public override void Operate(GameStack stack, GameContext context)
    {
        Value first = stack.Pop();
        Value second = stack.Peek();

        context.Assert(first.ValueType == Values.ValueType.Int, "Addition requires value to be integer.");
        context.Assert(first.ValueType == second.ValueType, "Addition requires both values must be the same type integer.");

        second.Data = first.Int() + second.Int();
    }
}