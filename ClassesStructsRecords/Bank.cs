namespace BankCustomerV2
{
    // TASK 1: Define the AccountType enum
    // TASK 1: Step 1 - Define the AccountType enum
    // - Add an enum named AccountType with values like Checking, Savings, and Business.

    public enum AccountType
    {
        Checking,
        Savings,
        Business
    }

    // TASK 2: Define the Transaction struct
    // TASK 2: Step 1 - Define the Transaction struct
    // - Add a struct named Transaction with properties for Amount, Date, and Description.
    // - Add a constructor to initialize the properties.
    // - Override the ToString method to format transaction details.

    public readonly struct Transaction
    {
        public double Amount { get; }
        public DateTime Date { get; }
        public string Description { get; }

        public Transaction(double amount, DateTime date, string description)
        {
            Amount = amount;
            Date = date;
            Description = description;
        }

        public override string ToString()
        {
            return $"{Date.ToShortDateString()}: {Description} - {Amount:C}";
        }
    }

    // TASK 3: Define the Customer record
    // TASK 3: Step 1 - Define the Customer record
    // - Add a record named Customer with properties for Name, CustomerId, and Address.

    public record Customer(string Name, string CustomerId, string Address);

    public class BankAccount
    {
        // TASK 4: Implement the BankAccount class
        // TASK 4: Step 1 - Add properties for AccountNumber, Balance, AccountHolder, and Type.
        // TASK 4: Step 2 - Add a constructor to initialize the properties.
        // TASK 4: Step 3 - Add a method to deposit money into the account.
        // TASK 4: Step 4 - Add a method to withdraw money from the account.
        // TASK 4: Step 5 - Add a method to display account information.
        // TASK 4: Step 6 - Add a list to track transactions.
        // TASK 4: Step 7 - Add a method to add transactions to the list.
        // TASK 4: Step 8 - Add a method to display all transactions.

        public int AccountNumber { get; }
        public AccountType Type { get; }
        public Customer AccountHolder { get; private set; }
        public double Balance { get; private set; }
        private readonly List<Transaction> _transactions = new();

        public BankAccount(int accountNumber, AccountType type, Customer accountHolder, double balance)
        {
            AccountNumber = accountNumber;
            Type = type;
            AccountHolder = accountHolder;
            Balance = balance;
        }

        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
            }
        }

        public bool Withdraw(double amount)
        {
            if (amount > 0 && Balance >= amount)
            {
                Balance -= amount;
                return true;
            }

            return false;
        }

        public void AddTransaction(double amount, string description)
        {
            Balance += amount;
            _transactions.Add(new Transaction(amount, DateTime.Now, description));
        }

        public string DisplayAccountInfo()
        {
            return $"Account Number: {AccountNumber}, Balance: {Balance:C}";
        }

        public void DisplayTransactions()
        {
            Console.WriteLine("Transactions:");
            foreach (var transaction in _transactions)
            {
                Console.WriteLine(transaction);
            }
        }
    }
}