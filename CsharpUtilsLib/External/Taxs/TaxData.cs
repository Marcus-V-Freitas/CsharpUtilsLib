namespace CsharpUtilsLib.External.Taxs;

public sealed class TaxData : BaseExternalData<Tax>
{
    protected override string Url => "https://brasilapi.com.br/api/taxas/v1/{0}";

    public TaxData() : base() { }

    public TaxData(HttpWrapper http) : base(http) { }

    public async Task<Tax> GetTaxByName(string name)
    {
        return await Request(parameters: name);
    }
}