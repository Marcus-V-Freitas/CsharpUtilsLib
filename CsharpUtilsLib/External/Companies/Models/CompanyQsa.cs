namespace CsharpUtilsLib.External.Companies.Models;

public sealed class CompanyQsa
{
    [Display(Name = "Pa�s"), JsonPropertyName("pais")]
    public string Pais { get; set; }

    [Display(Name = "Nome do S�cio"), JsonPropertyName("nome_socio")]
    public string NomeSocio { get; set; }

    [Display(Name = "C�digo do Pa�s"), JsonPropertyName("codigo_pais")]
    public int? CodigoPais { get; set; }

    [Display(Name = "Faixa Et�ria"), JsonPropertyName("faixa_etaria")]
    public string FaixaEtaria { get; set; }

    [Display(Name = "CNPJ/CPF do S�cio"), JsonPropertyName("cnpj_cpf_do_socio")]
    public string CnpjCpfDoSocio { get; set; }

    [Display(Name = "Qualifica��o do S�cio"), JsonPropertyName("qualificacao_socio")]
    public string QualificacaoSocio { get; set; }

    [Display(Name = "C�digo da Faixa Et�ria"), JsonPropertyName("codigo_faixa_etaria")]
    public int? CodigoFaixaEtaria { get; set; }

    [Display(Name = "Data da Entrada na Sociedade"), JsonPropertyName("data_entrada_sociedade")]
    public string DataEntradaSociedade { get; set; }

    [Display(Name = "Identificador de S�cio"), JsonPropertyName("identificador_de_socio")]
    public int? IdentificadorDeSocio { get; set; }

    [Display(Name = "CPF do Representante Legal"), JsonPropertyName("cpf_representante_legal")]
    public string CpfRepresentanteLegal { get; set; }

    [Display(Name = "Nome do Representante Legal"), JsonPropertyName("nome_representante_legal")]
    public string NomeRepresentanteLegal { get; set; }

    [Display(Name = "C�digo da Qualifica��o do S�cio"), JsonPropertyName("codigo_qualificacao_socio")]
    public int? CodigoQualificacaoSocio { get; set; }

    [Display(Name = "Qualifica��o do Representante Legal"), JsonPropertyName("qualificacao_representante_legal")]
    public string QualificacaoRepresentanteLegal { get; set; }

    [Display(Name = "C�digo da Qualifica��o do Representante Legal"), JsonPropertyName("codigo_qualificacao_representante_legal")]
    public int? CodigoQualificacaoRepresentanteLegal { get; set; }
}