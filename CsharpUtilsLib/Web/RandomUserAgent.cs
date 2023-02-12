namespace CsharpUtilsLib.Web;

public static class RandomUserAgent
{
    private static readonly string[] _browserType = new string[]
    {
        "chrome",
        "firefox",
    };

    private static readonly Dictionary<string, string> _UATemplate = new Dictionary<string, string>
    {
        { "chrome", "Mozilla/5.0 ({0}) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/{1} Safari/537.36" },
        { "firefox", "Mozilla/5.0 ({0}; rv:{1}.0) Gecko/20100101 Firefox/{1}.0" },
    };

    private static readonly string[] _OS = new string[]
    {
        "Windows NT 10.0; Win64; x64",
        "X11; Linux x86_64",
        "Macintosh; Intel Mac OS X 12_4"
    };

    public static string Get()
    {
        string OSsystem = _OS.GetRandom();
        int version = SafeRandom.Next(93, 104);
        int minor = 0;
        int patch = SafeRandom.Next(4950, 5162);
        int build = SafeRandom.Next(80, 212);
        string randomBroswer = _browserType.GetRandom();
        string browserTemplate = _UATemplate[randomBroswer];
        string finalVersion = version.ToString();

        if (randomBroswer == "chrome")
        {
            finalVersion = $"{version}.{minor}.{patch}.{build}";
        }

        return string.Format(browserTemplate, OSsystem, finalVersion);
    }
}