using System;

class Pizza
{
    public string Dough { get; set; }
    public string Sauce { get; set; }
    public string Topping { get; set; }

    public void Display()
    {
        Console.WriteLine($"Pizza with {Dough} dough, {Sauce} sauce, and {Topping} topping.");
    }
}

abstract class PizzaBuilder
{
    protected Pizza _pizza = new Pizza();

    public Pizza GetPizza()
    {
        return _pizza;
    }

    public abstract void BuildDough();
    public abstract void BuildSauce();
    public abstract void BuildTopping();
}

class HawaiianPizzaBuilder : PizzaBuilder
{
    public override void BuildDough()
    {
        _pizza.Dough = "Thin";
    }

    public override void BuildSauce()
    {
        _pizza.Sauce = "Mild";
    }

    public override void BuildTopping()
    {
        _pizza.Topping = "Ham and Pineapple";
    }
}

class SpicyPizzaBuilder : PizzaBuilder
{
    public override void BuildDough()
    {
        _pizza.Dough = "Thick";
    }

    public override void BuildSauce()
    {
        _pizza.Sauce = "Hot";
    }

    public override void BuildTopping()
    {
        _pizza.Topping = "Pepperoni and Jalapeno";
    }
}

class Waiter
{
    private PizzaBuilder _pizzaBuilder;

    public void SetPizzaBuilder(PizzaBuilder pizzaBuilder)
    {
        _pizzaBuilder = pizzaBuilder;
    }

    public void ConstructPizza()
    {
        _pizzaBuilder.BuildDough();
        _pizzaBuilder.BuildSauce();
        _pizzaBuilder.BuildTopping();
    }

    public Pizza GetPizza()
    {
        return _pizzaBuilder.GetPizza();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Waiter waiter = new Waiter();
        PizzaBuilder hawaiianPizzaBuilder = new HawaiianPizzaBuilder();
        PizzaBuilder spicyPizzaBuilder = new SpicyPizzaBuilder();

        waiter.SetPizzaBuilder(hawaiianPizzaBuilder);
        waiter.ConstructPizza();
        Pizza hawaiianPizza = waiter.GetPizza();
        hawaiianPizza.Display();

        waiter.SetPizzaBuilder(spicyPizzaBuilder);
        waiter.ConstructPizza();
        Pizza spicyPizza = waiter.GetPizza();
        spicyPizza.Display();
    }
}
