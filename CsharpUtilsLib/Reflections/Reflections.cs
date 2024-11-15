namespace CsharpUtilsLib.Reflections;

public static class Reflections
{
    public static string GetDisplayName(this PropertyInfo property)
    {
        return (property.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute)?.Name!;
    }

    public static T DefaultConstructor<T>() where T : class
    {
        Type type = typeof(T);
        return (T)Activator.CreateInstance(type, true)!;
    }

    public static object CreateInstance(this Type type)
    {
        var constructorInfo = type.GetConstructor(Type.EmptyTypes);
        if (constructorInfo == null)
        {
            throw new ArgumentException($"Type '{type.Name}' does not have a parameterless constructor.");
        }
        return constructorInfo.Invoke(null);
    }

    public static object CreateInstance(this Type type, params object[] args)
    {
        var constructorInfo = type.GetConstructor(args.Select(arg => arg.GetType()).ToArray());
        if (constructorInfo == null)
        {
            throw new ArgumentException($"Type '{type.Name}' does not have a constructor with the specified parameter types.");
        }
        return constructorInfo.Invoke(args);
    }

    public static object InvokeMethod(this object obj, string methodName, object[] args)
    {
        Type objType = obj.GetType();
        MethodInfo method = objType.GetMethod(methodName)!;
        return method.Invoke(obj, args)!;
    }

    public static void SetPropertyValue(this object obj, string propertyName, object value)
    {
        Type objType = obj.GetType();
        PropertyInfo property = objType.GetProperty(propertyName, GetBindingFlags)!;
        property.SetValue(obj, value);
    }

    public static object GetPropertyValue(this object obj, string propertyName)
    {
        Type objType = obj.GetType();
        PropertyInfo property = objType.GetProperty(propertyName, GetBindingFlags)!;
        return property.GetValue(obj)!;
    }

    public static string GetStringPropertyValue(this object source, string propertyName)
    {
        var property = source.GetPropertyValue(propertyName);
        return (property == null ? string.Empty : property.ToString())!;
    }

    public static void SetFieldValue(this object obj, string fieldName, object value)
    {
        Type objType = obj.GetType();
        FieldInfo field = objType.GetField(fieldName, GetBindingFlags)!;
        field.SetValue(obj, value);
    }

    public static object GetFieldValue(this object obj, string fieldName)
    {
        Type objType = obj.GetType();
        FieldInfo field = objType.GetField(fieldName, GetBindingFlags)!;
        return field.GetValue(obj)!;
    }

    public static string GetStringFieldValue(this object source, string fieldName)
    {
        var field = source.GetFieldValue(fieldName);
        return (field == null ? string.Empty : field.ToString())!;
    }

    public static string GetFullTypeName(this Type type)
    {
        return $"{type.Namespace}.{type.Name}";
    }

    public static bool HasPropertyOrField(this object obj, string name)
    {
        return obj.GetType().GetProperty(name, GetBindingFlags) != null || obj.GetType().GetField(name) != null;
    }

    private static BindingFlags GetBindingFlags => BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.IgnoreCase;
}