namespace CsharpUtilsLib.External.Companies.Models;

public sealed class CompanyQsa
{
    [JsonPropertyName("pais")]
    public string Pais { get; set; }

    [JsonPropertyName("nome_socio")]
    public string NomeSocio { get; set; }

    [JsonPropertyName("codigo_pais")]
    public string CodigoPais { get; set; }

    [JsonPropertyName("faixa_etaria")]
    public string FaixaEtaria { get; set; }

    [JsonPropertyName("cnpj_cpf_do_socio")]
    public string CnpjCpfDoSocio { get; set; }

    [JsonPropertyName("qualificacao_socio")]
    public string QualificacaoSocio { get; set; }

    [JsonPropertyName("codigo_faixa_etaria")]
    public int? CodigoFaixaEtaria { get; set; }

    [JsonPropertyName("data_entrada_sociedade")]
    public string DataEntradaSociedade { get; set; }

    [JsonPropertyName("identificador_de_socio")]
    public int? IdentificadorDeSocio { get; set; }

    [JsonPropertyName("cpf_representante_legal")]
    public string CpfRepresentanteLegal { get; set; }

    [JsonPropertyName("nome_representante_legal")]
    public string NomeRepresentanteLegal { get; set; }

    [JsonPropertyName("codigo_qualificacao_socio")]
    public int? CodigoQualificacaoSocio { get; set; }

    [JsonPropertyName("qualificacao_representante_legal")]
    public string QualificacaoRepresentanteLegal { get; set; }

    [JsonPropertyName("codigo_qualificacao_representante_legal")]
    public int? CodigoQualificacaoRepresentanteLegal { get; set; }
}