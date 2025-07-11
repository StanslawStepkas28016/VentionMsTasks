namespace EventsAndDelegates.ObserverV2;

interface IChannel
{
    event EventHandler<CustomChannelArgs> EventHandler;
    void SendNotification(CustomChannelArgs args);
}