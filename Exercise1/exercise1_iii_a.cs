//Structural Design Patterns
//Adapter Pattern: Using incompatible interfaces together.

using System;

public interface ITarget
{
    void Request();
}

public class Adaptee
{
    public void SpecificRequest()
    {
        Console.WriteLine("Called SpecificRequest in Adaptee.");
    }
}

public class Adapter : ITarget
{
    private Adaptee _adaptee = new Adaptee();

    public void Request()
    {
        _adaptee.SpecificRequest();
    }
}

class Program
{
    static void Main()
    {
        ITarget target = new Adapter();
        target.Request();
    }
}
