using CardStock.CardEngine;
using CardStock.Evaluation;

namespace CardStock.FreezeFrame.Tree;

public class GameContext
{
    private readonly GameIterator _iterator;

    public GameContext(GameIterator iterator)
    {
        this._iterator = iterator;
    }

    public GameIterator GetIterator()
    {
        return _iterator;
    }

    public CardGame Game()
    {
        return _iterator.game;
    }
}