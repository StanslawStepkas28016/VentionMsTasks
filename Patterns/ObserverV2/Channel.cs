namespace EventsAndDelegates.ObserverV2;

internal class Channel : IChannel
{
    public event EventHandler<CustomChannelArgs>? EventHandler;

    public void SendNotification(CustomChannelArgs args)
    {
        EventHandler?.Invoke(this, args);
    }
}