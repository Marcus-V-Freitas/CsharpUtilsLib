namespace CsharpUtilsLib.External.NCMs;

public sealed class NCMData : BaseExternalData<NCM>
{
    protected override string Url => "https://brasilapi.com.br/api/ncm/v1/{0}";

    public NCMData() : base() { }

    public NCMData(HttpWrapper http) : base(http) { }

    public async Task<NCM> GetNCMByCode(string code)
    {
        return await Request(parameters: Texts.RemoveDocumentMask(code));
    }
}