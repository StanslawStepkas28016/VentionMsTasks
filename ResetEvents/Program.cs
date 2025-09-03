class Program
{
    // Needs to be "false" to block the other thread until a signal is received
    private static AutoResetEvent autoResetEvent = new AutoResetEvent(false);

    public static void Main(string[] args)
    {
        var t1 = new Thread(T1Work);

        t1.Start();

        Console.ReadLine();

        autoResetEvent.Set();
    }

    public static void T1Work()
    {
        Console.WriteLine("Hello from T1!");

        // This will block the thread until the signal is received
        autoResetEvent.WaitOne();

        // This will be printed only after the .Set() method is called in the Main thread
        Console.WriteLine("Hello 2 from T1!");
        
        autoResetEvent.WaitOne();
        
        Console.WriteLine("Bye from T1!");
    }
}