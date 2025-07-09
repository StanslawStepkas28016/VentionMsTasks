using System.Runtime.InteropServices;

class Program
{
    public static void Main(string[] args)
    {
        // One method of creating
        var tuple1 = new Tuple<string, string, string>("e", "a", "a");

        // Another method of creating
        var tuple2 = Tuple.Create("a", 1, 2);
        Console.Out.WriteLine(tuple2.Item1 + " " + tuple2.Item1.GetType());
        Console.Out.WriteLine(tuple2.Item2 + " " + tuple2.Item2.GetType());
        Console.Out.WriteLine(tuple2.Item3 + " " + tuple2.Item3.GetType());

        Console.Out.WriteLine("---------------------");

        // Nested tuple
        var tuple3 = Tuple.Create("a", Tuple.Create("b", "c"));
        Console.Out.WriteLine(tuple3.Item1 + " " + tuple3.Item1.GetType());
        Console.Out.WriteLine(tuple3.Item2 + " " + tuple3.Item2.GetType());
        Console.Out.WriteLine(tuple3.Item2.Item1 + " " + tuple3.Item2.Item1.GetType());
        Console.Out.WriteLine(tuple3.Item2.Item2 + " " + tuple3.Item2.Item1.GetType());
    }
}