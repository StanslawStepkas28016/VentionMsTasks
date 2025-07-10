using Generics.Generics1St;
using Generics.Generics2Nd;
using Generics.Old;

namespace Generics;

public class Program
{
    public enum Test
    {
        A, // 0
        B, // 1
        C = 7,
        D, // 8
    }

    public static void Main(string[] args)
    {
        // Generics1St();
        Generics2Nd();
    }

    private static void Generics2Nd()
    {
        // var universalCalculator = new UniversalCalculator<double>();
        // var res = universalCalculator.Add(1.2, 2);
        // Console.Out.WriteLine(res.GetType());
        // Console.Out.WriteLine(res);

        UniversalCalculator.Add<int>(1, 1);
    }
    
    private static void Generics1St()
    {
        // Generic with Generic Interfaces
        var item = new Item<Book>(new Book("desc", DateTime.UtcNow));
        Console.Out.WriteLine(item);

        // Anonymous type
        var anon = new
        {
            Desc = item.Data.Description,
            SomeOtherProperty = "SomeOtherProperty"
        };

        Console.Out.WriteLine(anon.Desc + " " + anon.SomeOtherProperty);
    }

    private static void Old()
    {
        Customer customer = new Customer
        {
            Name = "John Doe",
            CustomerId = "C12345",
            Address = "123 Main St"
        };

        BankAccount account = new BankAccount(12345678, 500, customer, AccountType.Checking);

        Console.WriteLine(account.DisplayAccountInfo());
    }
}