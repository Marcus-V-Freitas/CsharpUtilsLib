namespace CsharpUtilsLib.External.Location.Models.Countries;

public sealed class CountryMaps
{
    [Display(Name = "Google Maps"), JsonPropertyName("googleMaps")]
    public string GoogleMaps { get; set; }

    [Display(Name = "Open Street Maps"), JsonPropertyName("openStreetMaps")]
    public string OpenStreetMaps { get; set; }
}