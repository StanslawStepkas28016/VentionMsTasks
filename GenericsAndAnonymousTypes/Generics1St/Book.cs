namespace Generics.Generics1St;

public class Book : IDescribable
{
    public string Description { get; set; }
    public DateTime TimePosted { get; set; }

    public Book(string description, DateTime timePosted)
    {
        Description = description;
        TimePosted = timePosted;
    }

    public override string ToString()
    {
        return $"{nameof(Description)}: {Description}, {nameof(TimePosted)}: {TimePosted}";
    }
}