namespace BankCustomerV2
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Bank App!");

            // TASK 5: Display Basic Bank Account Information
            // TASK 5: Step 1 - Create a BankAccount object.
            BankAccount account = new BankAccount(12345678, AccountType.Checking,
                new Customer("John Doe", "12312", "Mainstreet 23rd"), 500);
            // TASK 5: Step 2 - Call the DisplayAccountInfo method to output account details.
            Console.WriteLine(account.DisplayAccountInfo());
            
            // TASK 6: Perform Transactions
            // TASK 6: Step 1 - Call the Deposit method to add money to the account.
            // TASK 6: Step 2 - Call the Withdraw method to subtract money from the account.
            // TASK 6: Step 3 - Display the updated account information after each transaction.

            // Perform a deposit
            Console.WriteLine("After deposit:");
            account.Deposit(200);
            Console.WriteLine(account.DisplayAccountInfo());

            // Perform a withdrawal
            bool success = account.Withdraw(100);
            Console.WriteLine(success ? "Withdrawal successful." : "Withdrawal failed.");
            Console.WriteLine("After withdrawal:");
            Console.WriteLine(account.DisplayAccountInfo());

            // TASK 7: Display Transaction History
            // TASK 7: Step 1 - Call the DisplayTransactions method to output the list of transactions.

            Console.WriteLine("Features to be implemented...");

            // TASK 8: Demonstrate Record Comparison
            // TASK 8: Step 1 - Create two Customer objects with identical properties.
            var customer1 = new Customer("John", "123", "Prosta 67");
            var customer2 = new Customer("John", "123", "Prosta 67");
            // TASK 8: Step 2 - Compare the two Customer objects using the == operator.
            Console.Out.WriteLine(customer1 == customer2);

            // TASK 9: Demonstrate Immutability of Structs
            // TASK 9: Step 1 - Create a Transaction object.
            var transactionStruct = new Transaction(200, DateTime.Now, "blah blah blah");
            // transactionStruct.Amount = 200; // Here is the immutability, I cannot change the amount
            transactionStruct = new Transaction(100, DateTime.Now, "blah blah blah"); // However I can still change the value of this struct
            // TASK 9: Step 2 - Display the transaction details using the ToString method.
            Console.Out.WriteLine(transactionStruct); // No need to say ToString() explicitly
        }
    }
}