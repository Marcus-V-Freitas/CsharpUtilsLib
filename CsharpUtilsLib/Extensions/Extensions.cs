namespace CsharpUtilsLib.Extensions;

public static class Extensions
{
    public static T GetRandom<T>(this T[] source)
    {
        return source[SafeRandom.Next(source.Length)];
    }

    public static T With<T>(this T item, Action<T> action)
    {
        action(item);
        return item;
    }

    public static async Task With<T>(this T value, Func<T, Task> action)
    {
        await action(value);
    }

    public static T Clone<T>(this T item)
    {
        string json = JsonSerializer.Serialize(item);
        return JsonSerializer.Deserialize<T>(json)!;
    }

    public static Result ConvertTo<Result, Source>(this Source source, Result defaultValue = default!)
    {
        if (source == null || DBNull.Value.Equals(source))
        {
            return defaultValue;
        }

        try
        {
            Type type = typeof(Result);
            return (Result)Convert.ChangeType(source, Nullable.GetUnderlyingType(type) ?? type);
        }
        catch
        {
            return defaultValue;
        }
    }
}