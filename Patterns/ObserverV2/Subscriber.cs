namespace EventsAndDelegates.ObserverV2;

class Subscriber : ISubscriber
{
    public IChannel Channel { get; set; }

    public Subscriber(IChannel channel)
    {
        Channel = channel;
    }

    public void Subscribe()
    {
        Channel.EventHandler += OnMessageReceived;
    }

    public void UnSubscribe()
    {
        Channel.EventHandler += OnMessageReceived;
    }

    private void OnMessageReceived(object? sender, CustomChannelArgs args)
    {
        args.Operation?.Invoke();
    }
}