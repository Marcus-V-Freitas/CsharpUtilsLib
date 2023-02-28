namespace CsharpUtilsLib.External.NCMs.Models;

public sealed class NCM
{
    private string _descricao;

    [Display(Name = "C�digo"), JsonPropertyName("codigo")]
    public string Codigo { get; set; }

    [Display(Name = "Descri��o"), JsonPropertyName("descricao")]
    public string Descricao { get => _descricao; set => _descricao = value.Replace("-- ", "").Replace("- ", ""); }

    [Display(Name = "Data de In�cio"), JsonPropertyName("data_inicio")]
    public string DataInicio { get; set; }

    [Display(Name = "Data de Fim"), JsonPropertyName("data_fim")]
    public string DataFim { get; set; }

    [Display(Name = "Tipo de Ato"), JsonPropertyName("tipo_ato")]
    public string TipoAto { get; set; }

    [Display(Name = "N�mero do Ato"), JsonPropertyName("numero_ato")]
    public string NumeroAto { get; set; }

    [Display(Name = "Ano do Ato"), JsonPropertyName("ano_ato")]
    public string AnoAto { get; set; }
}