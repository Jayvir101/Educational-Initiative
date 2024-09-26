// SmartHomeSystem/Factories/SmartDeviceFactory.cs
public class SmartDeviceFactory : ISmartDeviceFactory
{
    public ISmartDevice CreateDevice(string type, int id)
    {
        switch (type.ToLower())
        {
            case "light": return new Light(id);
            case "thermostat": return new Thermostat(id);
            case "door": return new DoorLock(id);
            default: throw new ArgumentException("Invalid device type");
        }
    }
}
