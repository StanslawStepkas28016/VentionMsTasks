using CarsApp.CarRelated;

namespace CarsApp.WarehouseRelated;

public sealed class MockDatabase : IMockDatabase<Vehicle>
{
    public List<Vehicle> Items { get; init; }

    public MockDatabase()
    {
        Items = new();
    }

    public void Connect()
    {
        Console.Out.WriteLine("Connected to database successfully!");
    }

    public Vehicle Add(Vehicle t)
    {
        Items.Add(t);
        return t;
    }


    public bool Remove(in Vehicle t)
    {
        return Items.Remove(t);
    }

    public void Disconnect()
    {
        Console.Out.WriteLine("Disconnected from database successfully!");
    }
}