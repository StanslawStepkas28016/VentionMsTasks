namespace Tuple;

class Program
{
    public static void Main(string[] args)
    {
        // Tuples();
        // Switch();
        Console.Out.WriteLine(int.MaxValue);
        int a = 2147483647;
        int b = 2147483647;

        int c = checked(a + b);
        Console.Out.WriteLine(c);
        
        
    }
    

    private static void Switch()
    {
        // Normal switch
        int a = 10;

        switch (a)
        {
            case 1:
                Console.Out.WriteLine(a + " something for 1");
                break;
            case 2:
                Console.Out.WriteLine(a + " something for 2");
                break;
            default:
                Console.Out.WriteLine("Invalid");
                break;
        }

        // Nested switch
        switch (a)
        {
            case 1:
                int input = int.Parse(Console.ReadLine()!);

                switch (input)
                {
                    case 5:
                        Console.Out.WriteLine("You picked option 1");
                        break;
                    default:
                        Console.Out.WriteLine("Exiting");
                        break;
                }

                break;
            case 2:
                Console.Out.WriteLine("No options for case 2 provided");
                break;
            default:
                Console.Out.WriteLine("Invalid");
                break;
        }
    }

    private static void Tuples()
    {
        // One method of creating
        var tuple1 = new Tuple<string, string, string>("e", "a", "a");

        // Another method of creating
        var tuple2 = System.Tuple.Create("a", 1, 2);
        Console.Out.WriteLine(tuple2.Item1 + " " + tuple2.Item1.GetType());
        Console.Out.WriteLine(tuple2.Item2 + " " + tuple2.Item2.GetType());
        Console.Out.WriteLine(tuple2.Item3 + " " + tuple2.Item3.GetType());

        Console.Out.WriteLine("---------------------");

        // Nested tuple
        var tuple3 = System.Tuple.Create("a", System.Tuple.Create("b", "c"));
        Console.Out.WriteLine(tuple3.Item1 + " " + tuple3.Item1.GetType());
        Console.Out.WriteLine(tuple3.Item2 + " " + tuple3.Item2.GetType());
        Console.Out.WriteLine(tuple3.Item2.Item1 + " " + tuple3.Item2.Item1.GetType());
        Console.Out.WriteLine(tuple3.Item2.Item2 + " " + tuple3.Item2.Item1.GetType());
    }
}