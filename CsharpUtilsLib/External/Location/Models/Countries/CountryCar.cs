namespace CsharpUtilsLib.External.Location.Models.Countries;

public sealed class CountryCar
{
    [Display(Name = "Signs"), JsonPropertyName("signs")]
    public List<string> Signs { get; set; }

    [Display(Name = "Side"), JsonPropertyName("side")]
    public string Side { get; set; }
}