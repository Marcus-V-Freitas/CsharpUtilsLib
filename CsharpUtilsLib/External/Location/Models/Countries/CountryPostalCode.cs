namespace CsharpUtilsLib.External.Location.Models.Countries;

public sealed class CountryPostalCode
{
    [Display(Name = "Format"), JsonPropertyName("format")]
    public string Format { get; set; }

    [Display(Name = "Regex"), JsonPropertyName("regex")]
    public string Regex { get; set; }
}