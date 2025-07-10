namespace CarsApp.CarRelated;

public enum EngineCylinderCount
{
    V4,
    V6,
    V8,
    V12
}

public abstract class Vehicle
{
    private string _brandName;
    private string _modelName;
    private EngineCylinderCount _engineCylinderCount;

    public string BrandName
    {
        get { return _brandName; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"{nameof(BrandName)} cannot be null or empty");
            }

            _brandName = value;
        }
    }

    public string ModelName
    {
        get { return _modelName; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"{nameof(ModelName)} cannot be null or empty");
            }

            _modelName = value;
        }
    }

    public EngineCylinderCount EngineCylinderCount
    {
        get { return _engineCylinderCount; }
        set { _engineCylinderCount = value; }
    }

    protected Vehicle(string brandName, string modelName, EngineCylinderCount engineCylinderCount)
    {
        BrandName = brandName;
        ModelName = modelName;
        EngineCylinderCount = engineCylinderCount;
    }

    public abstract void Drive();

    protected bool Equals(Vehicle other)
    {
        return _brandName == other._brandName && _modelName == other._modelName &&
               _engineCylinderCount == other._engineCylinderCount;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Vehicle)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_brandName, _modelName, (int)_engineCylinderCount);
    }

    public override string ToString()
    {
        return
            $"{nameof(BrandName)}: {BrandName}, {nameof(ModelName)}: {ModelName}, {nameof(EngineCylinderCount)}: {EngineCylinderCount}";
    }
}