using CardStock.CardEngine;
using CardStock.FreezeFrame.Tree.Storage;

namespace CardStock.FreezeFrame.Tree.Deck;

/*
    Push card collection and initial attribute node to stack
    Local holds the attribute, so that its easier to work with.
*/
public class BeginDeckNode : IGameNode
{
    private readonly string _collectionName;
    private readonly CCType _visibility;

    public BeginDeckNode(string collectionName, CCType visibility)
    {
        _collectionName = collectionName;
        _visibility = visibility;
    }

    public void Process(GameContext context)
    {
        GameStack stack = context.Stack();
        GameStack local = context.Local();

        //stack.Push(new(Values.ValueTypes.String, _collectionName));
        //stack.Push(new(Values.ValueTypes.CardCollection, context.CreateCardCollection(_visibility)));

        local.Push(new(Values.ValueTypes.CardAttribute, new AttributeNode
        {
            Key = "ROOT",
            Value = "Root"
        }));
    }
}