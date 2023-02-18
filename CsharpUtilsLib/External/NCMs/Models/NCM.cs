namespace CsharpUtilsLib.External.NCMs.Models;

public sealed class NCM
{
    private string _descricao;

    [JsonPropertyName("codigo")]
    public string Codigo { get; set; }

    [JsonPropertyName("descricao")]
    public string Descricao { get => _descricao; set => _descricao = value.Replace("-- ", "").Replace("- ", ""); }

    [JsonPropertyName("data_inicio")]
    public string DataInicio { get; set; }

    [JsonPropertyName("data_fim")]
    public string DataFim { get; set; }

    [JsonPropertyName("tipo_ato")]
    public string TipoAto { get; set; }

    [JsonPropertyName("numero_ato")]
    public string NumeroAto { get; set; }

    [JsonPropertyName("ano_ato")]
    public string AnoAto { get; set; }
}