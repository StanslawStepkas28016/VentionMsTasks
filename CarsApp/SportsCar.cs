namespace CarsApp;

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
}