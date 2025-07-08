namespace DecoupleWithInterfaces;

public class Student : IPerson, IComparable<IPerson>
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; } = 0;
    public string Role => "Student";

    public void DisplayInfo()
    {
        Console.WriteLine($"Student Name: {Name}, Age: {Age}");
    }


    public int CompareTo(IPerson? obj)
    {
        if (obj == null) return 1;
        return this.Age.CompareTo(obj.Age);
    }
}