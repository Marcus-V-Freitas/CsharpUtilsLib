namespace CsharpUtilsLib.External.IPs.Models;

public sealed class IP
{
    [Display(Name = "IP"), JsonPropertyName("ip")]
    public string Ip { get; set; }

    [Display(Name = "NetWork"), JsonPropertyName("network")]
    public string Network { get; set; }

    [Display(Name = "Version"), JsonPropertyName("version")]
    public string Version { get; set; }

    [Display(Name = "City"), JsonPropertyName("city")]
    public string City { get; set; }

    [Display(Name = "Region"), JsonPropertyName("region")]
    public string Region { get; set; }

    [Display(Name = "Region Code"), JsonPropertyName("region_code")]
    public string RegionCode { get; set; }

    [Display(Name = "Country"), JsonPropertyName("country")]
    public string Country { get; set; }

    [Display(Name = "Country Name"), JsonPropertyName("country_name")]
    public string CountryName { get; set; }

    [Display(Name = "Country Code"), JsonPropertyName("country_code")]
    public string CountryCode { get; set; }

    [Display(Name = "Country Code ISO-3"), JsonPropertyName("country_code_iso3")]
    public string CountryCodeIso3 { get; set; }

    [Display(Name = "Country Capital"), JsonPropertyName("country_capital")]
    public string CountryCapital { get; set; }

    [Display(Name = "Country TLD"), JsonPropertyName("country_tld")]
    public string CountryTld { get; set; }

    [Display(Name = "Continent Code"), JsonPropertyName("continent_code")]
    public string ContinentCode { get; set; }

    [Display(Name = "IN EU"), JsonPropertyName("in_eu")]
    public bool InEu { get; set; }

    [Display(Name = "Postal"), JsonPropertyName("postal")]
    public string Postal { get; set; }

    [Display(Name = "Latitude"), JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [Display(Name = "Longitude"), JsonPropertyName("longitude")]
    public double Longitude { get; set; }

    [Display(Name = "TimeZone"), JsonPropertyName("timezone")]
    public string Timezone { get; set; }

    [Display(Name = "UTC Offset"), JsonPropertyName("utc_offset")]
    public string UtcOffset { get; set; }

    [Display(Name = "Country Calling Code"), JsonPropertyName("country_calling_code")]
    public string CountryCallingCode { get; set; }

    [Display(Name = "Currency"), JsonPropertyName("currency")]
    public string Currency { get; set; }

    [Display(Name = "Currency Name"), JsonPropertyName("currency_name")]
    public string CurrencyName { get; set; }

    [Display(Name = "Languages"), JsonPropertyName("languages")]
    public string Languages { get; set; }

    [Display(Name = "Country Area"), JsonPropertyName("country_area")]
    public double CountryArea { get; set; }

    [Display(Name = "Country Population"), JsonPropertyName("country_population")]
    public int CountryPopulation { get; set; }

    [Display(Name = "ASN"), JsonPropertyName("asn")]
    public string Asn { get; set; }

    [Display(Name = "ORG"), JsonPropertyName("org")]
    public string Org { get; set; }
}