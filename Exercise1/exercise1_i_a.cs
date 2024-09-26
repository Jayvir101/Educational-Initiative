//Observer Pattern: Stock price notifications for subscribers.

using System;
using System.Collections.Generic;

public interface IObserver
{
    void Update(float price);
}

public class Stock : IObservable
{
    private List<IObserver> observers = new List<IObserver>();
    private float price;

    public void SetPrice(float price)
    {
        this.price = price;
        Notify();
    }

    public void Attach(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in observers)
        {
            observer.Update(price);
        }
    }
}

public class StockObserver : IObserver
{
    private string name;

    public StockObserver(string name)
    {
        this.name = name;
    }

    public void Update(float price)
    {
        Console.WriteLine($"Notifying {name}: Stock price changed to {price}");
    }
}

class Program
{
    static void Main()
    {
        Stock googleStock = new Stock();
        StockObserver investor1 = new StockObserver("Investor1");
        StockObserver investor2 = new StockObserver("Investor2");

        googleStock.Attach(investor1);
        googleStock.Attach(investor2);

        googleStock.SetPrice(1200.50f);
    }
}
