//Command Pattern: Remote control simulation for switching devices on/off.
using System;

public interface ICommand
{
    void Execute();
    void Undo();
}

public class Light
{
    public void On() => Console.WriteLine("Light is On");
    public void Off() => Console.WriteLine("Light is Off");
}

public class LightOnCommand : ICommand
{
    private Light _light;

    public LightOnCommand(Light light)
    {
        _light = light;
    }

    public void Execute() => _light.On();
    public void Undo() => _light.Off();
}

public class RemoteControl
{
    private ICommand _command;

    public void SetCommand(ICommand command)
    {
        _command = command;
    }

    public void PressButton()
    {
        _command.Execute();
    }

    public void PressUndo()
    {
        _command.Undo();
    }
}

class Program
{
    static void Main()
    {
        RemoteControl remote = new RemoteControl();
        Light light = new Light();
        ICommand lightOn = new LightOnCommand(light);

        remote.SetCommand(lightOn);
        remote.PressButton();
        remote.PressUndo();
    }
}
