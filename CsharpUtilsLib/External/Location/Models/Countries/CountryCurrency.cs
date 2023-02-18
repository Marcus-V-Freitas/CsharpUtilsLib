namespace CsharpUtilsLib.External.Location.Models.Countries;

public sealed class CountryCurrency
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }
}