namespace CsharpUtilsLib.External.IBGEDataNews.Models;

public sealed class SearchIBGENews
{
    [Display(Name = "Count"), JsonPropertyName("count")]
    public int? Count { get; set; }

    [Display(Name = "Page"), JsonPropertyName("page")]
    public int? Page { get; set; }

    [Display(Name = "Total Pages"), JsonPropertyName("totalPages")]
    public int? TotalPages { get; set; }

    [Display(Name = "Next Page"), JsonPropertyName("nextPage")]
    public int? NextPage { get; set; }

    [Display(Name = "Previous Page"), JsonPropertyName("previousPage")]
    public int? PreviousPage { get; set; }

    [Display(Name = "Showing From"), JsonPropertyName("showingFrom")]
    public int? ShowingFrom { get; set; }

    [Display(Name = "Showing To"), JsonPropertyName("showingTo")]
    public int? ShowingTo { get; set; }

    [Display(Name = "Items"), JsonPropertyName("items")]
    public List<IBGENews> Items { get; set; }
}