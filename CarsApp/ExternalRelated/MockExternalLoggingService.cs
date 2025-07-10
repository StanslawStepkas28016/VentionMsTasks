namespace CarsApp.ExternalRelated;

public class MockExternalLoggingService : IMockExternalLoggingService
{
    public void StartLogging()
    {
        Console.Out.WriteLine("Started MockExternalLoggingService!");
    }

    public void StopLogging()
    {
        Console.Out.WriteLine("Stopped MockExternalLoggingService!");
    }
}