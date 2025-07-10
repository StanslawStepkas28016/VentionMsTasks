namespace Generics.Old;

public enum AccountType
{
    Checking,
    Savings,
    Business
}

public class BankAccount
{
    public int AccountNumber { get; }
    public double Balance { get; private set; }
    public Customer AccountHolder { get; }
    public AccountType Type { get; }

    private List<Transaction> _transactions = new();

    public BankAccount(int accountNumber, double balance, Customer accountHolder, AccountType type)
    {
        AccountNumber = accountNumber;
        Balance = balance;
        AccountHolder = accountHolder;
        Type = type;
    }

    public void Deposit(double amount, string description)
    {
        if (amount > 0)
        {
            Balance += amount;
            _transactions.Add(new Transaction(amount, DateTime.Now, description));
        }
    }

    public bool Withdraw(double amount, string description)
    {
        if (amount > 0 && Balance >= amount)
        {
            Balance -= amount;
            _transactions.Add(new Transaction(-amount, DateTime.Now, description));
            return true;
        }

        return false;
    }
    
    public void DisplayTransactions()
    {
        Console.WriteLine("Transaction History:");
        foreach (var transaction in _transactions)
        {
            Console.WriteLine(transaction);
        }
    }
    
    public string DisplayAccountInfo()
    {
        return $"Account Number: {AccountNumber}, Balance: {Balance:C}, Account Holder: {AccountHolder.Name}, Type: {Type}";
    }
}