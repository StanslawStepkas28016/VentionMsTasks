using System.Diagnostics;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonSerializer = System.Text.Json.JsonSerializer;

class Product
{
    public int IdProduct { get; set; }
    public string? Name { get; set; }

    public override string ToString()
    {
        return $"{nameof(IdProduct)}: {IdProduct}, {nameof(Name)}: {Name}";
    }
}

class Program
{
    public static void Main(string[] args)
    {
        // SystemTextJson();
        NewtonsoftJson();
    }

    private static void NewtonsoftJson()
    {
        // You can use this kind of object instead of "product"
        JObject jObject = new JObject()
        {
            { "IdProduct", 1 },
            { "Name", "Car" }
        };

        // You can also use a normal object
        var product = new Product()
        {
            IdProduct = 1,
            Name = "Car"
        };

        // Static method taking formatting options
        var serialized = JsonConvert.SerializeObject(product, Formatting.Indented);
        Console.WriteLine($"{serialized} \n");

        var deserialized = JsonConvert.DeserializeObject<Product>(serialized);
        Console.WriteLine(deserialized);

        // var declarativeApproach = new JObject(new JProperty("IdProduct", 1), new JProperty("Name", "Something"));
        // Console.WriteLine(declarativeApproach);
    }

    private static void SystemTextJson()
    {
        // Object initialization
        Product product = new Product { IdProduct = 1, Name = "Shampoo" };

        // Used for adjusting json
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            // This adds nice indents for readability
            WriteIndented = true
        };

        // Serialization
        string serializedProduct = JsonSerializer.Serialize(product, options);
        Console.WriteLine(serializedProduct);

        // Converted to a byte array
        byte[] serializedProductUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(product);

        foreach (var serializedProductUtf8Byte in serializedProductUtf8Bytes)
        {
            Console.Write($"{serializedProductUtf8Byte} ");
        }

        Console.WriteLine();

        // Writing a JSON to a file
        string directoryPath = Path.Combine("./Resources/");
        Directory.CreateDirectory(directoryPath);

        string productPath = Path.Combine(directoryPath, "product.json");
        File.WriteAllText(productPath, serializedProduct);

        // Reading a JSON from a file
        string text = File.ReadAllText(productPath);

        // If the JSON does not match it will leave those fields empty
        Product? productDeserialized = JsonSerializer.Deserialize<Product>(text);
        Console.WriteLine(productDeserialized);
    }
}

class MyStuff
{
    private static void Terminal()
    {
        var psi = new ProcessStartInfo();
        psi.FileName = "/Applications/iTerm.app/Contents/MacOS/iTerm2";
        psi.Arguments = "echo 12";
        psi.UseShellExecute = true;
        psi.CreateNoWindow = true;
        using var process = Process.Start(psi);
        process.WaitForExit();
        var output = process.StandardOutput.ReadToEnd();
        Console.WriteLine(output);

        Console.ReadKey();
    }
}