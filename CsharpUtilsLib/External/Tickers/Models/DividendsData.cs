namespace CsharpUtilsLib.External.Tickers.Models;

public sealed class DividendsData
{
    [Display(Name = "Cash Dividends"), JsonPropertyName("cashDividends")]
    public List<CashDividend> CashDividends { get; set; }

    [Display(Name = "Stock Dividends"), JsonPropertyName("stockDividends")]
    public List<StockDividend> StockDividends { get; set; }

    [Display(Name = "Subscriptions"), JsonPropertyName("subscriptions")]
    public List<object> Subscriptions { get; set; }
}