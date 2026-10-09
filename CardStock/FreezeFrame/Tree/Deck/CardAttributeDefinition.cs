using CardStock.CardEngine;
using CardStock.FreezeFrame.Tree.Values;

namespace CardStock.FreezeFrame.Tree.Deck;

public class CardAttributeDefinition : IGameNode
{
    private readonly string _definition;

    public CardAttributeDefinition(string definition)
    {
        this._definition = definition;
    }

    public void Process(GameContext context)
    {
        Value value = context.Local().Peek();

        context.Assert(value.ValueType == ValueTypes.CardAttribute, "To define a card attribute, top of stack must be of type CardAttribute.");

        AttributeNode node = (value.Reference as AttributeNode)!;

        node!.children.Add(new AttributeNode
        {
            Key = node.Key,
            Value = _definition
        });
    }
}