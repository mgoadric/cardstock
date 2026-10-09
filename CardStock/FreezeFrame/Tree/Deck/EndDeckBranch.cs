using CardStock.CardEngine;
using CardStock.FreezeFrame.Tree.Storage;
using CardStock.FreezeFrame.Tree.Values;

namespace CardStock.FreezeFrame.Tree.Deck;

public class EndDeckBranch : IGameNode
{
    public void Process(GameContext context)
    {
        GameStack stack = context.Stack();
        GameStack local = context.Local();

        Value value = local.Pop();

        context.Assert(value.ValueType == ValueTypes.CardAttribute, "Value must be of type CardAttribute");

        Value node = local.Peek();

        context.Assert(node.ValueType == ValueTypes.CardAttribute, "Value must be of type AttributeNode");

        (node.Reference as AttributeNode)!.children.Add((value.Reference as AttributeNode)!);
    }
}