namespace Generics;

public class Item<T> where T : IDescribable
{
    public T Data { get; set; }

    public Item(T data)
    {
        Data = data;
    }
    
    public override string ToString()
    {
        return $"{nameof(Data)}: {Data}";
    }
}