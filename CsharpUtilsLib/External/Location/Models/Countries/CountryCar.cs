namespace CsharpUtilsLib.External.Location.Models.Countries;

public sealed class CountryCar
{
    [JsonPropertyName("signs")]
    public List<string> Signs { get; set; }

    [JsonPropertyName("side")]
    public string Side { get; set; }
}