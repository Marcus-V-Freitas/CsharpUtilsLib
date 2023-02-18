namespace CsharpUtilsLib.External.Location;

public sealed class CEPData : BaseExternalData<CEP>
{
    protected override string Url => "https://viacep.com.br/ws/{0}/json/";

    public CEPData() : base() { }

    public CEPData(HttpWrapper http) : base(http) { }

    public async Task<CEP> GetLocation(string input)
    {
        return await Request(parameters: Texts.RemoveDocumentMask(input));
    }
}