namespace CsharpUtilsLib.External.Temperatures.Models;

public sealed class Temperature
{
    [Display(Name = "Latitude"), JsonPropertyName("latitude")]
    public double? Latitude { get; set; }

    [Display(Name = "Longitude"), JsonPropertyName("longitude")]
    public double? Longitude { get; set; }

    [Display(Name = "Generation Time(ms)"), JsonPropertyName("generationtime_ms")]
    public double? GenerationtimeMs { get; set; }

    [Display(Name = "Utc Offset Seconds"), JsonPropertyName("utc_offset_seconds")]
    public int? UtcOffsetSeconds { get; set; }

    [Display(Name = "TimeZone"), JsonPropertyName("timezone")]
    public string Timezone { get; set; }

    [Display(Name = "TimeZone Abbreviation"), JsonPropertyName("timezone_abbreviation")]
    public string TimezoneAbbreviation { get; set; }

    [Display(Name = "Elevation"), JsonPropertyName("elevation")]
    public double? Elevation { get; set; }

    [Display(Name = "Hourly Units"), JsonPropertyName("hourly_units")]
    public HourlyUnits HourlyUnits { get; set; }

    [Display(Name = "Hourly"), JsonPropertyName("hourly")]
    public Hourly Hourly { get; set; }
}