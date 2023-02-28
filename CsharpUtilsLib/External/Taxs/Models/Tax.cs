namespace CsharpUtilsLib.External.Taxs.Models;

public sealed class Tax
{
    [Display(Name = "Nome"), JsonPropertyName("nome")]
    public string Nome { get; set; }

    [Display(Name = "Valor"), JsonPropertyName("valor")]
    public double Valor { get; set; }
}