namespace BankCustomer;

public class BankAccount
{
    public int AccountNumber;
    public double Balance = 0;
    public static double InterestRate;
    public string AccountType = "Checking";
    public readonly string CustomerId;
    public static int s_nextAccountNumber = 1;

    static BankAccount()
    {
        Random random = new Random();
        s_nextAccountNumber = random.Next(10000000, 20000000);
        InterestRate = 0;
    }

    public BankAccount(string customerId)
    {
        AccountNumber = s_nextAccountNumber++;
        CustomerId = customerId;
    }

    public BankAccount(string customerId, double balance, string accountType)
    {
        AccountNumber = s_nextAccountNumber++;
        Balance = balance;
        AccountType = accountType;
        CustomerId = customerId;
    }
}