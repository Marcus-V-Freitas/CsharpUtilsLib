namespace CsharpUtilsLib.External.NationalBrazilHolidays.Models;

public sealed class NationalBrazilHoliday
{
    [Display(Name = "Date"), JsonPropertyName("date")]
    public string Date { get; set; }

    [Display(Name = "Name"), JsonPropertyName("name")]
    public string Name { get; set; }

    [Display(Name = "Type"), JsonPropertyName("type")]
    public string Type { get; set; }
}