namespace CsharpUtilsLib.External.Tickers.Models;

public sealed class SearchTickers
{
    [Display(Name = "Results"), JsonPropertyName("results")]
    public List<Ticker> Results { get; set; }

    [Display(Name = "Requested At"), JsonPropertyName("requestedAt")]
    public DateTime? RequestedAt { get; set; }
}