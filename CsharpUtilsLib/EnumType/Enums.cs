namespace CsharpUtilsLib.EnumType;

public static class Enums
{
    public static Dictionary<int, string> GetEnumValuesAndNames<T>(string filter) where T : struct, Enum
    {
        var enumDic = Enum.GetValues(typeof(T)).Cast<T>().ToDictionary(e => Convert.ToInt32(e), e => e.ToString());

        if (!string.IsNullOrEmpty(filter))
        {
            return enumDic.Where(x => x.Value.Contains(filter)).ToDictionary(x => x.Key, x => x.Value);
        }

        return enumDic;
    }

    public static List<int> GetEnumValues<T>(string filter) where T : struct, Enum
    {
        try
        {
            var enumDic = Enum.GetValues(typeof(T)).Cast<T>().ToDictionary(e => Convert.ToInt32(e), e => e.ToString());

            if (!string.IsNullOrEmpty(filter))
            {
                return enumDic.Where(x => x.Value.Contains(filter)).Select(x => x.Key).ToList();
            }

            return enumDic.Select(x => x.Key).ToList();
        }
        catch { }
        return null!;
    }

    public static string GetDisplayName(this Enum enumValue)
    {
        return enumValue.GetType()
                        .GetMember(enumValue.ToString())
                        .FirstOrDefault()!
                        .GetCustomAttribute<DisplayAttribute>()!
                        .GetName()!;
    }

    public static string GetEnumName<T>(this T enumValue) where T : Enum
    {
        return Enum.GetName(typeof(T), enumValue)!;
    }

    public static int GetEnumValue<T>(this T enumValue) where T : Enum
    {
        if (!typeof(int).IsAssignableFrom(Enum.GetUnderlyingType(typeof(T))))
        {
            return default;
        }

        return Convert.ToInt32(enumValue);
    }
}