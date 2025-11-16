namespace CsharpUtilsLib.Web.Pagination;

public sealed class CurrentPage(int page, bool enabled, string text)
{
    public string Text { get; set; } = text;
    public int Page { get; set; } = page;
    public bool Enabled { get; set; } = enabled;
    public bool Active { get; set; }
}