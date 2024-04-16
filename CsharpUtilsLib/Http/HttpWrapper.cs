namespace CsharpUtilsLib.Http;

public sealed class HttpWrapper : IHttpWrapper
{
    private const string _defaultContentType = "application/x-www-form-urlencoded";
    private readonly bool _allowAutoRedirect;
    private readonly CookieContainer _cookiesContainer = new();
    private HttpClientHandler _httpClientHandler;
    private Dictionary<string, string> _headers = new();
    private List<KeyValuePair<string, string>> _cookies = new();
    private Encoding _encoding = Encoding.Default;
    private IWebProxy _proxy = null!;

    public Encoding Encoding
    {
        get => _encoding;
        set
        {
            _encoding = value ?? Encoding.Default;
            SetHeaderValue("Accept-Charset", _encoding.HeaderName);
        }
    }

    public IWebProxy Proxy
    {
        get => _proxy;
        set
        {
            _proxy = value;
            FillWebProxy(_proxy);
        }
    }

    public string ContentType { get; set; } = _defaultContentType;
    public bool KeepAlive { get; set; }
    public int TimeoutSeconds { get; set; } = 30;
    public HttpStatusCode StatusCode { get; private set; }
    public string ReasonPhrase { get; private set; } = null!;
    public string RequestUri { get; private set; } = null!;
    public string ErrorMessage { get; private set; } = null!;
    public long? ContentLength { get; private set; } = null!;
    public string Version { get; private set; } = null!;
    public Dictionary<string, string> Headers { get => _headers; set => _headers = value; }
    public List<KeyValuePair<string, string>> Cookies { get => _cookies; set => _cookies = value; }
    public HttpResponseHeaders ResponseHeaders { get; private set; }
    public List<Cookie> ResponseCookies { get; private set; }

    #region Specific Headers

    public string AcceptCharset { get => GetHeaderValue("Accept-Charset"); set => Encoding = Texts.GetEncodingByName(value); }
    public string Authorization { get => GetHeaderValue("Authorization"); set => SetHeaderValue("Authorization", value); }
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
        RegisterEncodings();
        TimeoutSeconds = timeoutSeconds;
        Encoding = Encoding.Default;
        _allowAutoRedirect = allowAutoRedirect;
        Proxy = proxy;
    }

    public async Task<HtmlString> HtmlGET(string Url, bool lowerCaseKeepAlive = false)
    {
        string htmlResponse = await GET(Url, lowerCaseKeepAlive);
        return SecureHtmlStringReturn(htmlResponse);
    }

    public async Task<HtmlString> HtmlPOST(string Url, HttpContent postData = null!, bool lowerCaseKeepAlive = false)
    {
        string htmlResponse = await POST(Url, postData, lowerCaseKeepAlive);
        return SecureHtmlStringReturn(htmlResponse);
    }

    public async Task<HtmlString> HtmlPOST(string Url, string rawPostData = null!, bool lowerCaseKeepAlive = false)
    {
        StringContent content = CreateContentByRawPostData(rawPostData);
        return await HtmlPOST(Url, content, lowerCaseKeepAlive);
    }

    public async Task<HtmlString> HtmlPUT(string Url, HttpContent postData = null!, bool lowerCaseKeepAlive = false)
    {
        string htmlResponse = await PUT(Url, postData, lowerCaseKeepAlive);
        return SecureHtmlStringReturn(htmlResponse);
    }

    public async Task<HtmlString> HtmlPUT(string Url, string rawPostData = null!, bool lowerCaseKeepAlive = false)
    {
        StringContent content = CreateContentByRawPostData(rawPostData);
        return await HtmlPUT(Url, content, lowerCaseKeepAlive);
    }

    public async Task<HtmlString> HtmlDELETE(string Url, bool lowerCaseKeepAlive = false)
    {
        string htmlResponse = await DELETE(Url, lowerCaseKeepAlive);
        return SecureHtmlStringReturn(htmlResponse);
    }

    public async Task<T> GET<T>(string Url, bool lowerCaseKeepAlive = false) where T : class
    {
        string jsonResponse = await GET(Url, lowerCaseKeepAlive);
        return SecureJsonObjectReturn<T>(jsonResponse);
    }

    public async Task<T> POST<T>(string Url, HttpContent postData = null!, bool lowerCaseKeepAlive = false) where T : class
    {
        string jsonResponse = await POST(Url, postData: postData, lowerCaseKeepAlive);
        return SecureJsonObjectReturn<T>(jsonResponse);
    }

    public async Task<T> POST<T>(string Url, string rawPostData = null!, bool lowerCaseKeepAlive = false) where T : class
    {
        StringContent content = CreateContentByRawPostData(rawPostData);
        return await POST<T>(Url, content, lowerCaseKeepAlive);
    }

    public async Task<T> PUT<T>(string Url, HttpContent postData = null!, bool lowerCaseKeepAlive = false) where T : class
    {
        string jsonResponse = await PUT(Url, postData: postData, lowerCaseKeepAlive);
        return SecureJsonObjectReturn<T>(jsonResponse);
    }

    public async Task<T> PUT<T>(string Url, string rawPostData = null!, bool lowerCaseKeepAlive = false) where T : class
    {
        StringContent content = CreateContentByRawPostData(rawPostData);
        return await PUT<T>(Url, content, lowerCaseKeepAlive);
    }

    public async Task<T> DELETE<T>(string Url, bool lowerCaseKeepAlive = false) where T : class
    {
        string jsonResponse = await DELETE(Url, lowerCaseKeepAlive);
        return SecureJsonObjectReturn<T>(jsonResponse);
    }

    public async Task<string> GET(string Url, bool lowerCaseKeepAlive = false)
    {
        var (content, _) = await SendRequest(HttpMethod.Get, Url, postData: null!, lowerCaseKeepAlive);
        return content;
    }

    public async Task<string> POST(string Url, HttpContent postData = null!, bool lowerCaseKeepAlive = false)
    {
        var (content, _) = await SendRequest(HttpMethod.Post, Url, postData, lowerCaseKeepAlive);
        return content;
    }

    public async Task<string> POST(string Url, string rawPostData = null!, bool lowerCaseKeepAlive = false)
    {
        StringContent content = CreateContentByRawPostData(rawPostData);
        return await POST(Url, content, lowerCaseKeepAlive);
    }

    public async Task<string> PUT(string Url, HttpContent postData = null!, bool lowerCaseKeepAlive = false)
    {
        var (content, _) = await SendRequest(HttpMethod.Put, Url, postData, lowerCaseKeepAlive);
        return content;
    }

    public async Task<string> PUT(string Url, string rawPostData = null!, bool lowerCaseKeepAlive = false)
    {
        StringContent content = CreateContentByRawPostData(rawPostData);
        return await PUT(Url, content, lowerCaseKeepAlive);
    }

    public async Task<string> DELETE(string Url, bool lowerCaseKeepAlive = false)
    {
        var (content, _) = await SendRequest(HttpMethod.Delete, Url, postData: null!, lowerCaseKeepAlive);
        return content;
    }

    public async Task<byte[]> BytesGET(string Url, bool lowerCaseKeepAlive = false)
    {
        var (_, bytes) = await SendRequest(HttpMethod.Get, Url, postData: null!, lowerCaseKeepAlive);
        return bytes;
    }

    public async Task<byte[]> BytesPOST(string Url, HttpContent postData = null!, bool lowerCaseKeepAlive = false)
    {
        var (_, bytes) = await SendRequest(HttpMethod.Post, Url, postData, lowerCaseKeepAlive);
        return bytes;
    }

    public async Task<byte[]> BytesPOST(string Url, string rawPostData = null!, bool lowerCaseKeepAlive = false)
    {
        StringContent content = CreateContentByRawPostData(rawPostData);
        return await BytesPOST(Url, content, lowerCaseKeepAlive);
    }

    public async Task<byte[]> BytesPUT(string Url, HttpContent postData = null!, bool lowerCaseKeepAlive = false)
    {
        var (_, bytes) = await SendRequest(HttpMethod.Put, Url, postData, lowerCaseKeepAlive);
        return bytes;
    }

    public async Task<byte[]> BytesPUT(string Url, string rawPostData = null!, bool lowerCaseKeepAlive = false)
    {
        StringContent content = CreateContentByRawPostData(rawPostData);
        return await BytesPUT(Url, content, lowerCaseKeepAlive);
    }

    public async Task<byte[]> BytesDELETE(string Url, bool lowerCaseKeepAlive = false)
    {
        var (_, bytes) = await SendRequest(HttpMethod.Delete, Url, postData: null!, lowerCaseKeepAlive);
        return bytes;
    }

    private void ResetHttpClientHandler()
    {
        _httpClientHandler?.Dispose();

        _httpClientHandler = new HttpClientHandler()
        {
            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate | DecompressionMethods.Brotli,
            SslProtocols = SslProtocols.Ssl3 | SslProtocols.Tls | SslProtocols.Tls11 | SslProtocols.Tls12 | SslProtocols.Tls13,
            ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true,
            CookieContainer = _cookiesContainer,
            AllowAutoRedirect = _allowAutoRedirect
        };
    }

    private static void RegisterEncodings()
    {
        EncodingProvider provider = CodePagesEncodingProvider.Instance;
        Encoding.RegisterProvider(provider);
    }

    private static HtmlString SecureHtmlStringReturn(string htmlResponse)
    {
        return (string.IsNullOrEmpty(htmlResponse) ? null : HtmlString.Instance(htmlResponse))!;
    }

    private static T SecureJsonObjectReturn<T>(string jsonResponse) where T : class
    {
        return (string.IsNullOrEmpty(jsonResponse) ? null : JsonSerializer.Deserialize<T>(jsonResponse))!;
    }

    private StringContent CreateContentByRawPostData(string postData)
    {
        StringContent content = new(postData, Encoding);
        content.Headers.Remove("Content-Type");
        content.Headers.TryAddWithoutValidation("Content-Type", ContentType);

        return content;
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
            return;
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

    private void FillWebProxy(IWebProxy proxy)
    {
        ResetHttpClientHandler();

        _httpClientHandler.Proxy = proxy;
        _httpClientHandler.UseProxy = proxy != null;
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
                using (HttpClient http = new(_httpClientHandler, disposeHandler: false)
                {
                    Timeout = TimeSpan.FromSeconds(TimeoutSeconds)
                })
                {
                    using (HttpRequestMessage request = new(method, Url)
                    {
                        Content = postData
                    })
                    {
                        FillContentType(postData);
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

    private void FillContentType(HttpContent content)
    {
        ContentType = content?.Headers?.ContentType?.MediaType! ?? _defaultContentType;
        AcceptCharset = content?.Headers?.ContentType?.CharSet!;
    }

    private async Task<(string content, byte[] bytes)> SendRequest(HttpMethod method,
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
            ContentLength = bytes?.LongLength;
            Version = response?.Version?.ToString()!;
            ResponseCookies = _cookiesContainer?.GetCookies(Url)!;

            await Task.Delay(3000);

            if (response.IsSuccessStatusCode)
            {
                ErrorMessage = string.Empty;
                return (content, bytes)!;
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
        _httpClientHandler?.Dispose();
    }
}