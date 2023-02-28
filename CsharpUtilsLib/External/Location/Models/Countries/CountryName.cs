namespace CsharpUtilsLib.External.Location.Models.Countries;

public sealed class CountryName
{
    [Display(Name = "Common"), JsonPropertyName("common")]
    public string Common { get; set; }

    [Display(Name = "Official"), JsonPropertyName("official")]
    public string Official { get; set; }

    [Display(Name = "Native Name"), JsonPropertyName("nativeName")]
    public CountryNativeName NativeName { get; set; }
}