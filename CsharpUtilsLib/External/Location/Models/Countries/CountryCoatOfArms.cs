namespace CsharpUtilsLib.External.Location.Models.Countries;

public sealed class CountryCoatOfArms
{
    [Display(Name = "PNG"), JsonPropertyName("png")]
    public string PNG { get; set; }

    [Display(Name = "SVG"), JsonPropertyName("svg")]
    public string SVG { get; set; }
}