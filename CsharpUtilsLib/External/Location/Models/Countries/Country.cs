namespace CsharpUtilsLib.External.Location.Models.Countries;

public sealed class Country
{
    [JsonPropertyName("name")]
    public CountryName Name { get; set; }

    [JsonPropertyName("tld")]
    public List<string> Tld { get; set; }

    [JsonPropertyName("cca2")]
    public string CCA2 { get; set; }

    [JsonPropertyName("ccn3")]
    public string CCN3 { get; set; }

    [JsonPropertyName("cca3")]
    public string CCA3 { get; set; }

    [JsonPropertyName("cioc")]
    public string CIOC { get; set; }

    [JsonPropertyName("independent")]
    public bool Independent { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("unMember")]
    public bool UnMember { get; set; }

    [JsonPropertyName("currencies")]
    public CountryCurrencies Currencies { get; set; }

    [JsonPropertyName("idd")]
    public CountryIdd Idd { get; set; }

    [JsonPropertyName("capital")]
    public List<string> Capital { get; set; }

    [JsonPropertyName("altSpellings")]
    public List<string> AltSpellings { get; set; }

    [JsonPropertyName("region")]
    public string Region { get; set; }

    [JsonPropertyName("subregion")]
    public string Subregion { get; set; }

    [JsonPropertyName("languages")]
    public CountryLanguages Languages { get; set; }

    [JsonPropertyName("latlng")]
    public List<double> LatLng { get; set; }

    [JsonPropertyName("landlocked")]
    public bool LandLocked { get; set; }

    [JsonPropertyName("borders")]
    public List<string> Borders { get; set; }

    [JsonPropertyName("area")]
    public double Area { get; set; }

    [JsonPropertyName("flag")]
    public string Flag { get; set; }

    [JsonPropertyName("maps")]
    public CountryMaps Maps { get; set; }

    [JsonPropertyName("population")]
    public int Population { get; set; }

    [JsonPropertyName("fifa")]
    public string Fifa { get; set; }

    [JsonPropertyName("car")]
    public CountryCar car { get; set; }

    [JsonPropertyName("timezones")]
    public List<string> Timezones { get; set; }

    [JsonPropertyName("continents")]
    public List<string> Continents { get; set; }

    [JsonPropertyName("flags")]
    public CountryFlags Flags { get; set; }

    [JsonPropertyName("coatOfArms")]
    public CountryCoatOfArms CoatOfArms { get; set; }

    [JsonPropertyName("startOfWeek")]
    public string StartOfWeek { get; set; }

    [JsonPropertyName("capitalInfo")]
    public CountryCapitalInfo CapitalInfo { get; set; }

    [JsonPropertyName("postalCode")]
    public CountryPostalCode PostalCode { get; set; }
}