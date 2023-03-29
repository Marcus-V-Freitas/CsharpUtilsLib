namespace CsharpUtilsLib.Http;

public sealed class HttpWrapper : IHttpWrapper
{
    private readonly HttpClient _http;

    public int TimeoutSeconds { get; set; } = 30;
    public string RequestUri { get; private set; } = null!;

    public string ErrorMessage { get; private set; } = null!;

    public HttpStatusCode StatusCode { get; private set; } = HttpStatusCode.OK;
    public HttpResponseHeaders Headers { get; private set; } = null!;

    public HttpWrapper()
    {
        _http = new HttpClient();
    }

    public HttpWrapper(HttpClient http)
    {
        _http = http;
    }

    public async Task<HtmlString> HtmlGET(string Url,
                                          List<KeyValuePair<string, string>> cookies = null!,
                                          Dictionary<string, string> headers = null!)
    {
        var (content, _) = await SendResquest(HttpMethod.Get, Url, postData: null!, cookies: cookies, headers: headers);
        return HtmlString.Instance(content);
    }

    public async Task<HtmlString> HtmlPOST(string Url,
                                           HttpContent postData = null!,
                                           List<KeyValuePair<string, string>> cookies = null!,
                                           Dictionary<string, string> headers = null!)
    {
        var (content, _) = await SendResquest(HttpMethod.Post, Url, postData, cookies, headers);
        return HtmlString.Instance(content);
    }

    public async Task<T> GET<T>(string Url,
                                List<KeyValuePair<string, string>> cookies = null!,
                                Dictionary<string, string> headers = null!) where T : class
    {
        string jsonResponse = await GET(Url, cookies: cookies, headers: headers);
        return (string.IsNullOrEmpty(jsonResponse) ? null : JsonSerializer.Deserialize<T>(jsonResponse))!;
    }

    public async Task<T> POST<T>(string Url,
                                 HttpContent postData = null!,
                                 List<KeyValuePair<string, string>> cookies = null!,
                                 Dictionary<string, string> headers = null!) where T : class
    {
        string jsonResponse = await POST(Url, postData: postData, cookies: cookies, headers: headers);
        return (string.IsNullOrEmpty(jsonResponse) ? null : JsonSerializer.Deserialize<T>(jsonResponse))!;
    }

    public async Task<string> GET(string Url,
                                  List<KeyValuePair<string, string>> cookies = null!,
                                  Dictionary<string, string> headers = null!)
    {
        var (content, _) = await SendResquest(HttpMethod.Get, Url, postData: null!, cookies: cookies, headers: headers);
        return content;
    }

    public async Task<string> POST(string Url,
                                   HttpContent postData = null!,
                                   List<KeyValuePair<string, string>> cookies = null!,
                                   Dictionary<string, string> headers = null!)
    {
        var (content, _) = await SendResquest(HttpMethod.Post, Url, postData, cookies, headers);
        return content;
    }

    public async Task<string> PUT(string Url,
                                  HttpContent postData = null!,
                                  List<KeyValuePair<string, string>> cookies = null!,
                                  Dictionary<string, string> headers = null!)
    {
        var (content, _) = await SendResquest(HttpMethod.Put, Url, postData, cookies, headers);
        return content;
    }

    public async Task<string> DELETE(string Url,
                                     List<KeyValuePair<string, string>> cookies = null!,
                                     Dictionary<string, string> headers = null!)
    {
        var (content, _) = await SendResquest(HttpMethod.Delete, Url, postData: null!, cookies: cookies, headers: headers);
        return content;
    }

    public async Task<byte[]> BytesGET(string Url,
                                       List<KeyValuePair<string, string>> cookies = null!,
                                       Dictionary<string, string> headers = null!)
    {
        var (_, bytes) = await SendResquest(HttpMethod.Get, Url, postData: null!, cookies: cookies, headers: headers);
        return bytes;
    }

    public async Task<byte[]> BytesPOST(string Url,
                                        HttpContent postData = null!,
                                        List<KeyValuePair<string, string>> cookies = null!,
                                        Dictionary<string, string> headers = null!)
    {
        var (_, bytes) = await SendResquest(HttpMethod.Post, Url, postData, cookies, headers);
        return bytes;
    }

    private void AddHeaders(Dictionary<string, string> headers)
    {
        if (headers.DictionaryIsNullOrEmpty())
        {
            return;
        }

        _http.DefaultRequestHeaders.Clear();

        foreach (var header in headers)
        {
            _http.DefaultRequestHeaders.Add(header.Key, header.Value);
        }
    }

    private async Task<HttpResponseMessage> ReponseMessage(HttpMethod method,
                                                           string Url,
                                                           HttpContent postData = null!,
                                                           List<KeyValuePair<string, string>> cookies = null!,
                                                           Dictionary<string, string> headers = null!)
    {
        using (CancellationTokenSource cancelToken = new(TimeSpan.FromSeconds(TimeoutSeconds)))
        {
            try
            {
                HttpRequestMessage request = new(method, Url)
                {
                    Content = postData
                };

                AddCookies(request, cookies);

                AddHeaders(headers);

                return await _http.SendAsync(request, cancelToken.Token);
            }
            catch (TaskCanceledException ex)
            {
                Console.WriteLine($"[{nameof(HttpWrapper)}][Timeout] - {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{nameof(HttpWrapper)}] - {ex.Message}");
            }
        }
        return null!;
    }

    private static void AddCookies(HttpRequestMessage request, List<KeyValuePair<string, string>> cookies)
    {
        if (cookies.ListIsNullOrEmpty())
        {
            return;
        }

        StringBuilder sb = new();

        foreach (var cookie in cookies)
        {
            if (!cookie.KeyValueIsNullOrEmpty())
            {
                sb.Append($"{cookie.Key}={cookie.Value}; ");
            }
        }

        if (sb.Length > 0)
        {
            request.Headers.Add("Cookie", sb.ToString());
        }
    }

    private async Task<(string content, byte[] bytes)> SendResquest(HttpMethod method,
                                                                    string Url,
                                                                    HttpContent postData = null!,
                                                                    List<KeyValuePair<string, string>> cookies = null!,
                                                                    Dictionary<string, string> headers = null!)
    {
        HttpResponseMessage response = await ReponseMessage(method, Url, postData, cookies, headers);

        if (response == null)
            return (null, null)!;

        var bytes = await response.Content.ReadAsByteArrayAsync();
        var content = await response.Content.ReadAsStringAsync();
        RequestUri = response.RequestMessage?.RequestUri?.ToString()!;
        Headers = response.Headers;
        StatusCode = response.StatusCode;

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