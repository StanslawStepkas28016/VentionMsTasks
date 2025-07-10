namespace CarsApp.ExternalRelated;

public sealed class MockExternalLoggingService : IMockExternalLoggingService
{
    public delegate void PerformedDelegate(string log);

    public void StartLogging()
    {
        Console.Out.WriteLine("Started MockExternalLoggingService!");
    }

    public void StopLogging()
    {
        Console.Out.WriteLine("Stopped MockExternalLoggingService!");
    }

    public void DoSthWithDelegate(PerformedDelegate performedDelegate)
    {
        performedDelegate("Some stuff");
        Console.Out.WriteLine("LogWithDelegate finished!");
    }
}