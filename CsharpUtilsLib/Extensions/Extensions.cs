namespace CsharpUtilsLib.Extensions;

public static class Extensions
{
    private static readonly JsonSerializerOptions _cloneOptions = new()
    {
        ReferenceHandler = ReferenceHandler.Preserve,
        IncludeFields = true,
        NumberHandling = JsonNumberHandling.AllowReadingFromString |
                        JsonNumberHandling.WriteAsString,
        MaxDepth = 64,
        ReadCommentHandling = JsonCommentHandling.Skip,
        AllowTrailingCommas = true,
        PropertyNameCaseInsensitive = true,
        Converters = { new JsonStringEnumConverter() }
    };

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

    public static T Clone<T>(this object item)
    {
        string json = JsonSerializer.Serialize(item, _cloneOptions);
        return JsonSerializer.Deserialize<T>(json, _cloneOptions)!;
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