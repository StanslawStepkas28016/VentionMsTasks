namespace CarsApp;

public enum EngineCylinderCount
{
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
}