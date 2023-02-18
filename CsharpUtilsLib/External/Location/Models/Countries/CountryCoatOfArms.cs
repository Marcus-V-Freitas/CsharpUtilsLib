namespace CsharpUtilsLib.External.Location.Models.Countries;

public sealed class CountryCoatOfArms
{
    [JsonPropertyName("png")]
    public string PNG { get; set; }

    [JsonPropertyName("svg")]
    public string SVG { get; set; }
}