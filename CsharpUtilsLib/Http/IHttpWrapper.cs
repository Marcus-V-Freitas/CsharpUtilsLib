namespace CsharpUtilsLib.Http;

public interface IHttpWrapper : IDisposable
{
    HttpResponseHeaders ResponseHeaders { get; }
    HttpStatusCode StatusCode { get; }
    string ReasonPhrase { get; }
    WebProxy Proxy { get; }
    Encoding Encoding { get; set; }
    string ContentType { get; set; }
    bool KeepAlive { get; set; }
    Dictionary<string, string> Headers { get; set; }
    List<KeyValuePair<string, string>> Cookies { get; set; }
    int TimeoutSeconds { get; set; }
    string RequestUri { get; }
    string ErrorMessage { get; }
    long? ContentLength { get; }
    string Version { get; }
    List<Cookie> ResponseCookies { get; }

    #region Specific Headers

    string AcceptCharset { get; set; }
    string Authorization { get; set; }
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

    Task<HtmlString> HtmlPOST(string Url, string rawPostData = null!, bool lowerCaseKeepAlive = false);

    Task<HtmlString> HtmlPUT(string Url, HttpContent postData = null!, bool lowerCaseKeepAlive = false);

    Task<HtmlString> HtmlPUT(string Url, string rawPostData = null!, bool lowerCaseKeepAlive = false);

    Task<HtmlString> HtmlDELETE(string Url, bool lowerCaseKeepAlive = false);

    Task<T> GET<T>(string Url, bool lowerCaseKeepAlive = false) where T : class;

    Task<T> POST<T>(string Url, HttpContent postData = null!, bool lowerCaseKeepAlive = false) where T : class;

    Task<T> POST<T>(string Url, string rawPostData = null!, bool lowerCaseKeepAlive = false) where T : class;

    Task<T> PUT<T>(string Url, HttpContent postData = null!, bool lowerCaseKeepAlive = false) where T : class;

    Task<T> PUT<T>(string Url, string rawPostData = null!, bool lowerCaseKeepAlive = false) where T : class;

    Task<T> DELETE<T>(string Url, bool lowerCaseKeepAlive = false) where T : class;

    Task<string> GET(string Url, bool lowerCaseKeepAlive = false);

    Task<string> POST(string Url, HttpContent postData = null!, bool lowerCaseKeepAlive = false);

    Task<string> POST(string Url, string rawPostData = null!, bool lowerCaseKeepAlive = false);

    Task<string> PUT(string Url, HttpContent postData = null!, bool lowerCaseKeepAlive = false);

    Task<string> PUT(string Url, string rawPostData = null!, bool lowerCaseKeepAlive = false);

    Task<string> DELETE(string Url, bool lowerCaseKeepAlive = false);

    Task<byte[]> BytesGET(string Url, bool lowerCaseKeepAlive = false);

    Task<byte[]> BytesPOST(string Url, HttpContent postData = null!, bool lowerCaseKeepAlive = false);

    Task<byte[]> BytesPOST(string Url, string rawPostData = null!, bool lowerCaseKeepAlive = false);

    Task<byte[]> BytesPUT(string Url, HttpContent postData = null!, bool lowerCaseKeepAlive = false);

    Task<byte[]> BytesPUT(string Url, string rawPostData = null!, bool lowerCaseKeepAlive = false);

    Task<byte[]> BytesDELETE(string Url, bool lowerCaseKeepAlive = false);
}
