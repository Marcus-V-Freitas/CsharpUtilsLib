namespace CsharpUtilsLib.External.Inflations;

public sealed class InflationData : BaseExternalData<SearchInflation>
{
    protected override string Url => "https://brapi.dev/api/v2/inflation?country={0}&historical=false&start={1}&end={2}&sortBy=date&sortOrder=desc";

    protected override Dictionary<string, string> Headers => new()
    {
        { "User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/110.0.0.0 Safari/537.36" },
        { "Accept", "application/json" },
        { "Connection", "keep-alive" },
        { "Host", "brapi.dev" }
    };

    public async Task<SearchInflation> GetByCountryInPeriod(string country, DateTime start, DateTime end)
    {
        return await Request(endpoint: null!, country, Uri.EscapeDataString(start.ToString("dd/MM/yyyy")), Uri.EscapeDataString(end.ToString("dd/MM/yyyy")));
    }
}