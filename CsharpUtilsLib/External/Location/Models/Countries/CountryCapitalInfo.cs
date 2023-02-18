namespace CsharpUtilsLib.External.Location.Models.Countries;

public sealed class CountryCapitalInfo
{
    [JsonPropertyName("latlng")]
    public List<double> LatLng { get; set; }
}