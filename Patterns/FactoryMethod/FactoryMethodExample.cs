namespace EventsAndDelegates.FactoryMethod;

interface IFirstInterface
{
    void DoSomething();
}

interface ISecondInterface
{
    void DoSomething();
    
}
public class FactoryMethodExample : IFirstInterface, ISecondInterface
{
    public Guid IdItem { get; set; }
    public string Description { get; set; }

    public static FactoryMethodExample Create(string description)
    {
        return new FactoryMethodExample
        {
            IdItem = Guid.NewGuid(),
            Description = description
        };
    }

    void IFirstInterface.DoSomething()
    {
        throw new NotImplementedException();
    }

    void ISecondInterface.DoSomething()
    {
        throw new NotImplementedException();
    }
}