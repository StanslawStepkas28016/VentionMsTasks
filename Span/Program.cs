using System.Security.Cryptography;

namespace Span;

class Program
{
    public static void Main(string[] args)
    {
        // Expensive way
        string dateStr = "20.09.2003";
        var substring = dateStr.Substring(0, 2);

        Console.WriteLine(substring);

        // More efficient way
        string dateStr2 = "20.09.2005";
        
        // Can also do implicit conversion - ReadOnlySpan<char> span = dateStr2;
        ReadOnlySpan<char>
            span = dateStr2.AsSpan(); 
        
        var readOnlySpan = span.Slice(0, 2);

        Console.WriteLine(readOnlySpan.ToString());
    }
}