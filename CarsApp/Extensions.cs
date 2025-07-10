using CarsApp.CarRelated;
using CarsApp.WarehousRelated;

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
}