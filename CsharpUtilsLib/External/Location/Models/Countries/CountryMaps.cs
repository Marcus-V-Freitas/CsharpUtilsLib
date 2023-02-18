namespace CsharpUtilsLib.External.Location.Models.Countries;

public sealed class CountryMaps
{
    [JsonPropertyName("googleMaps")]
    public string GoogleMaps { get; set; }

    [JsonPropertyName("openStreetMaps")]
    public string OpenStreetMaps { get; set; }
}