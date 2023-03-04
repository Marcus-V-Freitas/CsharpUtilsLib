namespace CsharpUtilsLib.External.Dictionaries.Models;

public sealed class EnglishPhonetic
{
    [Display(Name = "Text"), JsonPropertyName("text")]
    public string Text { get; set; }

    [Display(Name = "Audio"), JsonPropertyName("audio")]
    public string Audio { get; set; }

    [Display(Name = "Source Url"), JsonPropertyName("sourceUrl")]
    public string SourceUrl { get; set; }

    [Display(Name = "License"), JsonPropertyName("license")]
    public EnglishLicense License { get; set; }
}