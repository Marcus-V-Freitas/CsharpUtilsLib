namespace CsharpUtilsLib.External.Inflations.Models;

public sealed class SearchInflation
{
    [Display(Name = "Inflation"), JsonPropertyName("inflation")]
    public List<Inflation> Inflation { get; set; }
}