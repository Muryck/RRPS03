using System;

class Context
{
    private IState _state;

    public Context(IState state)
    {
        TransitionTo(state);
    }

    public void TransitionTo(IState state)
    {
        Console.WriteLine($"Context: Transition to {state.GetType().Name}.");
        _state = state;
        _state.SetContext(this);
    }

    public void Request1()
    {
        _state.Handle1();
    }

    public void Request2()
    {
        _state.Handle2();
    }
}

interface IState
{
    void SetContext(Context context);
    void Handle1();
    void Handle2();
}

class ConcreteStateA : IState
{
    private Context _context;

    public void SetContext(Context context)
    {
        _context = context;
    }

    public void Handle1()
    {
        Console.WriteLine("ConcreteStateA handles request1.");
        Console.WriteLine("ConcreteStateA wants to change the state of the context.");
        _context.TransitionTo(new ConcreteStateB());
    }

    public void Handle2()
    {
        Console.WriteLine("ConcreteStateA handles request2.");
    }
}

class ConcreteStateB : IState
{
    private Context _context;

    public void SetContext(Context context)
    {
        _context = context;
    }

    public void Handle1()
    {
        Console.WriteLine("ConcreteStateB handles request1.");
    }

    public void Handle2()
    {
        Console.WriteLine("ConcreteStateB handles request2.");
        Console.WriteLine("ConcreteStateB wants to change the state of the context.");
        _context.TransitionTo(new ConcreteStateA());
    }
}

class Program
{
    static void Main(string[] args)
    {
        Context context = new Context(new ConcreteStateA());

        context.Request1();
        context.Request2();
    }
}
