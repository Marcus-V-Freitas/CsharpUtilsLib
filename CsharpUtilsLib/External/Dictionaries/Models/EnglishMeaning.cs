namespace CsharpUtilsLib.External.Dictionaries.Models;

public sealed class EnglishMeaning
{
    [Display(Name = "Part Of Speech"), JsonPropertyName("partOfSpeech")]
    public string PartOfSpeech { get; set; }

    [Display(Name = "Definitions"), JsonPropertyName("definitions")]
    public List<EnglishDefinition> Definitions { get; set; }

    [Display(Name = "Synonyms"), JsonPropertyName("synonyms")]
    public List<string> Synonyms { get; set; }

    [Display(Name = "Antonyms"), JsonPropertyName("antonyms")]
    public List<string> Antonyms { get; set; }
}