namespace CsharpUtilsLib.Web;

public static class RandomUserAgent
{
    private static readonly List<string> _browsers = new()
    {
        "Chrome",
        "Firefox",
        "Safari",
        "Edge",
        "Opera"
    };

    private static readonly List<string> _operatingSystems = new()
    {
        "Windows NT 10.0; Win64; x64",
        "Windows NT 6.1; Win64; x64",
        "Macintosh; Intel Mac OS X 10_15_7",
        "X11; Linux x86_64",
        "iPhone; CPU iPhone OS 15_0 like Mac OS X",
        "Android 11; Mobile"
    };

    public static string Get()
    {
        string browser = _browsers[SafeRandom.Next(_browsers.Count)];
        string os = _operatingSystems[SafeRandom.Next(_operatingSystems.Count)];
        string version = GenerateVersion();

        return browser switch
        {
            "Chrome" => $"Mozilla/5.0 ({os}) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/{version} Safari/537.36",
            "Firefox" => $"Mozilla/5.0 ({os}; rv:{version.Split('.')[0]}) Gecko/20100101 Firefox/{version}",
            "Safari" => $"Mozilla/5.0 ({os}) AppleWebKit/537.36 (KHTML, like Gecko) Version/{version} Safari/537.36",
            "Edge" => $"Mozilla/5.0 ({os}) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/{version} Safari/537.36 Edg/{version}",
            "Opera" => $"Mozilla/5.0 ({os}) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/{version} Safari/537.36 OPR/{version}",
            _ => $"Mozilla/5.0 ({os}) AppleWebKit/537.36 (KHTML, like Gecko)"
        };
    }

    private static string GenerateVersion()
    {
        int major = SafeRandom.Next(50, 120);
        int minor = SafeRandom.Next(0, 5000);
        int build = SafeRandom.Next(0, 100);
        return $"{major}.{minor}.{build}";
    }
}