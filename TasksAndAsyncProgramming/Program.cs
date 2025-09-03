using System.Reflection.Metadata;

class A
{
    public string S { get; set; }

    public A(string s)
    {
        S = s;
    }
}

class Program
{
    /*public static void Main(string[] args)
    {
        // Task with action
        // TaskWithAction();

        // Semaphore example
        // SemaphoreExample().GetAwaiter().GetResult();

        // Global Mutex example
        GlobalMutexExample();
    }*/

    private static Mutex mutex;

    public static void GlobalMutexExample()
    {
        mutex = new Mutex(true, "GlobalMutexExample", out var createdNew);
        var semaphore = new Semaphore(0, 1, "asdsa");
        // Semaphore.OpenExisting();

        if (!createdNew)
        {
            Console.WriteLine("Another instance of the program is already running!");
            return;
        }

        Console.WriteLine("Successfully running the program!");
        Console.ReadLine();
    }

    private static async Task SemaphoreExample()
    {
        // Define a semaphore
        var semaphoreSlim = new SemaphoreSlim(3);

        // Define a list of tasks
        List<A> elements =
        [
            new A("a1"),
            new A("a2"),
            new A("a3"),
            new A("a4"),
            new A("a5")
        ];

        List<Task<string>> tasks = elements.Select(async element =>
            {
                try
                {
                    await semaphoreSlim.WaitAsync();
                    Console.WriteLine("Performing " + element.S);
                    return element.S;
                }
                finally
                {
                    semaphoreSlim.Release();
                }
            }
        ).ToList();

        // Perform operations on the resource
        await Task.WhenAll(tasks);
    }

    private static void TaskWithAction()
    {
        Task task = new Task(() => Console.WriteLine($"Hello World!"));
        task.Start();

        var run = Task.Run(() => { return "asda"; });

        var a1 = new A("a");
        a1.S = "Hello";

        var a2 = a1;
        a2.S = "World";

        Console.WriteLine(a1.S);
    }

    private static async Task<int> TaskExample2()
    {
        await Task.Delay(1000);
        return 1;
    }

    private static async Task<int> TaskExample()
    {
        var res = await TaskExample2();
        return res;
    }

    public static async Task Main(string[] args)
    {
        await TaskExample();
    }
}