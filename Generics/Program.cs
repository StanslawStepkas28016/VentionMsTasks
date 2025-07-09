public class Program
{
    public static void Main(string[] args)
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