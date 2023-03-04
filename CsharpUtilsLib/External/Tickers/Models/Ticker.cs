namespace CsharpUtilsLib.External.Tickers.Models;

public sealed class Ticker
{
    [Display(Name = "Symbol"), JsonPropertyName("symbol")]
    public string Symbol { get; set; }

    [Display(Name = "Short Name"), JsonPropertyName("shortName")]
    public string ShortName { get; set; }

    [Display(Name = "Long Name"), JsonPropertyName("longName")]
    public string LongName { get; set; }

    [Display(Name = "Currency"), JsonPropertyName("currency")]
    public string Currency { get; set; }

    [Display(Name = "Regular Market Price"), JsonPropertyName("regularMarketPrice")]
    public double? RegularMarketPrice { get; set; }

    [Display(Name = "Regular Market Day High"), JsonPropertyName("regularMarketDayHigh")]
    public double? RegularMarketDayHigh { get; set; }

    [Display(Name = "Regular Market Day Low"), JsonPropertyName("regularMarketDayLow")]
    public double? RegularMarketDayLow { get; set; }

    [Display(Name = "Regular Market Day Range"), JsonPropertyName("regularMarketDayRange")]
    public string RegularMarketDayRange { get; set; }

    [Display(Name = "Regular Market Change"), JsonPropertyName("regularMarketChange")]
    public double? RegularMarketChange { get; set; }

    [Display(Name = "Regular Market Change Percent"), JsonPropertyName("regularMarketChangePercent")]
    public double? RegularMarketChangePercent { get; set; }

    [Display(Name = "Regular Market Time"), JsonPropertyName("regularMarketTime")]
    public DateTime? RegularMarketTime { get; set; }

    [Display(Name = "Market Cap"), JsonPropertyName("marketCap")]
    public long? MarketCap { get; set; }

    [Display(Name = "Regular Market Volume"), JsonPropertyName("regularMarketVolume")]
    public int? RegularMarketVolume { get; set; }

    [Display(Name = "Regular Market Previous Close"), JsonPropertyName("regularMarketPreviousClose")]
    public double? RegularMarketPreviousClose { get; set; }

    [Display(Name = "Regular Market Open"), JsonPropertyName("regularMarketOpen")]
    public double? RegularMarketOpen { get; set; }

    [Display(Name = "Average Daily Volume 10 Day"), JsonPropertyName("averageDailyVolume10Day")]
    public int? AverageDailyVolume10Day { get; set; }

    [Display(Name = "Average Daily Volume 3 Month"), JsonPropertyName("averageDailyVolume3Month")]
    public int? AverageDailyVolume3Month { get; set; }

    [Display(Name = "Fifty Two Week Low Change"), JsonPropertyName("fiftyTwoWeekLowChange")]
    public double? FiftyTwoWeekLowChange { get; set; }

    [Display(Name = "Fifty Two Week Low Change Percent"), JsonPropertyName("fiftyTwoWeekLowChangePercent")]
    public double? FiftyTwoWeekLowChangePercent { get; set; }

    [Display(Name = "Fifty Two Week Range"), JsonPropertyName("fiftyTwoWeekRange")]
    public string FiftyTwoWeekRange { get; set; }

    [Display(Name = "Fifty Two Week High Change"), JsonPropertyName("fiftyTwoWeekHighChange")]
    public double? FiftyTwoWeekHighChange { get; set; }

    [Display(Name = "Fifty Two Week High Change Percent"), JsonPropertyName("fiftyTwoWeekHighChangePercent")]
    public double? FiftyTwoWeekHighChangePercent { get; set; }

    [Display(Name = "Fifty Two Week Low"), JsonPropertyName("fiftyTwoWeekLow")]
    public double? FiftyTwoWeekLow { get; set; }

    [Display(Name = "Fifty Two Week High"), JsonPropertyName("fiftyTwoWeekHigh")]
    public double? FiftyTwoWeekHigh { get; set; }

    [Display(Name = "Two Hundred Day Average"), JsonPropertyName("twoHundredDayAverage")]
    public double? TwoHundredDayAverage { get; set; }

    [Display(Name = "Two Hundred Day Average Change"), JsonPropertyName("twoHundredDayAverageChange")]
    public double? TwoHundredDayAverageChange { get; set; }

    [Display(Name = "Two Hundred Day Average Change Percent"), JsonPropertyName("twoHundredDayAverageChangePercent")]
    public double? TwoHundredDayAverageChangePercent { get; set; }

    [Display(Name = "Valid Ranges"), JsonPropertyName("validRanges")]
    public List<string> ValidRanges { get; set; }

    [Display(Name = "Historical Data Price"), JsonPropertyName("historicalDataPrice")]
    public List<HistoricalDataPrice> HistoricalDataPrice { get; set; }

    [Display(Name = "Price Earnings"), JsonPropertyName("priceEarnings")]
    public double? PriceEarnings { get; set; }

    [Display(Name = "Earnings Per Share"), JsonPropertyName("earningsPerShare")]
    public double? EarningsPerShare { get; set; }

    [Display(Name = "Logo Url"), JsonPropertyName("logourl")]
    public string Logourl { get; set; }

    [Display(Name = "Dividends Data"), JsonPropertyName("dividendsData")]
    public DividendsData DividendsData { get; set; }
}