namespace CsharpUtilsLib.External.Tickers.Models;

public sealed class HistoricalDataPrice
{
    [Display(Name = "Date"), JsonPropertyName("date")]
    public int? Date { get; set; }

    [Display(Name = "Open"), JsonPropertyName("open")]
    public double? Open { get; set; }

    [Display(Name = "High"), JsonPropertyName("high")]
    public double? High { get; set; }

    [Display(Name = "Low"), JsonPropertyName("low")]
    public double? Low { get; set; }

    [Display(Name = "Close"), JsonPropertyName("close")]
    public double? Close { get; set; }

    [Display(Name = "Volume"), JsonPropertyName("volume")]
    public int? Volume { get; set; }
}