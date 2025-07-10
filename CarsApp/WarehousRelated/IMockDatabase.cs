namespace CarsApp.WarehousRelated;

public interface IMockDatabase<T>
{
    List<T> Items { get; }
    void Connect();
    T Add(T t);
    bool Remove(in T t);
    void Disconnect();
}