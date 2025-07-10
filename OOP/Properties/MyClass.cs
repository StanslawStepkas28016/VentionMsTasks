namespace OOP.Properties;

class MyClass
{
    // Backing field
    private int _myProp;

    public int MyProp
    {
        get => _myProp;
        set => _myProp = value;
    }

    public MyClass(int myProp)
    {
        this.MyProp = myProp;
    }

    // Copy constructor
    public MyClass(MyClass myClass)
    {
        this.MyProp = myClass.MyProp;
    }

    // Destructor
    ~MyClass()
    {
        Console.Out.WriteLine("Destructing the object");
    }
}