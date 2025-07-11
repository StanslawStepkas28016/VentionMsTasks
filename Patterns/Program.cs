using EventsAndDelegates.ObserverV1;
using EventsAndDelegates.ObserverV2;

namespace EventsAndDelegates;

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
        channel.SendNotification(new CustomChannelArgs
        {
            Operation = () => { Console.WriteLine("Performing some operations..."); }
        });
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