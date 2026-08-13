using System;

public interface IVehicle { string Model { get; } void Drive(); }
public interface IElectric { int BatteryPercent { get; set; } void Charge(); }
public interface IElectricVehicle : IVehicle, IElectric { }

public class ElectricCar : IElectricVehicle
{
    public string Model { get; init; }
    private int _batteryPercent;

    public int BatteryPercent
    {
        get { return _batteryPercent; }
        set { _batteryPercent = value < 0 ? 0 : value > 100 ? 100 : value; }
    }

    public ElectricCar(string model, int batteryPercent) { Model = model; BatteryPercent = batteryPercent; }
    public void Drive() { BatteryPercent -= 10; }
    public void Charge() { BatteryPercent = 100; }
}

class Program
{
    static void Main()
    {
        ElectricCar car = new ElectricCar("Tesla Model 3", 100);

        car.Drive(); Console.WriteLine($"Battery after drive 1: {car.BatteryPercent}%");
        car.Drive(); Console.WriteLine($"Battery after drive 2: {car.BatteryPercent}%");
        car.Drive(); Console.WriteLine($"Battery after drive 3: {car.BatteryPercent}%");
        car.Charge(); Console.WriteLine($"Battery after charge: {car.BatteryPercent}%");

        IVehicle vehicle = car;
        Console.WriteLine($"As IVehicle - Model: {vehicle.Model}");

        IElectric electric = car;
        Console.WriteLine($"As IElectric - BatteryPercent: {electric.BatteryPercent}");
    }
}
