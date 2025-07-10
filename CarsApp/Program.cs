using CarsApp;

class Program
{
    public static void Main(string[] args)
    {
        var vehicle1 = new SportsCar("BMW", "325i", EngineCylinderCount.V6, 200, 3.2);
        var vehicle2 = new SportsCar("Porsche", "911", EngineCylinderCount.V8, 300, 2.9);
    }
}