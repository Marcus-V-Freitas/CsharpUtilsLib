namespace CsharpUtilsLib.Web.Html;

public sealed class HtmlString
{
    private readonly string _html;
    private readonly HtmlDocument _htmlDocument;

    private HtmlString(string html, bool autoCloseTags = false)
    {
        Id = $"{Guid.NewGuid()}";
        _html = WebUtility.HtmlDecode(html);
        _htmlDocument = CreateHtmlDocument(autoCloseTags);
    }

    public static HtmlString Instance(string html = "", bool autoCloseTags = false)
    {
        return new HtmlString(html, autoCloseTags);
    }

    public string Id { get; init; }

    public HtmlDocument Document { get => _htmlDocument; }

    public string ToHtmlString { get => _html; }

    public bool IsNullOrEmpty { get => string.IsNullOrEmpty(_html); }

    private HtmlDocument CreateHtmlDocument(bool autoCloseTags)
    {
        var doc = new HtmlDocument()
        {
            OptionAutoCloseOnEnd = autoCloseTags
        };

        if (!string.IsNullOrEmpty(ToHtmlString))
        {
            doc.LoadHtml(ToHtmlString);
        }
        return doc;
    }

    public Dictionary<string, string> ExtractTableInfo(string nodeXPath, bool normalize = true)
    {
        var extracted = new Dictionary<string, string>();
        var tableNode = ExtractSingleNode(nodeXPath);

        if (tableNode == null)
        {
            return extracted;
        }

        var thNodes = tableNode.SelectNodes(".//th");
        var tdNodes = tableNode.SelectNodes(".//td");

        if (thNodes == null || tdNodes == null || thNodes.Count != tdNodes.Count)
        {
            return extracted;
        }

        foreach (int index in Enumerable.Range(0, thNodes.Count))
        {
            string key = thNodes[index].InnerText;
            string value = tdNodes[index].InnerText;
            extracted.Add(normalize ? Web.ClearHtml(key) : key, normalize ? Web.ClearHtml(value) : value);
        }
        return extracted;
    }

    public string ExtractSingleInfo(string nodeXPath, bool normalize = true)
    {
        HtmlNode node = ExtractSingleNode(nodeXPath);

        if (node != null)
        {
            return normalize ? Web.ClearHtml(node.InnerText) : node.InnerText;
        }

        return string.Empty;
    }

    public List<string> ExtractListInfo(string nodeXPath, bool normalize = true)
    {
        var infos = new List<string>();
        var nodes = ExtractNodeCollection(nodeXPath);

        if (nodes.ListIsNullOrEmpty())
        {
            return infos;
        }

        foreach (var node in nodes)
        {
            string info = normalize ? Web.ClearHtml(node.InnerText) : node.InnerText;

            if (!string.IsNullOrEmpty(info))
            {
                infos.AddIfNotNull(info);
            }
        }
        return infos;
    }

    public string ExtractSingleInfoAttribute(string nodeXPath, string attributeName, bool normalize = true)
    {
        HtmlNode node = ExtractSingleNode(nodeXPath);

        if (node == null)
        {
            return string.Empty;
        }

        string value = node.GetAttributeValue(attributeName, null);
        value = normalize ? Web.ClearHtml(value) : value;

        if (!string.IsNullOrEmpty(value))
        {
            return value;
        }

        return string.Empty;
    }

    public List<string> ExtractListInfoAttributes(string nodeXPath, string attributeName, bool normalize = true)
    {
        var infos = new List<string>();
        var nodes = ExtractNodeCollection(nodeXPath);

        if (nodes.ListIsNullOrEmpty())
        {
            return infos;
        }

        foreach (var node in nodes)
        {
            string value = node.GetAttributeValue(attributeName, null);
            value = normalize ? Web.ClearHtml(value) : value;

            if (!string.IsNullOrEmpty(value))
            {
                infos.AddIfNotNull(value);
            }
        }
        return infos;
    }

    public HtmlNodeCollection ExtractNodeCollection(string nodeXPath)
    {
        return Document.DocumentNode.SelectNodes(nodeXPath);
    }

    public List<HtmlNode> ExtractListNodes(string nodeXPath)
    {
        return ExtractNodeCollection(nodeXPath).ToNullList();
    }

    public List<List<HtmlNode>> ExtractTableInternalNodes(string nodeTrXpath, string nodeTdXpath, bool removeEmpty = true)
    {
        var detailsNodes = new List<List<HtmlNode>>();
        var nodes = ExtractNodeCollection(nodeTrXpath);

        if (nodes.ListIsNullOrEmpty())
        {
            return null!;
        }

        foreach (var node in nodes)
        {
            var nodeInfos = node.SelectNodes(nodeTdXpath).ToNullList();

            if (removeEmpty)
            {
                nodeInfos = nodeInfos.Where(x => !string.IsNullOrEmpty(Web.ClearHtml(x.InnerText)))
                                     .ToNullList();
            }

            if (!nodeInfos.ListIsNullOrEmpty())
            {
                detailsNodes.AddIfNotNull(nodeInfos);
            }
        }

        return detailsNodes;
    }

    public HtmlNode ExtractSingleNode(string nodeXPath)
    {
        return Document.DocumentNode.SelectSingleNode(nodeXPath);
    }

    public bool ExistsInPage(params string[] terms)
    {
        return terms.Any(term => _html.Contains(term, StringComparison.OrdinalIgnoreCase));
    }

    public HtmlString Copy()
    {
        return (MemberwiseClone() as HtmlString)!;
    }
}