namespace CsharpUtilsLib.External.Companies.Models;

public sealed class CompanySecondaryCnae
{
    [JsonPropertyName("codigo")]
    public int? Codigo { get; set; }

    [JsonPropertyName("descricao")]
    public string Descricao { get; set; }
}