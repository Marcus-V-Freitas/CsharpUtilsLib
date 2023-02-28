namespace CsharpUtilsLib.External.Location.Models.CEPs;

public sealed class CEP
{
    [Display(Name = "CEP"), JsonPropertyName("cep")]
    public string Cep { get; set; }

    [Display(Name = "Logradouro"), JsonPropertyName("logradouro")]
    public string Logradouro { get; set; }

    [Display(Name = "Complemento"), JsonPropertyName("complemento")]
    public string Complemento { get; set; }

    [Display(Name = "Bairro"), JsonPropertyName("bairro")]
    public string Bairro { get; set; }

    [Display(Name = "Localidade"), JsonPropertyName("localidade")]
    public string Localidade { get; set; }

    [Display(Name = "UF"), JsonPropertyName("uf")]
    public string Uf { get; set; }

    [Display(Name = "IBGE"), JsonPropertyName("ibge")]
    public string Ibge { get; set; }

    [Display(Name = "GIA"), JsonPropertyName("gia")]
    public string Gia { get; set; }

    [Display(Name = "DDD"), JsonPropertyName("ddd")]
    public string Ddd { get; set; }

    [Display(Name = "SIAFI"), JsonPropertyName("siafi")]
    public string Siafi { get; set; }
}