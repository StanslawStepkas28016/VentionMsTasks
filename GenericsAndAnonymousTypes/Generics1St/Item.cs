namespace Generics.Generics1St;

public class Item<T> where T : IDescribable
{
    public T Data { get; private set; }
    // Consumer types, producer types

    public Item(T data)
    {
        Data = data;
    }

    public T GetItem<K>(K myArg)
    {
        Console.Out.WriteLine(myArg!.GetType() + " is the type");
        return Data;
    }

    public override string ToString()
    {
        return $"{nameof(Data)}: {Data}";
    }
}