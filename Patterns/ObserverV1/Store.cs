namespace EventsAndDelegates.ObserverV1;

class Store
{
    public List<ICustomer> Customers { get; } = new();

    public void AddSubscriber(ICustomer customer)
    {
        Customers.Add(customer);
    }

    public void RemoveSubscriber(ICustomer customer)
    {
        Customers.Remove(customer);
    }

    public void NotifyAll(ref string? message)
    {
        foreach (var customer in Customers)
        {
            customer.Update(message);
        }
    }
}