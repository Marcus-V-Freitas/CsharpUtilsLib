namespace CsharpUtilsLib.External.Currencies.Models;

public sealed class Currency
{
    [Display(Name = "From Currency"), JsonPropertyName("fromCurrency")]
    public string FromCurrency { get; set; }

    [Display(Name = "To Currency"), JsonPropertyName("toCurrency")]
    public string ToCurrency { get; set; }

    [Display(Name = "Name"), JsonPropertyName("name")]
    public string Name { get; set; }

    [Display(Name = "High"), JsonPropertyName("high")]
    public string High { get; set; }

    [Display(Name = "Low"), JsonPropertyName("low")]
    public string Low { get; set; }

    [Display(Name = "Bid Variation"), JsonPropertyName("bidVariation")]
    public string BidVariation { get; set; }

    [Display(Name = "Percentage Change"), JsonPropertyName("percentageChange")]
    public string PercentageChange { get; set; }

    [Display(Name = "Bid Price"), JsonPropertyName("bidPrice")]
    public string BidPrice { get; set; }

    [Display(Name = "Ask Price"), JsonPropertyName("askPrice")]
    public string AskPrice { get; set; }

    [Display(Name = "Updated At Timestamp"), JsonPropertyName("updatedAtTimestamp")]
    public string UpdatedAtTimestamp { get; set; }

    [Display(Name = "Updated At Date"), JsonPropertyName("updatedAtDate")]
    public string UpdatedAtDate { get; set; }
}