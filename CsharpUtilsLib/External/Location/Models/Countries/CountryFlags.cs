namespace CsharpUtilsLib.External.Location.Models.Countries;

public sealed class CountryFlags
{
    [Display(Name = "PNG"), JsonPropertyName("png")]
    public string PNG { get; set; }

    [Display(Name = "SVG"), JsonPropertyName("svg")]
    public string SVG { get; set; }

    [Display(Name = "ALT"), JsonPropertyName("alt")]
    public string ALT { get; set; }
}