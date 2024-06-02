using System;

interface IDough
{
    string Description();
}

interface ISauce
{
    string Description();
}

interface ITopping
{
    string Description();
}

class ThinCrustDough : IDough
{
    public string Description()
    {
        return "Thin crust dough";
    }
}

class ThickCrustDough : IDough
{
    public string Description()
    {
        return "Thick crust dough";
    }
}

class MildSauce : ISauce
{
    public string Description()
    {
        return "Mild sauce";
    }
}

class HotSauce : ISauce
{
    public string Description()
    {
        return "Hot sauce";
    }
}

class HamAndPineappleTopping : ITopping
{
    public string Description()
    {
        return "Ham and pineapple topping";
    }
}

class PepperoniAndJalapenoTopping : ITopping
{
    public string Description()
    {
        return "Pepperoni and jalapeno topping";
    }
}

interface IPizzaFactory
{
    IDough CreateDough();
    ISauce CreateSauce();
    ITopping CreateTopping();
}

class HawaiianPizzaFactory : IPizzaFactory
{
    public IDough CreateDough()
    {
        return new ThinCrustDough();
    }

    public ISauce CreateSauce()
    {
        return new MildSauce();
    }

    public ITopping CreateTopping()
    {
        return new HamAndPineappleTopping();
    }
}

class SpicyPizzaFactory : IPizzaFactory
{
    public IDough CreateDough()
    {
        return new ThickCrustDough();
    }

    public ISauce CreateSauce()
    {
        return new HotSauce();
    }

    public ITopping CreateTopping()
    {
        return new PepperoniAndJalapenoTopping();
    }
}

class Program
{
    static void Main(string[] args)
    {
        IPizzaFactory hawaiianFactory = new HawaiianPizzaFactory();
        IPizzaFactory spicyFactory = new SpicyPizzaFactory();

        IDough hawaiianDough = hawaiianFactory.CreateDough();
        ISauce hawaiianSauce = hawaiianFactory.CreateSauce();
        ITopping hawaiianTopping = hawaiianFactory.CreateTopping();

        Console.WriteLine("Hawaiian Pizza:");
        Console.WriteLine(hawaiianDough.Description());
        Console.WriteLine(hawaiianSauce.Description());
        Console.WriteLine(hawaiianTopping.Description());

        IDough spicyDough = spicyFactory.CreateDough();
        ISauce spicySauce = spicyFactory.CreateSauce();
        ITopping spicyTopping = spicyFactory.CreateTopping();

        Console.WriteLine("\nSpicy Pizza:");
        Console.WriteLine(spicyDough.Description());
        Console.WriteLine(spicySauce.Description());
        Console.WriteLine(spicyTopping.Description());
    }
}
