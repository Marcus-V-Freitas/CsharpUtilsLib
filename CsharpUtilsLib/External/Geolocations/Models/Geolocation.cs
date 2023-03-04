namespace CsharpUtilsLib.External.Geolocations.Models;

public sealed class Geolocation
{
    [Display(Name = "Id"), JsonPropertyName("id")]
    public int? Id { get; set; }

    [Display(Name = "Name"), JsonPropertyName("name")]
    public string Name { get; set; }

    [Display(Name = "Latitude"), JsonPropertyName("latitude")]
    public double? Latitude { get; set; }

    [Display(Name = "Longitude"), JsonPropertyName("longitude")]
    public double? Longitude { get; set; }

    [Display(Name = "Elevation"), JsonPropertyName("elevation")]
    public double? Elevation { get; set; }

    [Display(Name = "Feature Code"), JsonPropertyName("feature_code")]
    public string FeatureCode { get; set; }

    [Display(Name = "Country Code"), JsonPropertyName("country_code")]
    public string CountryCode { get; set; }

    [Display(Name = "Admin 1 Id"), JsonPropertyName("admin1_id")]
    public int? Admin1Id { get; set; }

    [Display(Name = "TimeZone"), JsonPropertyName("timezone")]
    public string Timezone { get; set; }

    [Display(Name = "Population"), JsonPropertyName("population")]
    public int? Population { get; set; }

    [Display(Name = "Country Id"), JsonPropertyName("country_id")]
    public int? CountryId { get; set; }

    [Display(Name = "Country"), JsonPropertyName("country")]
    public string Country { get; set; }

    [Display(Name = "Admin 1"), JsonPropertyName("admin1")]
    public string Admin1 { get; set; }

    [Display(Name = "Admin 2 Id"), JsonPropertyName("admin2_id")]
    public int? Admin2Id { get; set; }

    [Display(Name = "Admin 2"), JsonPropertyName("admin2")]
    public string Admin2 { get; set; }

    [Display(Name = "Admin 3 Id"), JsonPropertyName("admin3_id")]
    public int? Admin3Id { get; set; }

    [Display(Name = "Admin 3"), JsonPropertyName("admin3")]
    public string Admin3 { get; set; }
}