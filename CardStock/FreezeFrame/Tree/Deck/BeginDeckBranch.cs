using CardStock.CardEngine;
using CardStock.FreezeFrame.Tree.Values;

namespace CardStock.FreezeFrame.Tree.Deck;

public class BeginDeckBranch : IGameNode
{
    private readonly string _branch;

    public BeginDeckBranch(string branch)
    {
        this._branch = branch;
    }

    public void Process(GameContext context)
    {
        Value value = context.Local().Peek();

        context.Assert(value.ValueType == ValueTypes.CardAttribute, "Begin Deck Branch requires top of local to be AttributeNode");

        AttributeNode node = (value.Reference as AttributeNode)!;

        context.Local().Push(new(ValueTypes.CardAttribute, new AttributeNode
        {
            Key = node.Key,
            Value = _branch
        }));
    }
}