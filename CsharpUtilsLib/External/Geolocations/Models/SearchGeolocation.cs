namespace CsharpUtilsLib.External.Geolocations.Models;

public sealed class SearchGeolocation
{
    [Display(Name = "Results"), JsonPropertyName("results")]
    public List<Geolocation> Results { get; set; }

    [Display(Name = "Generation Time (ms)"), JsonPropertyName("generationtime_ms")]
    public double? GenerationtimeMs { get; set; }
}