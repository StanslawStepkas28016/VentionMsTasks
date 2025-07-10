namespace OOP.Inheritance;

public class Derived : Base
{
    public string AdditionalInfo { get; set; }

    public Derived(int id, string someInfo, string additionalInfo) : base(id, someInfo)
    {
        AdditionalInfo = additionalInfo;
    }
    
    public override string ToString()
    {
        return $"{base.ToString()}, {nameof(AdditionalInfo)}: {AdditionalInfo}";
    }
}