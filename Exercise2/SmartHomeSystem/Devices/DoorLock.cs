// Door Lock Device
public class DoorLock : ISmartDevice, IObserver
{
    private int _id;
    private string _status = "locked";

    public DoorLock(int id)
    {
        _id = id;
    }

    public void TurnOn() => _status = "unlocked";
    public void TurnOff() => _status = "locked";
    public string GetStatus() => $"Door {_id} is {_status}";

    public void Update(string message)
    {
        Console.WriteLine($"Door {_id} received update: {message}");
    }
}