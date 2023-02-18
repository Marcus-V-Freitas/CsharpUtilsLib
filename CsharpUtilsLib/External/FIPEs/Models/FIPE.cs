namespace CsharpUtilsLib.External.FIPEs.Models;

public sealed class FIPE
{
    private string _modelo;

    [JsonPropertyName("valor")]
    public string Valor { get; set; }

    [JsonPropertyName("marca")]
    public string Marca { get; set; }

    [JsonPropertyName("modelo")]
    public string Modelo { get => _modelo; set => _modelo = value.Trim(); }

    [JsonPropertyName("anoModelo")]
    public int AnoModelo { get; set; }

    [JsonPropertyName("combustivel")]
    public string Combustivel { get; set; }

    [JsonPropertyName("codigoFipe")]
    public string CodigoFipe { get; set; }

    [JsonPropertyName("mesReferencia")]
    public string MesReferencia { get; set; }

    [JsonPropertyName("tipoVeiculo")]
    public int TipoVeiculo { get; set; }

    [JsonPropertyName("siglaCombustivel")]
    public string SiglaCombustivel { get; set; }

    [JsonPropertyName("dataConsulta")]
    public string DataConsulta { get; set; }
}