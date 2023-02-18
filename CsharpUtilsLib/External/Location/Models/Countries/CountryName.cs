namespace CsharpUtilsLib.External.Location.Models.Countries;

public sealed class CountryName
{
    [JsonPropertyName("common")]
    public string Common { get; set; }

    [JsonPropertyName("official")]
    public string Official { get; set; }

    [JsonPropertyName("nativeName")]
    public CountryNativeName NativeName { get; set; }
}