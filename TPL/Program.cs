class Program
{
    public static void Main(string[] args)
    {
        // You can specify the number of iterations
        // In this case 0 to 10 
        // Parallel.For(0, 10, i => { Console.WriteLine($"{i} is the current index"); });

        // You can also specify the amount of parallel iterations
        // In this case 2, so it will run 2 iterations at a time
        var parallelOptions = new ParallelOptions();
        parallelOptions.MaxDegreeOfParallelism = 2;
        parallelOptions.CancellationToken = new CancellationTokenSource(5).Token;

        try
        {
            string[] arr = ["mockObj1", "mockObj2", "mockObj3", "mockObj4", "mockObj5", "mockObj6", "mockObj7", "mockObj8", "mockObj9", "mockObj10"];

            Parallel.ForEach(arr, parallelOptions, (el =>
            {
                if (parallelOptions.CancellationToken.IsCancellationRequested)
                {
                    throw new OperationCanceledException(parallelOptions.CancellationToken);
                }

                Console.WriteLine(el);
            }));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}