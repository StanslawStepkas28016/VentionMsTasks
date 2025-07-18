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
        
        IEnumerable<int> a = [1, 2, 3, 4, 5, 6];

        foreach (var i in a)
        {
            Console.Out.WriteLine(a.GetType());
        }

        Console.ReadKey();
    }
}

class MyCollection<T> : ICollection<T>
{
    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(T item)
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public bool Contains(T item)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public bool Remove(T item)
    {
        throw new NotImplementedException();
    }

    public int Count { get; }
    public bool IsReadOnly { get; }
}