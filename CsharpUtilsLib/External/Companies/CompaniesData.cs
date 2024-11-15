namespace CsharpUtilsLib.External.Companies;

public sealed class CompaniesData : BaseExternalData<Company>
{
    protected override string Url => "https://brasilapi.com.br/api/cnpj/v1/{0}";

    protected override Dictionary<string, string> Headers => new()
    {
        { "User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/131.0.0.0 Safari/537.36" },
        { "Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8" },
        { "Host", "brasilapi.com.br" }
    };

    public CompaniesData() : base() { }

    public CompaniesData(HttpWrapper http) : base(http) { }

    public async Task<Company> GetCompanyByCNPJ(string cnpj)
    {
        return await Request(parameters: Texts.RemoveDocumentMask(cnpj));
    }
}