using System.Collections.Concurrent;
using System.Collections.Immutable;

class Program
{
    public static void Main(string[] args)
    {
        // PriorityQueue();
        // Dictionary();
        // ConcurrentDictionary();

        // ImmutableListE();

        var sortedList = new SortedList<string, int>();
        sortedList.Add("A", 1);
        sortedList.Add("D", 4);
        sortedList.Add("B", 2);
        sortedList.Add("C", 3);
        
        sortedList.RemoveAt(1);
        // sortedList.GetKeyAtIndex();

        // sortedList.RemoveAt(1);
        
        for (var i = 0; i < sortedList.Count; i++)
        {
            Console.WriteLine(sortedList.Keys[i]);
        }

        // Console.WriteLine(sortedList.TryGetValue("a", out var val));
        // Console.WriteLine(val);
    }

    private static void ImmutableListE()
    {
        // Creating an empty list
        ImmutableList<string> originalList =
            System.Collections.Immutable.ImmutableList.Create("element 0", "element 1");

        // Adding element to the original list,
        // results in a copied list with the new elements, being created
        var newList = originalList.AddRange(["element 2", "element 3"]);

        foreach (var element in originalList)
        {
            Console.WriteLine(element);
        }

        Console.WriteLine("==============");

        foreach (var element in newList)
        {
            Console.WriteLine(element);
        }
    }

    private static void Dictionary()
    {
        var dictionary = new Dictionary<string, string>();

        dictionary.Add("El", "asdasd");
        var tryAdd = dictionary.TryAdd("asdas", "123123");
        Console.WriteLine(tryAdd);

        // var remove = dictionary.Remove("El");
        // Console.WriteLine(remove);

        dictionary.TryGetValue("El", out var value);
        Console.WriteLine(value);

        Console.WriteLine(
            dictionary["El"]
        );

        foreach (var keyValuePair in dictionary)
        {
            Console.WriteLine($"key: {keyValuePair.Key}, value: {keyValuePair.Value}");
        }
    }

    private static void ConcurrentDictionary()
    {
        // Regular declaration
        var concurrentDictionary = new ConcurrentDictionary<string, string>();

        // Adding an element
        concurrentDictionary.TryAdd("hello", "world");

        // Adding an element and "appending the previous elements value"
        concurrentDictionary.AddOrUpdate("hello", "world", (k, v) => k + " " + v + ", updated");

        // Updating 
        concurrentDictionary.TryAdd("hi", "world");
        concurrentDictionary.TryUpdate("hi", "bye", "world"); // Need to use "world" as the previous value

        concurrentDictionary.GetOrAdd("asd", "sada");

        foreach (var keyValuePair in concurrentDictionary)
        {
            Console.WriteLine($"key: {keyValuePair.Key}, value: {keyValuePair.Value}");
        }
    }

    private static void PriorityQueue()
    {
        PriorityQueue<string, string> myPrimaryQueue = new PriorityQueue<string, string>(
            Comparer<string>.Create((x, y) => x.Length.CompareTo(y.Length))
        );

        myPrimaryQueue.Enqueue("Contents 1", "aaaaaaa");
        myPrimaryQueue.Enqueue("Contents 2", "aa");
        myPrimaryQueue.Enqueue("Contents 3", "aaaaaaaaaaaa");


        while (myPrimaryQueue.Count != 0)
        {
            Console.WriteLine(myPrimaryQueue.Dequeue());
        }
    }
}