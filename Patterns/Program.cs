using System.Runtime.CompilerServices;
using EventsAndDelegates.ObserverV1;
using EventsAndDelegates.ObserverV2;

namespace EventsAndDelegates;

class Program
{
    public static async Task Main(string[] args)
    {
        // Unhandled exceptions from any threads but not from the thread pool
        // AppDomain.CurrentDomain.UnhandledException += ForNonAsyncHandler;

        // Unhandled exceptions from any threads from thread pool
        TaskScheduler.UnobservedTaskException += ForAsyncTaksHandler;


        // ObserverNonCSharpNativeSolution();
        // ObserverNativeSolution();

        /*
        List<string> outList = ["yes", "no", "yes", "no"];

        var customWhere = outList.CustomWhere();

        foreach (var se in customWhere)
        {
            Console.WriteLine(se);
        }
        */

        await Task.Run(() => { throw new Exception("asdasdasdas"); });


        // List<int> readOnlySpan = [1, 5, 3];

        // var orderedEnumerable = readOnlySpan.OrderBy(x => x);
    }

    private static void ForAsyncTaksHandler(object? sender, UnobservedTaskExceptionEventArgs e)
    {
        Console.WriteLine("Unexpected async exception happened!");
        Console.WriteLine(e.Exception.ToString());
    }

    private static void ForNonAsyncHandler(object sender, UnhandledExceptionEventArgs e)
    {
        Console.WriteLine("Unexpected exception happened!");
        Console.WriteLine(e.ExceptionObject.ToString());
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