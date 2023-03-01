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
}