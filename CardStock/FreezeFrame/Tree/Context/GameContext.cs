using CardStock.FreezeFrame.Tree.Storage;

namespace CardStock.FreezeFrame;

public class GameContext
{
    private int _pointer = 0;
    private GameStack _stack;
    private GameStack _local;

    public GameContext()
    {
        _stack = new GameStack(64);
        _local = new GameStack(16);
    }

    public void Advance(int n)
    {
        _pointer += n;
    }

    public void AdvanceTo(int position)
    {
        _pointer = position;
    }

    public void Cancel(string description = "No description provided.")
    {

    }

    public void Assert(bool statement, string description)
    {
        if (!statement)
        {
            Cancel(description);
        }
    }

    public GameStack Stack()
    {
        return _stack;
    }

    public GameStack Local()
    {
        return _local;
    }
}