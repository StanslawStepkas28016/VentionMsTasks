namespace CarsApp.ExternalRelated;

public interface IMockExternalLoggingService
{
    void StartLogging();
    void StopLogging();
    void DoSthWithDelegate(MockExternalLoggingService.PerformedDelegate performedDelegate);
}