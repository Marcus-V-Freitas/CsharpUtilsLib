namespace CsharpUtilsLib.External.Companies;

public sealed class CompaniesData : BaseExternalData<Company>
{
    protected override string Url => "https://brasilapi.com.br/api/cnpj/v1/{0}";

    public CompaniesData() : base() { }

    public CompaniesData(HttpWrapper http) : base(http) { }

    public async Task<Company> GetCompanyByCNPJ(string cnpj)
    {
        return await Request(parameters: Texts.RemoveDocumentMask(cnpj));
    }
}