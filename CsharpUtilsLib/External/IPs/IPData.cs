namespace CsharpUtilsLib.External.IPs;

public sealed class IPData : BaseExternalData<IP>
{
    protected override string Url => "https://ipapi.co/{0}/json/";

    protected override List<KeyValuePair<string, string>> Cookies => new()
    {
        new("csrftoken", "nRbxkPyIXlkSavBGgmpsrwVtctYCPGgQL2GHT0V7Xyy9u0vouzWy85a6qhrabPpT")
    };

    protected override Dictionary<string, string> Headers => new()
    {
        { "User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/109.0.0.0 Safari/537.36" },
        { "Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9" },
        { "Connection", "keep-alive" },
        { "Host", "ipapi.co" }
    };

    public IPData() : base() { }

    public IPData(HttpWrapper http) : base(http) { }

    public async Task<IP> GetInfosFromIP(string ipAdress)
    {
        return await Request(parameters: ipAdress);
    }
}