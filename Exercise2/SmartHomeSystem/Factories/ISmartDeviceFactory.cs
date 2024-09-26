// SmartHomeSystem/Factories/ISmartDeviceFactory.cs
public interface ISmartDeviceFactory
{
    ISmartDevice CreateDevice(string type, int id);
}

