namespace CsharpUtilsLib.External.Dictionaries.Models;

public sealed class EnglishDictionary
{
    [Display(Name = "Word"), JsonPropertyName("word")]
    public string Word { get; set; }

    [Display(Name = "Phonetic"), JsonPropertyName("phonetic")]
    public string Phonetic { get; set; }

    [Display(Name = "Phonetics"), JsonPropertyName("phonetics")]
    public List<EnglishPhonetic> Phonetics { get; set; }

    [Display(Name = "Meanings"), JsonPropertyName("meanings")]
    public List<EnglishMeaning> Meanings { get; set; }

    [Display(Name = "License"), JsonPropertyName("license")]
    public EnglishLicense License { get; set; }

    [Display(Name = "Source Urls"), JsonPropertyName("sourceUrls")]
    public List<string> SourceUrls { get; set; }
}