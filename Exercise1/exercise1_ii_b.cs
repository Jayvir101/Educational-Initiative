//Factory Pattern: Vehicle factory that creates different types of vehicles.

using System;

public interface IVehicle
{
    void Drive();
}

public class Car : IVehicle
{
    public void Drive() => Console.WriteLine("Driving a Car.");
}

public class Bike : IVehicle
{
    public void Drive() => Console.WriteLine("Riding a Bike.");
}

public class VehicleFactory
{
    public static IVehicle GetVehicle(string vehicleType)
    {
        if (vehicleType == "Car")
            return new Car();
        else if (vehicleType == "Bike")
            return new Bike();
        else
            throw new ArgumentException("Unknown vehicle type");
    }
}

class Program
{
    static void Main()
    {
        IVehicle vehicle1 = VehicleFactory.GetVehicle("Car");
        vehicle1.Drive();

        IVehicle vehicle2 = VehicleFactory.GetVehicle("Bike");
        vehicle2.Drive();
    }
}
