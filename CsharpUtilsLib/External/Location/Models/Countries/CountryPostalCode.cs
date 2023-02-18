namespace CsharpUtilsLib.External.Location.Models.Countries;

public sealed class CountryPostalCode
{
    [JsonPropertyName("format")]
    public string Format { get; set; }

    [JsonPropertyName("regex")]
    public string Regex { get; set; }
}