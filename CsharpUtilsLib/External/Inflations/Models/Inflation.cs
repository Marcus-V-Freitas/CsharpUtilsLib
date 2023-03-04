namespace CsharpUtilsLib.External.Inflations.Models;

public sealed class Inflation
{
    [Display(Name = "Date"), JsonPropertyName("date")]
    public string Date { get; set; }

    [Display(Name = "Value"), JsonPropertyName("value")]
    public string Value { get; set; }

    [Display(Name = "Epoch Date"), JsonPropertyName("epochDate")]
    public long? EpochDate { get; set; }
}