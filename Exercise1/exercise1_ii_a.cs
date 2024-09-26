//Creational Design Patterns
//Singleton Pattern: Logger to ensure only one instance of logger is used across the application.

using System;

public sealed class Logger
{
    private static Logger _instance = null;
    private static readonly object _lock = new object();

    private Logger() { }

    public static Logger GetInstance()
    {
        lock (_lock)
        {
            if (_instance == null)
                _instance = new Logger();
        }
        return _instance;
    }

    public void Log(string message)
    {
        Console.WriteLine($"Log message: {message}");
    }
}

class Program
{
    static void Main()
    {
        Logger logger = Logger.GetInstance();
        logger.Log("Singleton Pattern Logger initialized.");
    }
}
