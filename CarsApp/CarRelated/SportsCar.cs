namespace CarsApp.CarRelated;

public class SportsCar : Vehicle
{
    // Backing fields
    private double _topSpeed;
    private double _timeTo100Km;

    // Contraints
    private static double _minSpeedToSet;
    private static double _maxSpeedToSet;

    public double TopSpeed
    {
        get { return _topSpeed; }
        set
        {
            if (value < 0 || value > _maxSpeedToSet || value < _minSpeedToSet)
            {
                throw new ArgumentException($"{nameof(TopSpeed)} cannot be less than 0");
            }

            _topSpeed = value;
        }
    }

    public double TimeTo100Km
    {
        get { return _timeTo100Km; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException($"{nameof(TimeTo100Km)} cannot be less than 0");
            }

            _timeTo100Km = value;
        }
    }

    public SportsCar(string brandName, string modelName, EngineCylinderCount engineCylinderCount, double topSpeed,
        double timeTo100Km) : base(brandName, modelName, engineCylinderCount)
    {
        TopSpeed = topSpeed;
        TimeTo100Km = timeTo100Km;
    }

    static SportsCar()
    {
        _minSpeedToSet = 100;
        _maxSpeedToSet = 400;
    }

    public override void Drive()
    {
        Console.Out.WriteLine($"Going about {TopSpeed}!");
    }

    public new void DisplayingTestMethod()
    {
        Console.Out.WriteLine($"From {this.GetType().Name}");
    }

    protected bool Equals(SportsCar other)
    {
        return base.Equals(other) && _topSpeed.Equals(other._topSpeed) && _timeTo100Km.Equals(other._timeTo100Km);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((SportsCar)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), _topSpeed, _timeTo100Km);
    }

    public override string ToString()
    {
        return $"{base.ToString()}, {nameof(TopSpeed)}: {TopSpeed}, {nameof(TimeTo100Km)}: {TimeTo100Km}";
    }
}