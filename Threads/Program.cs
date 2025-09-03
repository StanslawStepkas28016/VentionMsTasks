using System.Xml;

class Program
{
    public static void Main(string[] args)
    {
        // Using a lambda expression
        var thread1 = new Thread(() => { Console.Out.WriteLine("T1"); });
        thread1.Priority = ThreadPriority.Highest; // Property for the priority should be scheduled descending
        thread1.Start();
        Console.WriteLine($"T1: {thread1.ManagedThreadId} \n");

        // Using an anonymous function
        var thread2 = new Thread(delegate() { Console.Out.WriteLine("T2"); });
        thread2.Priority = ThreadPriority.AboveNormal;
        thread2.Start();

        // Using a delegate with parameters
        var pts = new ParameterizedThreadStart(MetWithParam);
        var thread3 = new Thread(pts);
        thread3.Start("T3 This is my text");

        thread1.Join();
        thread2.Join();
        thread3.Join();
    }

    private static void MetWithParam(object? obj)
    {
        string? text = (string)obj!;
        Console.WriteLine(text);
    }
}