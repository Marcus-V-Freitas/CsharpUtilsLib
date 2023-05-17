namespace CsharpUtilsLib.Http;

public interface IHttpWrapper
{
    HttpResponseHeaders ResponseHeaders { get; }
    HttpStatusCode StatusCode { get; }
    string ReasonPhrase { get; }
    WebProxy Proxy { get; }
    bool KeepAlive { get; set; }
    Dictionary<string, string> Headers { get; set; }
    List<KeyValuePair<string, string>> Cookies { get; set; }
    int TimeoutSeconds { get; set; }
    string RequestUri { get; }
    string ErrorMessage { get; }
    List<Cookie> ResponseCookies { get; }

    #region Specific Headers

    string UserAgent { get; set; }
    string Accept { get; set; }
    string Host { get; set; }
    string Referrer { get; set; }
    string AcceptEncoding { get; set; }
    string Origin { get; set; }
    string AcceptLanguage { get; set; }

    #endregion

    Task<HtmlString> HtmlGET(string Url, bool lowerCaseKeepAlive = false);

    Task<HtmlString> HtmlPOST(string Url, HttpContent postData = null!, bool lowerCaseKeepAlive = false);

    Task<string> GET(string Url, bool lowerCaseKeepAlive = false);

    Task<string> POST(string Url, HttpContent postData = null!, bool lowerCaseKeepAlive = false);

    Task<string> PUT(string Url, HttpContent postData = null!, bool lowerCaseKeepAlive = false);

    Task<string> DELETE(string Url, bool lowerCaseKeepAlive = false);

    Task<byte[]> BytesGET(string Url, bool lowerCaseKeepAlive = false);

    Task<byte[]> BytesPOST(string Url, HttpContent postData = null!, bool lowerCaseKeepAlive = false);
}
