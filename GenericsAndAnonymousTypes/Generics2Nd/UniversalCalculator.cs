using System.Numerics;

namespace Generics.Generics2Nd;

public class UniversalCalculator
{
    // First variant
    // public T Add<T> (T val1, T val2) where T : INumber<T>
    // {
    // return val1 + val2;
    // }

    // Second variant, we can specify interfaces which need to be 
    // in within the <T> param
    public static T Add<T>(T val1, T val2) where T : INumber<T>
    {
        return val1 + val2;
    }
}