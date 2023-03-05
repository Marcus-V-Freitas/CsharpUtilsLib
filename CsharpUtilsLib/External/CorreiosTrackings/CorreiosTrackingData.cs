namespace CsharpUtilsLib.External.CorreiosTrackings;

public sealed class CorreiosTrackingData : BaseExternalData<string>
{
    protected override string Url => "https://www.linkcorreios.com.br/{0}";

    public async Task<List<CorreiosTracking>> GetByTrackingCode(string trackingCode, bool asc = false)
    {
        var html = HtmlString.Instance(await Request(parameters: trackingCode));
        var nodes = html.ExtractTableInternalNodes(".//div[@class='singlepost']/ul[contains(@class,'linha_status')]", ".//li");

        if (nodes.ListIsNullOrEmpty())
        {
            return null!;
        }

        if (asc)
        {
            nodes.Reverse();
        }

        return ExtractTrackingsFromHtml(nodes);
    }

    private static List<CorreiosTracking> ExtractTrackingsFromHtml(List<List<HtmlNode>> nodes)
    {
        List<CorreiosTracking> correiosTrackings = new List<CorreiosTracking>();

        foreach (var node in nodes)
        {
            if (node.Count < 3 || node.Count > 4)
            {
                continue;
            }

            correiosTrackings.AddIfNotNull(CreateTracking(node));
        }

        return correiosTrackings;
    }

    private static string ClearHtmlText(List<HtmlNode> node, int index)
    {
        return Web.Web.ClearHtml(node.TryGetValue(index).InnerText
                                     .SpecificSplit(':', 2)
                                     .LastOrDefault()!);
    }

    private static CorreiosTracking CreateTracking(List<HtmlNode> node)
    {
        var correiosTracking = new CorreiosTracking()
        {
            Status = ClearHtmlText(node, 0),
            Data = ClearHtmlText(node, 1).ConvertToDatetime("dd/MM/yyyy | 'Hora:' HH:mm"),
        };

        if (node.Count == 3)
        {
            correiosTracking.Local = ClearHtmlText(node, 2);
        }
        else
        {
            correiosTracking.Origem = ClearHtmlText(node, 2);
            correiosTracking.Destino = ClearHtmlText(node, 3);
        }

        return correiosTracking;
    }
}