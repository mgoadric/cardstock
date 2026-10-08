using System.Diagnostics;
using CardStock.FreezeFrame.Tree.Storage;
using CardStock.FreezeFrame.Tree.Values;

namespace CardStock.FreezeFrame;

public class GameContext
{
    private int _pointer = 0;
    private GameStack _stack;
    private GameStack _local;

    public GameContext()
    {
        _stack = new(64);
        _local = new(16);
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
        Console.WriteLine(description);
    }

    // function no exist if not debug.
    // speed!
    [Conditional("DEBUG")]
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