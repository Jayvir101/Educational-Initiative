// SmartHomeSystem/Program.cs
using System;

class Program
{
    static void Main(string[] args)
    {
        // Create the factory
        ISmartDeviceFactory deviceFactory = new SmartDeviceFactory();

        // Initialize the Smart Home Hub
        SmartHomeHub smartHomeHub = new SmartHomeHub(deviceFactory);

        // Add devices
        smartHomeHub.AddDevice("light", 1);
        smartHomeHub.AddDevice("thermostat", 2);
        smartHomeHub.AddDevice("door", 3);

        // Turn devices on/off
        smartHomeHub.TurnOnDevice(1);
        smartHomeHub.TurnOffDevice(2);

        // Display status
        Console.WriteLine("\nStatus Report:");
        smartHomeHub.DisplayStatus();
    }
}
