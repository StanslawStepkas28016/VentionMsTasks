namespace EventsAndDelegates.ObserverV1;

class Customer : ICustomer
{
    public void Update(string? updateInfo)
    {
        Console.WriteLine(updateInfo);
    }
}