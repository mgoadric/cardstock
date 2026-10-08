using CardStock.FreezeFrame.Tree.Storage;
using CardStock.FreezeFrame.Tree.Values;

namespace CardStock.FreezeFrame.Tree.Operation;

public class AdditionNode : OperationNode
{
    public override void Operate(GameStack stack, GameStack local, GameContext context)
    {
        Value first = stack.Pop();
        Value second = stack.Pop();

        context.Assert(first.ValueType == Values.ValueTypes.Int, "Addition requires value to be integer.");
        context.Assert(first.ValueType == second.ValueType, "Addition requires both values must be the same type integer.");

        local.Push(new(second.Int() + first.Int()));
    }
}