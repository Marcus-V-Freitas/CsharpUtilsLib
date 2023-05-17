namespace CsharpUtilsLib.External;

public abstract class BaseExternalData<T> where T : class
{
    protected readonly HttpWrapper _http;
    protected abstract string Url { get; }
    protected virtual List<KeyValuePair<string, string>> Cookies => new();
    protected virtual Dictionary<string, string> Headers => new();

    public BaseExternalData()
    {
        _http = new HttpWrapper()
        {
            Headers = Headers,
            Cookies = Cookies
        };
    }

    public BaseExternalData(HttpWrapper http)
    {
        _http = http;
    }

    protected virtual async Task<T> Request(string endpoint = null!, params string[] parameters)
    {
        if (parameters.ListIsNullOrEmpty())
        {
            return null!;
        }

        string baseUrl = string.IsNullOrEmpty(endpoint) ? Url : Web.Web.CombineUrl(Url, endpoint);
        string url = string.Format(baseUrl, parameters);

        if (typeof(T) == typeof(string))
        {
            return (await _http.GET(url) as T)!;
        }

        return await _http.GET<T>(url);
    }
}