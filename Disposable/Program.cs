using System.Collections;

class Program
{
    public static void Main(string[] args)
    {
        
    }
}

class MyClass
{
    public string Name { get; set; }
}

class MyCollection<T> : ICollection<T>
{
    public List<T> Container { get; set; } = new();

    public IEnumerator<T> GetEnumerator()
    {
        return Container.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(T item)
    {
        Container.Add(item);
    }

    public void Clear()
    {
        Container.Clear();
    }

    public bool Contains(T item)
    {
        return Container.Contains(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        array.CopyTo(Container.ToArray(), arrayIndex);
    }

    public bool Remove(T item)
    {
        return Container.Remove(item);
    }

    public int Count { get; }
    public bool IsReadOnly { get; }
}