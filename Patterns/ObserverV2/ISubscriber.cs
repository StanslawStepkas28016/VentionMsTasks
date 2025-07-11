namespace EventsAndDelegates.ObserverV2;

internal interface ISubscriber
{
    IChannel Channel { get; set; }
    void Subscribe();
    void UnSubscribe();
}