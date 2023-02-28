namespace CsharpUtilsLib.External.ISBNs.Models;

public sealed class Dimensions
{
    [Display(Name = "Width"), JsonPropertyName("width")]
    public double Width { get; set; }

    [Display(Name = "Height"), JsonPropertyName("height")]
    public double Height { get; set; }

    [Display(Name = "Unit"), JsonPropertyName("unit")]
    public string Unit { get; set; }
}