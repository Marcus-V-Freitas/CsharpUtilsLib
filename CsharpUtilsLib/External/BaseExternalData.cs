namespace CsharpUtilsLib.External;

public abstract class BaseExternalData<T> : IDisposable where T : class
{
    protected readonly HttpWrapper _http;
    protected abstract string Url { get; }
    protected virtual List<KeyValuePair<string, string>> Cookies => [];
    protected virtual Dictionary<string, string> Headers => [];

    private bool _disposed;

    protected BaseExternalData()
    {
        _http = new HttpWrapper()
        {
            Headers = Headers,
            Cookies = Cookies
        };
    }

    protected BaseExternalData(HttpWrapper http)
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

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _http?.Dispose();
            }
            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~BaseExternalData()
    {
        Dispose(false);
    }
}