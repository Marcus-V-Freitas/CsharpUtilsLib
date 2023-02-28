namespace CsharpUtilsLib.External.Companies.Models;

public sealed class CompanySecondaryCnae
{
    [Display(Name = "C�digo"), JsonPropertyName("codigo")]
    public int? Codigo { get; set; }

    [Display(Name = "Descri��o"), JsonPropertyName("descricao")]
    public string Descricao { get; set; }
}