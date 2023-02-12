namespace CsharpUtilsLib.External.Translate;

public sealed class GoogleTranslate
{
    private readonly HttpClient _client = new HttpClient();
    private const string _url = "https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}";

    public async Task<string> Translate(string input, string inputLanguage, string outputLanguage)
    {
        string url = string.Format(_url, inputLanguage, outputLanguage, Uri.EscapeDataString(input));
        string output = await _client.GetStringAsync(url);

        return FixTranslateOutput(output);
    }

    private static string FixTranslateOutput(string output)
    {
        if (string.IsNullOrEmpty(output))
        {
            return null!;
        }

        var externalDetails = JsonSerializer.Deserialize<List<object>>(output);
        var internalDetails = JsonSerializer.Deserialize<List<object>>($"{externalDetails!.FirstOrDefault()}");

        StringBuilder sb = new StringBuilder();

        foreach (var internalDetail in internalDetails!)
        {
            var translateData = JsonSerializer.Deserialize<List<object>>($"{internalDetail}");

            var translate = $"{translateData!.FirstOrDefault()}";

            if (!string.IsNullOrEmpty(translate))
            {
                sb.Append(translate);
            }
        }

        return sb.ToString();
    }
}