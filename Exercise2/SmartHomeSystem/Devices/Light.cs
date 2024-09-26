
public class Light : ISmartDevice, IObserver
{
    private int _id;
    private string _status = "off";

    public Light(int id)
    {
        _id = id;
    }

    public void TurnOn() => _status = "on";
    public void TurnOff() => _status = "off";
    public string GetStatus() => $"Light {_id} is {_status}";

    public void Update(string message)
    {
        Console.WriteLine($"Light {_id} received update: {message}");
    }
}
