namespace EventsAndDelegates.Observer;

class Customer : ICustomer
{
    public void Update(string? updateInfo)
    {
        Console.WriteLine(updateInfo);
    }
}