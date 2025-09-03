using System.Collections;

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

        /*
        var myEnumerable = new MyEnumerable<string>(["my", "enumerable"]);

        foreach (var str in myEnumerable)
        {
            Console.WriteLine(str);
        }*/

        /*Object p1 = new Person() { Id = 3412 };
        Object p2 = new Person() { Id = 5 };
        Object p3 = new Person() { Id = 0 };

        List<Person> list = [(Person)p1, (Person)p2, (Person)p3];
        list.Sort();
        list.ForEach(Console.WriteLine);*/


        NewMethod();
        NewMethod2();
    }

    private static void NewMethod()
    {
        Dictionary<string, int> dict = new Dictionary<string, int>()
        {
            { "Hello", 1 },
            { "World", 2 }
        };

        // Get value for a specified key
        int i = dict["Hello"];

        // Set a value at a specified key
        dict["World"] = 3;

        // Obtain keys (as the name suggests, a ICollection)
        Dictionary<string, int>.KeyCollection keyCollection = dict.Keys;

        // Obtain values (as the name suggests, a ICollection)
        Dictionary<string, int>.ValueCollection valueCollection = dict.Values;

        // Iterate through the dictionary
        foreach (var keyValuePair in dict)
        {
            Console.WriteLine($"{keyValuePair.Key} : {keyValuePair.Value}");
        }
    }

    private static void NewMethod2()
    {
        var arrayList = new ArrayList();

        arrayList.Add(1);
        arrayList.Add(2);
        arrayList.Add("Because I can do that is it not type safe!");

        foreach (int element in arrayList)
        {
            Console.WriteLine(element);
        }
    }
}

class Person : IEquatable<Person>, IComparable<Person>
{
    public int Id { get; init; }

    public bool Equals(Person? other)
    {
        return Id == other!.Id;
    }

    public int CompareTo(Person? other)
    {
        if (other == null) return 1;
        return Id.CompareTo(other.Id);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Person)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }

    public override string ToString()
    {
        return $"{nameof(Id)}: {Id}";
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
    // An array for storing elements which are going to be iterated through
    public T[] Array { get; set; }

    // Current position index
    private int _position;

    // When creating assing the _position to -1, to ensure
    // increments work right
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

    // Used in IEnumerable, uses the prop above
    object? IEnumerator.Current => Current;

    public void Dispose()
    {
        Console.WriteLine("Disposing the enumerator!");
    }
}