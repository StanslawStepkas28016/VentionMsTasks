using OOP.Inheritance;

namespace Modifiers.Inheritance;

public class Derived : Base
{
    public string AdditionalInfo { get; set; }

    public Derived(int id, string someInfo, string additionalInfo) : base(id, someInfo)
    {
        AdditionalInfo = additionalInfo;
    }
}