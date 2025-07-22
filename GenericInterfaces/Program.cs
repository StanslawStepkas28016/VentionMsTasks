using System.Collections;
using System.Collections.Concurrent;

class Program
{
    public static void Main(string[] args)
    {
        // List<int> list = [1, 2, 3, 4, 5, 6];
        // ConcurrentBag<double> processed = [];

        // Parallel.ForEach(list, (num) => { processed.Add(num + 1); });
        // processed.ToList().ForEach(e => Console.Write($"{e} "));

        /*IEnumerable<int> a = [1, 2, 3, 4, 5, 6];

        foreach (var i in a)
        {
            Console.Out.WriteLine(a.GetType());
        }

        Console.ReadKey();*/

        var myEnumerable = new MyEnumerable<string>(["my", "enumerable"]);

        foreach (var str in myEnumerable)
        {
            Console.WriteLine(str);
        }
    }
}

class MyEnumerable<T> : IEnumerable<T>
{
    public T[] Array { get; set; }

    public MyEnumerable(T[] array)
    {
        Array = array;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new MyEnumerator<T>(Array);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class MyEnumerator<T> : IEnumerator<T>
{
    public T[] Array { get; set; }
    private int _position;

    public MyEnumerator(T[] array)
    {
        _position = -1;
        Array = array;
    }

    public bool MoveNext()
    {
        _position++;
        return _position < Array.Length;
    }

    public void Reset()
    {
        _position = -1;
    }

    public T Current => Array[_position];

    object? IEnumerator.Current => Current;

    public void Dispose()
    {
        Console.WriteLine("Disposing the enumerator!");
    }
}