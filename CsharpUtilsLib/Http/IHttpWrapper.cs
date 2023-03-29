namespace CsharpUtilsLib.Http;

public interface IHttpWrapper
{
    int TimeoutSeconds { get; set; }
    string RequestUri { get; }
    string ErrorMessage { get; }
    HttpStatusCode StatusCode { get; }
    HttpResponseHeaders Headers { get; }
    Task<HtmlString> HtmlGET(string Url, List<KeyValuePair<string, string>> cookies = null!, Dictionary<string, string> headers = null!);

    Task<HtmlString> HtmlPOST(string Url, HttpContent postData = null!, List<KeyValuePair<string, string>> cookies = null!, Dictionary<string, string> headers = null!);

    Task<string> GET(string Url, List<KeyValuePair<string, string>> cookies = null!, Dictionary<string, string> headers = null!);

    Task<string> POST(string Url, HttpContent postData = null!, List<KeyValuePair<string, string>> cookies = null!, Dictionary<string, string> headers = null!);

    Task<string> PUT(string Url, HttpContent postData = null!, List<KeyValuePair<string, string>> cookies = null!, Dictionary<string, string> headers = null!);

    Task<string> DELETE(string Url, List<KeyValuePair<string, string>> cookies = null!, Dictionary<string, string> headers = null!);

    Task<byte[]> BytesGET(string Url, List<KeyValuePair<string, string>> cookies = null!, Dictionary<string, string> headers = null!);

    Task<byte[]> BytesPOST(string Url, HttpContent postData = null!, List<KeyValuePair<string, string>> cookies = null!, Dictionary<string, string> headers = null!);
}
