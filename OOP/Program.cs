using OOP.Inheritance;

namespace OOP;

class Program
{
    public static void Main(string[] args)
    {
        var b1 = new Base(1, "a");
        var b2 = new Base(1, "a");

        Console.Out.WriteLine(
            b1.GetHashCode()
        );
        
        Console.Out.WriteLine(
            b2.GetHashCode()
        );
    }
}