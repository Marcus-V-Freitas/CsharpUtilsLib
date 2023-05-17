namespace CsharpUtilsLib.Http;

public sealed class HttpWrapper : IHttpWrapper, IDisposable
{
    private readonly HttpClientHandler _httpClientHandler;
    private readonly CookieContainer _cookiesContainer = new();
    private Dictionary<string, string> _headers = new();
    private List<KeyValuePair<string, string>> _cookies = new();

    public bool KeepAlive { get; set; }
    public int TimeoutSeconds { get; set; } = 30;
    public WebProxy Proxy { get; private set; }
    public HttpStatusCode StatusCode { get; private set; }
    public string ReasonPhrase { get; private set; } = null!;
    public string RequestUri { get; private set; } = null!;
    public string ErrorMessage { get; private set; } = null!;
    public Dictionary<string, string> Headers { get => _headers; set => _headers = value; }
    public List<KeyValuePair<string, string>> Cookies { get => _cookies; set => _cookies = value; }
    public HttpResponseHeaders ResponseHeaders { get; private set; }
    public List<Cookie> ResponseCookies { get; private set; }

    #region Specific Headers

    public string UserAgent { get => GetHeaderValue("User-Agent"); set => SetHeaderValue("User-Agent", value); }
    public string Accept { get => GetHeaderValue("Accept"); set => SetHeaderValue("Accept", value); }
    public string Host { get => GetHeaderValue("Host"); set => SetHeaderValue("Host", value); }
    public string Referrer { get => GetHeaderValue("Referer"); set => SetHeaderValue("Referer", value); }
    public string AcceptEncoding { get => GetHeaderValue("Accept-Encoding"); set => SetHeaderValue("Accept-Encoding", value); }
    public string Origin { get => GetHeaderValue("Origin"); set => SetHeaderValue("Origin", value); }
    public string AcceptLanguage { get => GetHeaderValue("Accept-Language"); set => SetHeaderValue("Accept-Language", value); }

    #endregion

    public HttpWrapper(int timeoutSeconds = 30, bool allowAutoRedirect = true, WebProxy proxy = null!)
    {
        TimeoutSeconds = timeoutSeconds;

        _httpClientHandler = new HttpClientHandler()
        {
            SslProtocols = SslProtocols.Ssl3 | SslProtocols.Tls | SslProtocols.Tls11 | SslProtocols.Tls12 | SslProtocols.Tls13,
            ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true,
            CookieContainer = _cookiesContainer,
            AllowAutoRedirect = allowAutoRedirect
        };

        FillWebProxy(proxy);
    }

    public async Task<HtmlString> HtmlGET(string Url, bool lowerCaseKeepAlive = false)
    {
        var (content, _) = await SendResquest(HttpMethod.Get, Url, postData: null!, lowerCaseKeepAlive);
        return HtmlString.Instance(content);
    }

    public async Task<HtmlString> HtmlPOST(string Url, HttpContent postData = null!, bool lowerCaseKeepAlive = false)
    {
        var (content, _) = await SendResquest(HttpMethod.Post, Url, postData, lowerCaseKeepAlive);
        return HtmlString.Instance(content);
    }

    public async Task<T> GET<T>(string Url, bool lowerCaseKeepAlive = false) where T : class
    {
        string jsonResponse = await GET(Url, lowerCaseKeepAlive);
        return (string.IsNullOrEmpty(jsonResponse) ? null : JsonSerializer.Deserialize<T>(jsonResponse))!;
    }

    public async Task<T> POST<T>(string Url, HttpContent postData = null!, bool lowerCaseKeepAlive = false) where T : class
    {
        string jsonResponse = await POST(Url, postData: postData, lowerCaseKeepAlive);
        return (string.IsNullOrEmpty(jsonResponse) ? null : JsonSerializer.Deserialize<T>(jsonResponse))!;
    }

    public async Task<string> GET(string Url, bool lowerCaseKeepAlive = false)
    {
        var (content, _) = await SendResquest(HttpMethod.Get, Url, postData: null!, lowerCaseKeepAlive);
        return content;
    }

    public async Task<string> POST(string Url, HttpContent postData = null!, bool lowerCaseKeepAlive = false)
    {
        var (content, _) = await SendResquest(HttpMethod.Post, Url, postData, lowerCaseKeepAlive);
        return content;
    }

    public async Task<string> PUT(string Url, HttpContent postData = null!, bool lowerCaseKeepAlive = false)
    {
        var (content, _) = await SendResquest(HttpMethod.Put, Url, postData, lowerCaseKeepAlive);
        return content;
    }

    public async Task<string> DELETE(string Url, bool lowerCaseKeepAlive = false)
    {
        var (content, _) = await SendResquest(HttpMethod.Delete, Url, postData: null!, lowerCaseKeepAlive);
        return content;
    }

    public async Task<byte[]> BytesGET(string Url, bool lowerCaseKeepAlive = false)
    {
        var (_, bytes) = await SendResquest(HttpMethod.Get, Url, postData: null!, lowerCaseKeepAlive);
        return bytes;
    }

    public async Task<byte[]> BytesPOST(string Url, HttpContent postData = null!, bool lowerCaseKeepAlive = false)
    {
        var (_, bytes) = await SendResquest(HttpMethod.Post, Url, postData, lowerCaseKeepAlive);
        return bytes;
    }

    private string GetHeaderValue(string key)
    {
        return _headers.ContainsKey(key) ? _headers[key] : null!;
    }

    private void SetHeaderValue(string key, string value)
    {
        if (value == null)
        {
            _headers.Remove(key);
        }

        _headers[key] = value!;
    }

    private static void AddOrUpdateHeader(HttpClient http, string key, string value)
    {
        if (http.DefaultRequestHeaders.Contains(key))
        {
            http.DefaultRequestHeaders.Remove(key);
        }

        http.DefaultRequestHeaders.Add(key, value);
    }

    private void AddKeepAlive(HttpClient http, bool lowerCaseKeepAlive)
    {
        if (lowerCaseKeepAlive)
        {
            AddOrUpdateHeader(http, "Connection", "keep-alive");
        }
        else if (KeepAlive)
        {
            AddOrUpdateHeader(http, "Connection", "Keep-Alive");
        }
    }

    private void FillWebProxy(WebProxy proxy)
    {
        if (proxy != null)
        {
            Proxy = proxy;
            _httpClientHandler.Proxy = Proxy;
            _httpClientHandler.UseProxy = true;
        }
    }

    private async Task<HttpResponseMessage> ReponseMessage(HttpMethod method,
                                                           string Url,
                                                           HttpContent postData,
                                                           bool lowerCaseKeepAlive)
    {
        using (CancellationTokenSource cancelToken = new(TimeSpan.FromSeconds(TimeoutSeconds)))
        {
            try
            {
                using (HttpClient http = new(_httpClientHandler, false))
                {
                    using (HttpRequestMessage request = new(method, Url)
                    {
                        Content = postData
                    })
                    {
                        AddCookies(request);
                        AddHeaders(http, lowerCaseKeepAlive);

                        return await http.SendAsync(request, cancelToken.Token);
                    }
                }
            }
            catch (TaskCanceledException ex)
            {
                ErrorMessage = $"[Timeout] - {ex.StackTrace}";
            }
            catch (Exception ex)
            {
                ErrorMessage = $"[Internal Error] - {ex.StackTrace}";
            }
        }
        return null!;
    }

    private void AddHeaders(HttpClient http, bool lowerCaseKeepAlive)
    {
        AddKeepAlive(http, lowerCaseKeepAlive);

        if (_headers.ListIsNullOrEmpty())
        {
            return;
        }

        foreach (KeyValuePair<string, string> header in _headers)
        {
            AddOrUpdateHeader(http, header.Key, header.Value);
        }
    }

    private void AddCookies(HttpRequestMessage request)
    {
        StringBuilder sb = new();

        if (!_cookies.ListIsNullOrEmpty())
        {
            foreach (KeyValuePair<string, string> cookie in _cookies)
            {
                if (!cookie.KeyValueIsNullOrEmpty())
                {
                    sb.Append($"{cookie.Key}={cookie.Value}; ");
                }
            }
        }

        if (!ResponseCookies.ListIsNullOrEmpty())
        {
            foreach (Cookie cookie in ResponseCookies)
            {
                sb.Append($"{cookie.Name}={cookie.Value}; ");
            }
        }

        if (sb.Length > 0)
        {
            request.Headers.Add("Cookie", sb.ToString());
        }
    }

    private async Task<(string content, byte[] bytes)> SendResquest(HttpMethod method,
                                                                    string Url,
                                                                    HttpContent postData,
                                                                    bool lowerCaseKeepAlive)
    {
        using (HttpResponseMessage response = await ReponseMessage(method, Url, postData, lowerCaseKeepAlive))
        {
            if (response == null)
                return (null, null)!;

            byte[] bytes = await response?.Content?.ReadAsByteArrayAsync()!;
            string content = await response?.Content?.ReadAsStringAsync()!;
            RequestUri = response.RequestMessage?.RequestUri?.ToString()!;
            StatusCode = response.StatusCode;
            ReasonPhrase = response.ReasonPhrase!;
            ResponseHeaders = response.Headers;
            ResponseCookies = _cookiesContainer?.GetCookies(new Uri(Url))?.Cast<Cookie>()?.ToList()!;

            await Task.Delay(3000);

            if (response.IsSuccessStatusCode)
            {
                ErrorMessage = string.Empty;
                return (content, bytes);
            }
            else
            {
                ErrorMessage = content;
                return (null, null)!;
            }
        }
    }

    public void Dispose()
    {
        _httpClientHandler.Dispose();
    }
}