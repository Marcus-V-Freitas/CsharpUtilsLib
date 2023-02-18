namespace CsharpUtilsLib.External.Taxs.Models;

public sealed class Tax
{
    [JsonPropertyName("nome")]
    public string Nome { get; set; }

    [JsonPropertyName("valor")]
    public double Valor { get; set; }
}