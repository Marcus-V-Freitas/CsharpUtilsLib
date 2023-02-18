namespace CsharpUtilsLib.External.FIPEs;

public sealed class FIPEData : BaseExternalData<List<FIPE>>
{
    protected override string Url => "https://brasilapi.com.br/api/fipe/preco/v1/{0}";

    public FIPEData() : base() { }

    public FIPEData(HttpWrapper http) : base(http) { }

    public async Task<List<FIPE>> GetFiPEByCode(string code)
    {
        return await Request(parameters: Texts.RemoveDocumentMask(code));
    }
}