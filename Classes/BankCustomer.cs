namespace BankCustomer;

public class BankCustomer
{
    public string FirstName = "Tim";
    public string LastName = "Shao";
    public readonly string CustomerId;
    public static int s_nextCustomerId;

    public BankCustomer()
    {
        this.CustomerId = (s_nextCustomerId++).ToString("D10");
    }

    static BankCustomer()
    {
        Random random = new Random();
        s_nextCustomerId = random.Next(10000000, 20000000);
    }

    public BankCustomer(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        this.CustomerId = (s_nextCustomerId++).ToString("D10");
    }
}