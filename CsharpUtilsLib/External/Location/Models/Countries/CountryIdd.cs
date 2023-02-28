namespace CsharpUtilsLib.External.Location.Models.Countries;

public sealed class CountryIdd
{
    [Display(Name = "Root"), JsonPropertyName("root")]
    public string Root { get; set; }

    [Display(Name = "Suffixes"), JsonPropertyName("suffixes")]
    public List<string> Suffixes { get; set; }
}