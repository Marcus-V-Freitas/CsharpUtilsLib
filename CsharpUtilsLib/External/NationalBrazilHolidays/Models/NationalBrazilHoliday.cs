namespace CsharpUtilsLib.External.NationalBrazilHolidays.Models;

public sealed class NationalBrazilHoliday
{
    [JsonPropertyName("date")]
    public string Date { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }
}