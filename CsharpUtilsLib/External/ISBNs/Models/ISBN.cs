namespace CsharpUtilsLib.External.ISBNs.Models;

public sealed class ISBN
{
    [Display(Name = "ISBN"), JsonPropertyName("isbn")]
    public string Isbn { get; set; }

    [Display(Name = "Title"), JsonPropertyName("title")]
    public string Title { get; set; }

    [Display(Name = "SubTitle"), JsonPropertyName("subtitle")]
    public string Subtitle { get; set; }

    [Display(Name = "Authors"), JsonPropertyName("authors")]
    public List<string> Authors { get; set; }

    [Display(Name = "Publisher"), JsonPropertyName("publisher")]
    public string Publisher { get; set; }

    [Display(Name = "Synopsis"), JsonPropertyName("synopsis")]
    public string Synopsis { get; set; }

    [Display(Name = "Dimensions"), JsonPropertyName("dimensions")]
    public Dimensions Dimensions { get; set; }

    [Display(Name = "Year"), JsonPropertyName("year")]
    public int Year { get; set; }

    [Display(Name = "Format"), JsonPropertyName("format")]
    public string Format { get; set; }

    [Display(Name = "Page Count"), JsonPropertyName("page_count")]
    public int PageCount { get; set; }

    [Display(Name = "Subjects"), JsonPropertyName("subjects")]
    public List<string> Subjects { get; set; }

    [Display(Name = "Location"), JsonPropertyName("location")]
    public string Location { get; set; }

    [Display(Name = "Retail Price"), JsonPropertyName("retail_price")]
    public object RetailPrice { get; set; }

    [Display(Name = "Cover Url"), JsonPropertyName("cover_url")]
    public string CoverUrl { get; set; }

    [Display(Name = "Provider"), JsonPropertyName("provider")]
    public string Provider { get; set; }
}