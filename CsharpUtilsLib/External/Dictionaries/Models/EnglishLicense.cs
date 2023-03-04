namespace CsharpUtilsLib.External.Dictionaries.Models;

public sealed class EnglishLicense
{
    [Display(Name = "Name"), JsonPropertyName("name")]
    public string Name { get; set; }

    [Display(Name = "Url"), JsonPropertyName("url")]
    public string Url { get; set; }
}