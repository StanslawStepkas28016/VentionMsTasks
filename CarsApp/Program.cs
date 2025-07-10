using CarsApp.CarRelated;
using CarsApp.ExternalRelated;
using CarsApp.WarehousRelated;

namespace CarsApp;

class Program
{
    public static void Main(string[] args)
    {
        // Polymorphism
        Vehicle[] vehicles =
        [
            new SportsCar("BMW", "325i", EngineCylinderCount.V6, 200, 3.2),
            new SportsCar("Porsche", "911", EngineCylinderCount.V8, 300, 2.9),
            new FamilyCar("Opel", "Astra", EngineCylinderCount.V6, 2, 1)
        ];

        foreach (var vehicle in vehicles)
        {
            Console.Out.WriteLine(vehicle);
        }

        Console.Out.WriteLine("============================================================");

        // Abstract method usage
        var sportsCar = new SportsCar("Audi", "Q3", EngineCylinderCount.V6, 200, 6.4);
        sportsCar.Drive();

        Console.Out.WriteLine("============================================================");

        // Equality (overriden) methods usage
        var familyCar1 = new FamilyCar("Fiat", "Panda", EngineCylinderCount.V4, 5, 2);
        var familyCar2 = new FamilyCar("Fiat", "Panda", EngineCylinderCount.V4, 5, 2);

        Console.Out.WriteLine(Equals(familyCar1, familyCar2));
        Console.Out.WriteLine(familyCar1.Equals(familyCar2));

        Console.Out.WriteLine("============================================================");

        // Dependency injection and additional IDisposable interface usage
        using var warehouse = new Warehouse(new MockDatabase(), new MockExternalLoggingService());
        warehouse.AddVehicle(familyCar1);
        warehouse.AddVehicle(familyCar2);

        foreach (var vehicle in vehicles)
        {
            warehouse.AddVehicle(vehicle);
        }

        warehouse.DisplayAllVehicles();
        // GC.Collect();
        // GC.WaitForPendingFinalizers();

        Console.Out.WriteLine("============================================================");

        // Extension methods        
        Console.Out.WriteLine("After adding via the extension method: ");

        warehouse.AddListOfVehicles([
            new SportsCar("Mazda", "Miata", EngineCylinderCount.V6, 250, 3.4),
            new SportsCar("Bentley", "Bentegga", EngineCylinderCount.V8, 320, 3.5)
        ]);

        warehouse.DisplayAllVehicles();

        Console.Out.WriteLine("============================================================");

        // Delegates usage
        var mockExternalLoggingService = warehouse.AccessLoggingService();

        mockExternalLoggingService.DoSthWithDelegate(input => Console.Out.WriteLine($"From anon function: {input}")); // Anonymous function

        mockExternalLoggingService.DoSthWithDelegate(ActualFunctionForDelegate); // Actual function

        Console.Out.WriteLine("============================================================");

        Console.ReadKey();
    }

    public static void ActualFunctionForDelegate(string log)
    {
        Console.Out.WriteLine($"From actual function {log}");
    }
}