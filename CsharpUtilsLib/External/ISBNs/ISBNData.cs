namespace CsharpUtilsLib.External.ISBNs;

public sealed class ISBNData : BaseExternalData<ISBN>
{
    protected override string Url => "https://brasilapi.com.br/api/isbn/v1/{0}";

    public ISBNData() : base() { }

    public ISBNData(HttpWrapper http) : base(http) { }

    public async Task<ISBN> GetInfosFromISBN(string isbn)
    {
        return await Request(parameters: isbn);
    }
}