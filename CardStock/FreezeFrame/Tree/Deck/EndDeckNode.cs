using CardStock.CardEngine;
using CardStock.FreezeFrame.Tree.Storage;
using CardStock.FreezeFrame.Tree.Values;

namespace CardStock.FreezeFrame.Tree.Deck;

public class EndDeckNode : IGameNode
{
    public void Process(GameContext context)
    {
        GameStack local = context.Local();

        Value value = local.Pop();

        context.Assert(value.ValueType == ValueTypes.CardAttribute, "Top of local must be AttributeNode to finalize deck.");

        CardTree tree = new CardTree();

        tree.rootNode = (value.Reference as AttributeNode)!;

        // Console.WriteLine(tree.ToString());
    }
}