namespace CsharpUtilsLib.Web;

public static class Web
{
    public static int Pagination(int totalRecords, int recordsPerPage)
    {
        return (totalRecords + recordsPerPage - 1) / recordsPerPage;
    }

    public static FormUrlEncodedContent ToFormPostData(this IDictionary<string, string> postData, string contentType = "application/x-www-form-urlencoded", string charset = "UTF-8")
    {
        var content = new FormUrlEncodedContent(postData);
        content.Headers.ContentType = new MediaTypeHeaderValue(contentType);
        content.Headers.ContentType.CharSet = charset;
        return content;
    }

    public static FormUrlEncodedContent ToFormPostData(this IEnumerable<KeyValuePair<string, string>> postData, string contentType = "application/x-www-form-urlencoded", string charset = "UTF-8")
    {
        var content = new FormUrlEncodedContent(postData);
        content.Headers.ContentType = new MediaTypeHeaderValue(contentType);
        content.Headers.ContentType.CharSet = charset;
        return content;
    }

    public static StringContent ToJsonPostData<T>(this T postData, Encoding encoding = null!, string contentType = "application/json") where T : class
    {
        encoding ??= Encoding.UTF8;

        return new StringContent(JsonSerializer.Serialize(postData), encoding, contentType);
    }

    public static string GetQueryStringValue(string url, string queryString)
    {
        if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(queryString))
        {
            return null!;
        }

        var uri = new Uri(url);
        var queryParams = QueryHelpers.ParseQuery(uri.Query);

        if (queryParams.TryGetValue(queryString, out StringValues value))
        {
            return value.FirstOrDefault()!;
        }
        return null!;
    }

    public static Dictionary<string, StringValues> GetAllQueryStringValues(string url)
    {
        if (string.IsNullOrEmpty(url))
        {
            return null!;
        }

        var uri = new Uri(url);
        return QueryHelpers.ParseQuery(uri.Query);
    }

    public static string AddQueryString(string url, string queryString, string value)
    {
        if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(queryString) || string.IsNullOrEmpty(value))
        {
            return null!;
        }

        var queryStringParam = new Dictionary<string, string>()
        {
            { queryString, value }
        };

        return QueryHelpers.AddQueryString(url, queryStringParam);
    }

    public static string AddQueryString(string url, Dictionary<string, string> queryParams)
    {
        if (!string.IsNullOrEmpty(url) || !queryParams.DictionaryIsNullOrEmpty())
        {
            return new Uri(QueryHelpers.AddQueryString(url, queryParams)).AbsoluteUri;
        }

        return url;
    }

    public static bool IsValidUrl(string url)
    {
        return Uri.TryCreate(url, UriKind.Absolute, out Uri? result)
            && (result.Scheme == Uri.UriSchemeHttp || result.Scheme == Uri.UriSchemeHttps);
    }

    public static string GetHeader(this HttpHeaders headers, string headerName)
    {
        if (headers.TryGetValues(headerName, out var value))
        {
            return value.FirstOrDefault()!;
        }

        return null!;
    }

    public static string CombineUrl(string baseUrl, string relativeUrl)
    {
        UriBuilder baseUri = new(baseUrl);

        if (Uri.TryCreate(baseUri.Uri, relativeUrl, out Uri? newUri))
        {
            return newUri.ToString();
        }
        else
        {
            throw new ArgumentException("Unable to combine specified url values");
        }
    }

    public static string ClearHtml(string html)
    {
        if (string.IsNullOrEmpty(html))
        {
            return null!;
        }

        return Regex.Replace(html, @"\r\n?|\n|\t", "", RegexOptions.Compiled).Trim();
    }
}