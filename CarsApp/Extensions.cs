using CarsApp.CarRelated;
using CarsApp.ExternalRelated;
using CarsApp.WarehouseRelated;

namespace CarsApp;

public static class Extensions
{
    // Since Warehouse is sealed we are creating extension methods
    public static void AddListOfVehicles(this Warehouse warehouse, List<Vehicle?> vehicles)
    {
        vehicles
            .ForEach(v =>
            {
                if (v == null)
                {
                    throw new Exception("Vehicle is null");
                }

                warehouse.AddVehicle(v);
            });
    }

    public static void LogErrors(this MockExternalLoggingService mockExternalLoggingService, string message)
    {
        Console.Out.WriteLine(message);
    }
}