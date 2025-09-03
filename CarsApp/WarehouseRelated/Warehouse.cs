using System.Diagnostics;
using CarsApp.CarRelated;
using CarsApp.ExternalRelated;

namespace CarsApp.WarehouseRelated;

public sealed class Warehouse : IDisposable
{
    private readonly IMockDatabase<Vehicle> _mockDatabase;
    private readonly IMockExternalLoggingService _externalLoggingService;

    public Warehouse(IMockDatabase<Vehicle> mockDatabase, IMockExternalLoggingService externalLoggingService)
    {
        _mockDatabase = mockDatabase;
        _externalLoggingService = externalLoggingService;
        Setup();
    }

    private void Setup()
    {
        _mockDatabase.Connect();
        _externalLoggingService.StartLogging();
    }

    public void AddVehicle(Vehicle vehicle)
    {
        _mockDatabase.Add(vehicle);
    }

    public void RemoveVehicle(Vehicle vehicle, Action? removeOperation = null)
    {
        var remove = _mockDatabase.Remove(vehicle);

        if (!remove)
        {
            throw new Exception("Vehicle not found!");
        }

        if (removeOperation != null)
        {
            removeOperation();
        }
    }

    public void DisplayAllVehicles()
    {
        Console.Out.WriteLine("Vehicles in Warehouse");
        Console.Out.WriteLine($"[{string.Join(", \n", _mockDatabase.Items)}]");
    }

    private void ReleaseUnmanagedResources()
    {
        // Releasing resources which are unmanaged by .NET CLR,
        // for examples other .dll's etc
        Console.Out.WriteLine("Performing mock unmanaged resource operation");

        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.FileName = "ls";
        startInfo.Arguments = $"-al";
        startInfo.RedirectStandardOutput = true;

        Process process = new Process();
        process.StartInfo = startInfo;
        process.Start();
        string output = process.StandardOutput.ReadToEnd();

        Console.WriteLine("------------------------");
        Console.WriteLine(output);
        Console.WriteLine("------------------------");
    }

    private void Dispose(bool disposing)
    {
        ReleaseUnmanagedResources();
        if (disposing)
        {
            // Releasing managed resources,
            // those which are managed by the .NET CLR
            _mockDatabase.Disconnect();
            _externalLoggingService.StopLogging();
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public IMockExternalLoggingService AccessLoggingService()
    {
        return _externalLoggingService;
    }
    
    ~Warehouse()
    {
        Dispose(false);
    }
}