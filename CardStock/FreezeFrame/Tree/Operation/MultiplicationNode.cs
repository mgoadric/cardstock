using CardStock.FreezeFrame.Tree.Storage;
using CardStock.FreezeFrame.Tree.Values;

namespace CardStock.FreezeFrame.Tree.Operation;

/*
    Multiplication operand on top 2 values on stack.
*/
public class MultiplicationNode : OperationNode
{
    public override void Operate(GameStack stack, GameStack local, GameContext context)
    {
        Value first = stack.Pop();
        Value second = stack.Pop();

        context.Assert(first.ValueType == ValueTypes.Int && second.ValueType == ValueTypes.Int, "Multiplication requires values to be integers.");

        stack.Push(new(second.Int() * first.Int()));
    }
}