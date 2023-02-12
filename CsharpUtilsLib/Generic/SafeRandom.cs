namespace CsharpUtilsLib.Generic;

public static class SafeRandom
{
    private static int _seedCount = 0;
    private static readonly ThreadLocal<Random> _random = new ThreadLocal<Random>(() => new Random(GenerateSeed()));

    private static int GenerateSeed()
    {
        return (int)((DateTime.Now.Ticks << 4) + Interlocked.Increment(ref _seedCount));
    }

    public static int Next()
    {
        return _random.Value!.Next();
    }

    public static int Next(int maxValue)
    {
        return _random.Value!.Next(maxValue);
    }
    public static int Next(int minValue, int maxValue)
    {
        return _random.Value!.Next(minValue, maxValue);
    }
}