namespace CsharpUtilsLib.Web.Pagination;

public sealed class PageMetaData
{
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPages;

    public PageMetaData()
    {
    }

    public PageMetaData(int totalRegisters, int skipRegisters, int takeRegisters) : this()
    {
        TotalPages = (int)Math.Ceiling(totalRegisters / (double)takeRegisters);
        CurrentPage = skipRegisters / takeRegisters + 1;
        PageSize = takeRegisters;
    }
}