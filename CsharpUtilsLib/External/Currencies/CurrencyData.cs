namespace CsharpUtilsLib.External.Currencies;

public sealed class CurrencyData : BaseExternalData<SearchCurrency>
{
    protected override string Url => "https://brapi.dev/api/v2/currency?currency={0}";

    protected override Dictionary<string, string> Headers => new()
    {
        { "User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/110.0.0.0 Safari/537.36" },
        { "Accept", "application/json" },
        { "Connection", "keep-alive" },
        { "Host", "brapi.dev" }
    };

    public async Task<SearchCurrency> ConvertCurrencies(string baseCurrency, params string[] currencyNames)
    {
        string query = string.Join(" ", currencyNames.Select(x => $"{baseCurrency.ToUpper()}-{x.ToUpper()}"));

        return await Request(parameters: Uri.EscapeDataString(query));
    }
}