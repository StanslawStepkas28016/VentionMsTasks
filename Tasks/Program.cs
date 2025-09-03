class Program
{
    public static async Task Main(string[] args)
    {
        List<Task<string>> tasks =
        [
            Met("1"),
            Met("2"),
            Met("3"),
            Met("4"),
        ];

        await Task.WhenAll(tasks);

        /*var task = new Task();
        var run = Task.Run();
        task.Start(
            );

        Parallel.ForEachAsync(tasks)*/

        // Tasks par


        // var cancellationTokenSource = new CancellationTokenSource();
        
        // cancellationTokenSource.CancelAfter(TimeSpan.FromSeconds(1));
        
        // await CancellationTest(cancellationTokenSource.Token);
    }

    public async static Task CancellationTest(CancellationToken token)
    {
        while (true)
        {
            Console.WriteLine("No cancellation requested");

            if (token.IsCancellationRequested)
            {
                Console.WriteLine("Cancellation was requested");
                return;
            }
        }
    }

    public static SemaphoreSlim semaphore = new SemaphoreSlim(2);

    private static int counter = 0;

    static async Task<string> Met(string str)
    {
        await semaphore.WaitAsync();
        Console.WriteLine(++counter);
        await Task.Delay(15);
        Console.WriteLine(--counter);
        semaphore.Release();
        return str;
    }

    private static async Task MethodsV1()
    {
        List<Task> tasks = [Task1(), Task2()];

        await Task.WhenAll(tasks);
    }


    static object _lockObject = new object();

    private static int a = 10;

    public static void AccessingSharedResource()
    {
        lock (_lockObject)
        {
            a += 1;
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        }
    }

    public static async Task Task1()
    {
        await Task.Delay(500);
        Console.WriteLine("Task " + Thread.CurrentThread.ManagedThreadId);
        AccessingSharedResource();
    }


    public static async Task Task2()
    {
        await Task.Delay(500);
        Console.WriteLine("Task " + Thread.CurrentThread.ManagedThreadId);
        AccessingSharedResource();
    }
}