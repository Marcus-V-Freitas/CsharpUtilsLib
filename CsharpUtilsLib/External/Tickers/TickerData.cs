namespace CsharpUtilsLib.External.Tickers;

public sealed class TickerData : BaseExternalData<SearchTickers>
{
    protected override string Url => "https://brapi.dev/api/quote/{0}?range=1d&interval=1d&fundamental={1}&dividends={2}";

    protected override Dictionary<string, string> Headers => new()
    {
        { "User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/110.0.0.0 Safari/537.36" },
        { "Accept", "application/json" },
        { "Connection", "keep-alive" },
        { "Host", "brapi.dev" }
    };

    public async Task<SearchTickers> GetTickerByName(string name, bool fundamental = true, bool dividends = true)
    {
        return await Request(endpoint: null!, name, fundamental.ToString(), dividends.ToString());
    }
}