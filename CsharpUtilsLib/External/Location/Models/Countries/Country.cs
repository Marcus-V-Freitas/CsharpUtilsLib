namespace CsharpUtilsLib.External.Location.Models.Countries;

public sealed class Country
{
    [Display(Name = "Name"), JsonPropertyName("name")]
    public CountryName Name { get; set; }

    [Display(Name = "TLD"), JsonPropertyName("tld")]
    public List<string> Tld { get; set; }

    [Display(Name = "CCA2"), JsonPropertyName("cca2")]
    public string CCA2 { get; set; }

    [Display(Name = "CCN3"), JsonPropertyName("ccn3")]
    public string CCN3 { get; set; }

    [Display(Name = "CCA3"), JsonPropertyName("cca3")]
    public string CCA3 { get; set; }

    [Display(Name = "CIOC"), JsonPropertyName("cioc")]
    public string CIOC { get; set; }

    [Display(Name = "Independent"), JsonPropertyName("independent")]
    public bool Independent { get; set; }

    [Display(Name = "Status"), JsonPropertyName("status")]
    public string Status { get; set; }

    [Display(Name = "Un Member"), JsonPropertyName("unMember")]
    public bool UnMember { get; set; }

    [Display(Name = "Currencies"), JsonPropertyName("currencies")]
    public CountryCurrencies Currencies { get; set; }

    [Display(Name = "IDD"), JsonPropertyName("idd")]
    public CountryIdd Idd { get; set; }

    [Display(Name = "Capital"), JsonPropertyName("capital")]
    public List<string> Capital { get; set; }

    [Display(Name = "ALT Spellings"), JsonPropertyName("altSpellings")]
    public List<string> AltSpellings { get; set; }

    [Display(Name = "Region"), JsonPropertyName("region")]
    public string Region { get; set; }

    [Display(Name = "Subregion"), JsonPropertyName("subregion")]
    public string Subregion { get; set; }

    [Display(Name = "Languages"), JsonPropertyName("languages")]
    public CountryLanguages Languages { get; set; }

    [Display(Name = "Lat/Lng"), JsonPropertyName("latlng")]
    public List<double> LatLng { get; set; }

    [Display(Name = "Land Locked"), JsonPropertyName("landlocked")]
    public bool LandLocked { get; set; }

    [Display(Name = "Borders"), JsonPropertyName("borders")]
    public List<string> Borders { get; set; }

    [Display(Name = "Area"), JsonPropertyName("area")]
    public double Area { get; set; }

    [Display(Name = "Flag"), JsonPropertyName("flag")]
    public string Flag { get; set; }

    [Display(Name = "Maps"), JsonPropertyName("maps")]
    public CountryMaps Maps { get; set; }

    [Display(Name = "Population"), JsonPropertyName("population")]
    public int Population { get; set; }

    [Display(Name = "FIFA"), JsonPropertyName("fifa")]
    public string Fifa { get; set; }

    [Display(Name = "Car"), JsonPropertyName("car")]
    public CountryCar car { get; set; }

    [Display(Name = "TimeZones"), JsonPropertyName("timezones")]
    public List<string> Timezones { get; set; }

    [Display(Name = "Continents"), JsonPropertyName("continents")]
    public List<string> Continents { get; set; }

    [Display(Name = "Flags"), JsonPropertyName("flags")]
    public CountryFlags Flags { get; set; }

    [Display(Name = "Coat Of Arms"), JsonPropertyName("coatOfArms")]
    public CountryCoatOfArms CoatOfArms { get; set; }

    [Display(Name = "Start Of Week"), JsonPropertyName("startOfWeek")]
    public string StartOfWeek { get; set; }

    [Display(Name = "Capital Info"), JsonPropertyName("capitalInfo")]
    public CountryCapitalInfo CapitalInfo { get; set; }

    [Display(Name = "Postal Code"), JsonPropertyName("postalCode")]
    public CountryPostalCode PostalCode { get; set; }
}