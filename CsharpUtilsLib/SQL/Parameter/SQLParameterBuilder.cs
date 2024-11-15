namespace CsharpUtilsLib.SQL.Parameter;

public sealed class SQLParameterBuilder
{
    private readonly Dictionary<string, object> _parameters = new();

    public SQLParameterBuilder(string name, object value)
    {
        AddParameter(name, value);
    }

    public SQLParameterBuilder AddParameter(string name, object value)
    {
        _parameters.AddOrChangeValue(name, value);
        return this;
    }

    public Dictionary<string, object> Build()
    {
        return _parameters;
    }
}