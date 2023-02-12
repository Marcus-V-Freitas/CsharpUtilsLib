namespace CsharpUtilsLib.Extensions;

public static class Extensions
{
    public static T DefaultConstructor<T>() where T : class
    {
        Type type = typeof(T);
        return (T)Activator.CreateInstance(type, true)!;
    }

    public static object GetPropertyValue(this object source, string propertyName)
    {
        return source.GetType().GetProperty(propertyName)?.GetValue(source, null)!;
    }

    public static string GetStringPropertyValue(this object source, string propertyName)
    {
        var property = source.GetPropertyValue(propertyName);
        return (property == null ? string.Empty : property.ToString())!;
    }

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
}