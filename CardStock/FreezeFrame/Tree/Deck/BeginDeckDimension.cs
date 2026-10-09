using CardStock.CardEngine;
using CardStock.FreezeFrame.Tree.Storage;

namespace CardStock.FreezeFrame.Tree.Deck;

/*
    This operates strangely. The idea is that it pops off attribute(s) from the stack,
    and then supplies each card with that attribute.
*/
public class BeginDeckDimension : IGameNode
{
    private readonly string _dimension;

    public BeginDeckDimension(string dimension)
    {
        this._dimension = dimension;
    }

    public void Process(GameContext context)
    {
        context.Local().Push(new Values.Value(Values.ValueTypes.CardAttribute, new AttributeNode
        {
            Value = "combo",
            Key = _dimension
        }));
    }
}