// Thermostat Device
public class Thermostat : ISmartDevice, IObserver
{
    private int _id;
    private int _temperature = 70;

    public Thermostat(int id)
    {
        _id = id;
    }

    public void SetTemperature(int temperature)
    {
        _temperature = temperature;
    }

    public void TurnOn() => Console.WriteLine($"Thermostat {_id} is adjusting to {_temperature} degrees.");
    public void TurnOff() => Console.WriteLine($"Thermostat {_id} is off.");
    public string GetStatus() => $"Thermostat {_id} is set to {_temperature} degrees";

    public void Update(string message)
    {
        Console.WriteLine($"Thermostat {_id} received update: {message}");
    }
}