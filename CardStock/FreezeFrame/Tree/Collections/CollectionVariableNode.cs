using CardStock.CardEngine;

namespace CardStock.FreezeFrame.Tree.Collections;

public class CollectionVariableNode : CollectionNode
{
    private readonly string _key;

    public CollectionVariableNode(string key)
    {
        _key = key;
    }

    public IEnumerable<object> GetCollection(GameContext context)
    {
        var value = context.GetIterator().variables.Get(_key);

        return value switch
        {
            CardLocReference clr => clr.cardList.AllCards(),
            CardLocReference[] clrs => clrs,
            string[] sa => sa,
            List<CardLocReference> clocr => clocr,
            Team ta => ta.teamPlayers,
            List<int> ls => (List<object>) value,
            List<Card> cards => cards,
            List<object> objs => objs,
            _ => throw new TypeAccessException("Invalid type from collection!")  
        };
    }
}