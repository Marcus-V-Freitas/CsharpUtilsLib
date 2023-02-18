namespace CsharpUtilsLib.External.Location;

public sealed class CountryData : BaseExternalData<List<Country>>
{
    private static readonly Dictionary<CountryOptions, string> _endpointMapping = new()
    {
        { CountryOptions.PartialName, "name/{0}" },
        { CountryOptions.FullName , "name/{0}?fullText=true" },
        { CountryOptions.IsoCode, "alpha/{0}" },
        { CountryOptions.Currency, "currency/{0}" },
        { CountryOptions.Language, "lang/{0}" },
        { CountryOptions.Capital, "capital/{0}" },
        { CountryOptions.Region, "region/{0}" },
        { CountryOptions.SubRegion, "subregion/{0}" }
    };

    protected override string Url => "https://restcountries.com/v3.1/";

    public CountryData() : base() { }

    public CountryData(HttpWrapper http) : base(http) { }

    public async Task<Country> GetCountryByOption(CountryOptions option, string searchTerm)
    {
        var countries = await GetCountriesByOption(option, searchTerm);

        if (countries.ListIsNullOrEmpty())
        {
            return null!;
        }

        return countries.FirstOrDefault()!;
    }

    public async Task<List<Country>> GetCountriesByOption(CountryOptions option, string searchTerm)
    {
        if (string.IsNullOrEmpty(searchTerm))
        {
            return null!;
        }

        string endpoint = _endpointMapping.TryGetValue(option);

        return await Request(endpoint: endpoint, Uri.EscapeDataString(searchTerm.ToLower()));
    }
}