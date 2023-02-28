namespace CsharpUtilsLib.External.Companies.Models;

public sealed class CompanySecondaryCnae
{
    [Display(Name = "Código"), JsonPropertyName("codigo")]
    public int? Codigo { get; set; }

    [Display(Name = "Descrição"), JsonPropertyName("descricao")]
    public string Descricao { get; set; }
}