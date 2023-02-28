namespace CsharpUtilsLib.External.Location.Models.Countries;

public sealed class CountryCurrency
{
    [Display(Name = "Name"), JsonPropertyName("name")]
    public string Name { get; set; }

    [Display(Name = "Symbol"), JsonPropertyName("symbol")]
    public string Symbol { get; set; }
}