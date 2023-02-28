namespace CsharpUtilsLib.External.FIPEs.Models;

public sealed class FIPE
{
    private string _modelo;

    [Display(Name = "Valor"), JsonPropertyName("valor")]
    public string Valor { get; set; }

    [Display(Name = "Marca"), JsonPropertyName("marca")]
    public string Marca { get; set; }

    [Display(Name = "Modelo"), JsonPropertyName("modelo")]
    public string Modelo { get => _modelo; set => _modelo = value.Trim(); }

    [Display(Name = "Ano do Modelo"), JsonPropertyName("anoModelo")]
    public int AnoModelo { get; set; }

    [Display(Name = "Combustível"), JsonPropertyName("combustivel")]
    public string Combustivel { get; set; }

    [Display(Name = "Código da FIPE"), JsonPropertyName("codigoFipe")]
    public string CodigoFipe { get; set; }

    [Display(Name = "Mês de Referência"), JsonPropertyName("mesReferencia")]
    public string MesReferencia { get; set; }

    [Display(Name = "Tipo de Veículo"), JsonPropertyName("tipoVeiculo")]
    public int TipoVeiculo { get; set; }

    [Display(Name = "Sigla do Combustível"), JsonPropertyName("siglaCombustivel")]
    public string SiglaCombustivel { get; set; }

    [Display(Name = "Data da Consulta"), JsonPropertyName("dataConsulta")]
    public string DataConsulta { get; set; }
}