namespace CsharpUtilsLib.External.Currencies.Models;

public sealed class SearchCurrency
{
    [Display(Name = "Currency"), JsonPropertyName("currency")]
    public List<Currency> Currency { get; set; }
}