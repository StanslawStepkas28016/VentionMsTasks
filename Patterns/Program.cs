using EventsAndDelegates.Observer;

namespace EventsAndDelegates;

interface IChannel
{
    event EventHandler<string> EventHandler;
    void SendNotification(string message);
}

internal class Channel : IChannel
{
    public event EventHandler<string>? EventHandler;

    public void SendNotification(string message)
    {
        EventHandler?.Invoke(this, message);
    }
}

internal interface ISubscriber
{
    IChannel Channel { get; set; }
    void Subscribe();
    void UnSubscribe();
}

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

    private void OnMessageReceived(object? sender, string eventArgument)
    {
        Console.WriteLine(eventArgument);
    }
}

class Program
{
    public static void Main(string[] args)
    {
        // ObserverNonCSharpNativeSolution();
        ObserverNativeSolution();
    }

    private static void ObserverNativeSolution()
    {
        // Create a channel
        var channel = new Channel();

        // Subscribe to it
        var subscriber1 = new Subscriber(channel);
        var subscriber2 = new Subscriber(channel);
        subscriber1.Subscribe();
        subscriber2.Subscribe();
        
        // Notify subs
        channel.SendNotification("Hello World!");
    }

    private static void ObserverNonCSharpNativeSolution()
    {
        var store = new Store();

        store.AddSubscriber(new Customer());
        store.AddSubscriber(new Customer());

        var message = "My message to all subscribers is!";
        store.NotifyAll(ref message);
    }
}