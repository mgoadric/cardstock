using System.Runtime.CompilerServices;
using CardStock.FreezeFrame.Tree.Values;

namespace CardStock.FreezeFrame.Tree.Storage;

public class GameStack
{
    private Value[] _stack;
    private Value[] _locals;
    private int _sp = 0;

    public GameStack() : this(64)
    {

    }

    public GameStack(int size)
    {
        this._stack = new Value[size];
        this._locals = new Value[size / 4];
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
    private ref Value Peek()
    {
        return ref _stack[_sp - 1];
    }

    public void Clear()
    {
        this._sp = 0;
    }
}