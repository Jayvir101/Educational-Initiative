
public interface IObserver
{
    void Update(string message);
}

public interface IObservable
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify(string message);
}

public class SmartHomeHub : IObservable
{
    private List<IObserver> _observers = new List<IObserver>();
    private List<ISmartDevice> _devices = new List<ISmartDevice>();
    private Dictionary<int, string> _deviceStatus = new Dictionary<int, string>();
    private ISmartDeviceFactory _deviceFactory;

    public SmartHomeHub(ISmartDeviceFactory deviceFactory)
    {
        _deviceFactory = deviceFactory;
    }

    public void Attach(IObserver observer) => _observers.Add(observer);
    public void Detach(IObserver observer) => _observers.Remove(observer);
    public void Notify(string message)
    {
        foreach (var observer in _observers)
        {
            observer.Update(message);
        }
    }

    public void AddDevice(string type, int id)
    {
        var device = _deviceFactory.CreateDevice(type, id);
        _devices.Add(device);
        Attach((IObserver)device);
        _deviceStatus[id] = device.GetStatus();
        Console.WriteLine($"{type} with ID {id} added to the system.");
    }

    public void TurnOnDevice(int id)
    {
        var device = _devices.FirstOrDefault(d => d.GetStatus().Contains($" {id} "));
        device?.TurnOn();
        Notify($"Device {id} turned on.");
        _deviceStatus[id] = device?.GetStatus();
    }

    public void TurnOffDevice(int id)
    {
        var device = _devices.FirstOrDefault(d => d.GetStatus().Contains($" {id} "));
        device?.TurnOff();
        Notify($"Device {id} turned off.");
        _deviceStatus[id] = device?.GetStatus();
    }

    public void DisplayStatus()
    {
        foreach (var status in _deviceStatus)
        {
            Console.WriteLine(status.Value);
        }
    }
}
