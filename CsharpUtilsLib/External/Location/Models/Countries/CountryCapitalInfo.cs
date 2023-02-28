namespace CsharpUtilsLib.External.Location.Models.Countries;

public sealed class CountryCapitalInfo
{
    [Display(Name = "Lat/Lng"), JsonPropertyName("latlng")]
    public List<double> LatLng { get; set; }
}