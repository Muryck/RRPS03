using System;

public abstract class Prototype
{
    public abstract Prototype Clone();
}

public class ConcretePrototype : Prototype
{
    private string _name;

    public ConcretePrototype(string name)
    {
        _name = name;
    }

    public override Prototype Clone()
    {
        return new ConcretePrototype(_name);
    }

    public string GetName()
    {
        return _name;
    }
}

class Program
{
    static void Main(string[] args)
    {
        ConcretePrototype original = new ConcretePrototype("Original Object");

        ConcretePrototype cloned = (ConcretePrototype)original.Clone();

        Console.WriteLine("Original Object: " + original.GetName());
        Console.WriteLine("Cloned Object: " + cloned.GetName());
    }
}
