namespace CarsApp.CarRelated;

public class FamilyCar : Vehicle
{
    private static int _safetyLevelMin;
    private static int _safetyLevelMax;
    private int _peopleCount;
    private int _safetyLevel;

    public int PeopleCount
    {
        get { return _peopleCount; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(PeopleCount)} cannot be negative");
            }

            _peopleCount = value;
        }
    }

    public int SafetyLevel
    {
        get { return _safetyLevel; }
        set
        {
            if (_safetyLevelMin > value
                || value > _safetyLevelMax)
            {
                throw new ArgumentOutOfRangeException(
                    $"{nameof(SafetyLevel)} cannot be less than {nameof(SafetyLevel)}");
            }

            _safetyLevel = value;
        }
    }

    static FamilyCar()
    {
        _safetyLevelMin = 1;
        _safetyLevelMax = 5;
    }

    public FamilyCar(string brandName, string modelName, EngineCylinderCount engineCylinderCount, int peopleCount,
        int safetyLevel) : base(brandName, modelName, engineCylinderCount)
    {
        PeopleCount = peopleCount;
        SafetyLevel = safetyLevel;
    }

    public override void Drive()
    {
        Console.Out.WriteLine($"Driving family car with {PeopleCount} people!");
    }

    protected bool Equals(FamilyCar other)
    {
        return base.Equals(other) && _peopleCount == other._peopleCount && _safetyLevel == other._safetyLevel;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((FamilyCar)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), _peopleCount, _safetyLevel);
    }

    public override string ToString()
    {
        return $"{base.ToString()}, {nameof(PeopleCount)}: {PeopleCount}, {nameof(SafetyLevel)}: {SafetyLevel}";
    }
}