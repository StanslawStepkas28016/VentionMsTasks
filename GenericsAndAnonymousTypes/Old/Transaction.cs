namespace Generics.Old;

public struct Transaction
{
    public double Amount { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }

    public Transaction(double amount, DateTime date, string description)
    {
        Amount = amount;
        Date = date;
        Description = description;
    }

    public override string ToString()
    {
        return $"Amount: {Amount}, Date: {Date}, Description: {Description}";
    }
}