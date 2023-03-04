namespace CsharpUtilsLib.External.Tickers.Models;

public sealed class StockDividend
{
    [Display(Name = "Asset Issued"), JsonPropertyName("assetIssued")]
    public string AssetIssued { get; set; }

    [Display(Name = "Factor"), JsonPropertyName("factor")]
    public int? Factor { get; set; }

    [Display(Name = "Approved On"), JsonPropertyName("approvedOn")]
    public DateTime? ApprovedOn { get; set; }

    [Display(Name = "Isin Code"), JsonPropertyName("isinCode")]
    public string IsinCode { get; set; }

    [Display(Name = "Label"), JsonPropertyName("label")]
    public string Label { get; set; }

    [Display(Name = "Last Date Prior"), JsonPropertyName("lastDatePrior")]
    public DateTime? LastDatePrior { get; set; }

    [Display(Name = "Remarks"), JsonPropertyName("remarks")]
    public string Remarks { get; set; }
}