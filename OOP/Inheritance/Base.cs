namespace OOP.Inheritance;

public class Base
{
    protected int Id { get; set; } = 25;
    protected  string SomeInfo { get; set; }

    public Base(int id, string someInfo)
    {
        Id = id;
        SomeInfo = someInfo;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null)
        {
            return false;
        }

        if (obj.GetType() != typeof(Base))
        {
            return false;
        }

        Base actual = (Base)obj;
        return Id == actual.Id && SomeInfo == actual.SomeInfo;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, SomeInfo);
    }

    public override string ToString()
    {
        return $"{nameof(Id)}: {Id}, {nameof(SomeInfo)}: {SomeInfo}";
    }
}