namespace CsharpUtilsLib.External.Location.Models.Countries;

public sealed class CountryIdd
{
    [JsonPropertyName("root")]
    public string Root { get; set; }

    [JsonPropertyName("suffixes")]
    public List<string> Suffixes { get; set; }
}