using System.Runtime.CompilerServices;
using CardStock.FreezeFrame.Tree.Values;

namespace CardStock.FreezeFrame.Tree.Storage;

public class GameStack
{
    private Value[] _stack;
    private int _sp = 0;

    public GameStack() : this(64)
    {

    }

    public GameStack(int size)
    {
        this._stack = new Value[size];
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Push(Value value)
    {
        if (_sp == _stack.Length)
            Array.Resize(ref _stack, _stack.Length);

        _stack[_sp++] = value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Value Pop()
    {
        return _stack[_sp--];
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ref Value Peek()
    {
        return ref _stack[_sp - 1];
    }

    public int Size()
    {
        return _sp;
    }

    public void Clear()
    {
        this._sp = 0;
    }
}