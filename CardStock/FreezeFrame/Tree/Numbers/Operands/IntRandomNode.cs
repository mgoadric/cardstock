namespace CardStock.FreezeFrame.Tree.Numbers.Operands;

public class IntRandomNode : IntNode
{
    private readonly IntNode _first;
    private readonly IntNode? _second;

    public IntRandomNode(IntNode first, IntNode? second)
    {
        _first = first;
        _second = second;
    }

    public int GetInt(GameContext context)
    {
        if (_second is not null)
        {
            return ThreadSafeRandom.Next(_first.GetInt(context), _second.GetInt(context) + 1);
        }
        else
        {
            return ThreadSafeRandom.Next(0, _first.GetInt(context) + 1);
        }
    }
}