namespace CsharpUtilsLib.External.Location.Models.Countries;

public sealed class CountryFlags
{
    [JsonPropertyName("png")]
    public string PNG { get; set; }

    [JsonPropertyName("svg")]
    public string SVG { get; set; }

    [JsonPropertyName("alt")]
    public string ALT { get; set; }
}