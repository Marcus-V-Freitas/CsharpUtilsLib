namespace CsharpUtilsLib.External.Dictionaries.Models;

public sealed class EnglishDefinition
{
    [Display(Name = "Definition"), JsonPropertyName("definition")]
    public string Definition { get; set; }

    [Display(Name = "Synonyms"), JsonPropertyName("synonyms")]
    public List<string> Synonyms { get; set; }

    [Display(Name = "Antonyms"), JsonPropertyName("antonyms")]
    public List<string> Antonyms { get; set; }

    [Display(Name = "Example"), JsonPropertyName("example")]
    public string Example { get; set; }
}