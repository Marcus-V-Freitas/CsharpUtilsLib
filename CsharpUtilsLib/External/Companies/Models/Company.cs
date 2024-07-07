namespace CsharpUtilsLib.External.Companies.Models;

public sealed class Company
{
    [Display(Name = "UF"), JsonPropertyName("uf")]
    public string Uf { get; set; }

    [Display(Name = "CEP"), JsonPropertyName("cep")]
    public string Cep { get; set; }

    [Display(Name = "QSA"), JsonPropertyName("qsa")]
    public List<CompanyQsa> Qsa { get; set; }

    [Display(Name = "CNPJ"), JsonPropertyName("cnpj")]
    public string Cnpj { get; set; }

    [Display(Name = "Pa�s"), JsonPropertyName("pais")]
    public string Pais { get; set; }

    [Display(Name = "E-mail"), JsonPropertyName("email")]
    public string Email { get; set; }

    [Display(Name = "Porte"), JsonPropertyName("porte")]
    public string Porte { get; set; }

    [Display(Name = "Bairro"), JsonPropertyName("bairro")]
    public string Bairro { get; set; }

    [Display(Name = "N�mero"), JsonPropertyName("numero")]
    public string Numero { get; set; }

    [Display(Name = "FAX"), JsonPropertyName("ddd_fax")]
    public string DddFax { get; set; }

    [Display(Name = "Munic�pio"), JsonPropertyName("municipio")]
    public string Municipio { get; set; }

    [Display(Name = "Logradouro"), JsonPropertyName("logradouro")]
    public string Logradouro { get; set; }

    [Display(Name = "CNAE Fiscal"), JsonPropertyName("cnae_fiscal")]
    public int? CnaeFiscal { get; set; }

    [Display(Name = "C�digo do Pa�s"), JsonPropertyName("codigo_pais")]
    public int? CodigoPais { get; set; }

    [Display(Name = "Complemento"), JsonPropertyName("complemento")]
    public string Complemento { get; set; }

    [Display(Name = "UF"), JsonPropertyName("codigo_porte")]
    public int? CodigoPorte { get; set; }

    [Display(Name = "Raz�o Social"), JsonPropertyName("razao_social")]
    public string RazaoSocial { get; set; }

    [Display(Name = "Nome Fantasia"), JsonPropertyName("nome_fantasia")]
    public string NomeFantasia { get; set; }

    [Display(Name = "Capital Social"), JsonPropertyName("capital_social")]
    public double? CapitalSocial { get; set; }

    [Display(Name = "Telefone 1"), JsonPropertyName("ddd_telefone_1")]
    public string DddTelefone1 { get; set; }

    [Display(Name = "Telefone 2"), JsonPropertyName("ddd_telefone_2")]
    public string DddTelefone2 { get; set; }

    [Display(Name = "Op��o pelo MEI"), JsonPropertyName("opcao_pelo_mei")]
    public bool? OpcaoPeloMei { get; set; }

    [Display(Name = "Descri��o do Porte"), JsonPropertyName("descricao_porte")]
    public string DescricaoPorte { get; set; }

    [Display(Name = "C�digo do Munic�pio"), JsonPropertyName("codigo_municipio")]
    public int? CodigoMunicipio { get; set; }

    [Display(Name = "CNAE's Secund�rios"), JsonPropertyName("cnaes_secundarios")]
    public List<CompanySecondaryCnae> CnaesSecundarios { get; set; }

    [Display(Name = "Natureza Jur�dica"), JsonPropertyName("natureza_juridica")]
    public string NaturezaJuridica { get; set; }

    [Display(Name = "Situa��o Especial"), JsonPropertyName("situacao_especial")]
    public string SituacaoEspecial { get; set; }

    [Display(Name = "Op��o pelo Simples"), JsonPropertyName("opcao_pelo_simples")]
    public bool? OpcaoPeloSimples { get; set; }

    [Display(Name = "Situa��o Cadastral"), JsonPropertyName("situacao_cadastral")]
    public int? SituacaoCadastral { get; set; }

    [Display(Name = "Data da Op��o pelo MEI"), JsonPropertyName("data_opcao_pelo_mei")]
    public string DataOpcaoPeloMei { get; set; }

    [Display(Name = "Data da Exclus�o do MEI"), JsonPropertyName("data_exclusao_do_mei")]
    public string DataExclusaoDoMei { get; set; }

    [Display(Name = "CNAE FISCAL"), JsonPropertyName("cnae_fiscal_descricao")]
    public string CnaeFiscalDescricao { get; set; }

    [Display(Name = "C�digo Munic�pio do IBGE"), JsonPropertyName("codigo_municipio_ibge")]
    public int? CodigoMunicipioIbge { get; set; }

    [Display(Name = "Data de In�cio das Atividades"), JsonPropertyName("data_inicio_atividade")]
    public string DataInicioAtividade { get; set; }

    [Display(Name = "Data da Situa��o Especial"), JsonPropertyName("data_situacao_especial")]
    public string DataSituacaoEspecial { get; set; }

    [Display(Name = "Data da Op��o pelo Simples"), JsonPropertyName("data_opcao_pelo_simples")]
    public string DataOpcaoPeloSimples { get; set; }

    [Display(Name = "Data da Situa��o Cadastral"), JsonPropertyName("data_situacao_cadastral")]
    public string DataSituacaoCadastral { get; set; }

    [Display(Name = "Nome da Cidade no Exterior"), JsonPropertyName("nome_cidade_no_exterior")]
    public string NomeCidadeNoExterior { get; set; }

    [Display(Name = "C�digo da Natureza Jur�dica"), JsonPropertyName("codigo_natureza_juridica")]
    public int? CodigoNaturezaJuridica { get; set; }

    [Display(Name = "Data da Exclus�o do Simples"), JsonPropertyName("data_exclusao_do_simples")]
    public string DataExclusaoDoSimples { get; set; }

    [Display(Name = "Motivo da Situa��o Cadastral"), JsonPropertyName("motivo_situacao_cadastral")]
    public int? MotivoSituacaoCadastral { get; set; }

    [Display(Name = "Ente Federativo Respons�vel"), JsonPropertyName("ente_federativo_responsavel")]
    public string EnteFederativoResponsavel { get; set; }

    [Display(Name = "Identificador da Matriz/Filial"), JsonPropertyName("identificador_matriz_filial")]
    public int? IdentificadorMatrizFilial { get; set; }

    [Display(Name = "Qualifica��o do Respons�vel"), JsonPropertyName("qualificacao_do_responsavel")]
    public int? QualificacaoDoResponsavel { get; set; }

    [Display(Name = "Descri��o da Situa��o Cadastral"), JsonPropertyName("descricao_situacao_cadastral")]
    public string DescricaoSituacaoCadastral { get; set; }

    [Display(Name = "Descri��o do Tipo de Logradouro"), JsonPropertyName("descricao_tipo_de_logradouro")]
    public string DescricaoTipoDeLogradouro { get; set; }

    [Display(Name = "Descri��o do Motivo da Situa��o Cadastral"), JsonPropertyName("descricao_motivo_situacao_cadastral")]
    public string DescricaoMotivoSituacaoCadastral { get; set; }

    [Display(Name = "Descri��o Identificador da Matriz/Filial"), JsonPropertyName("descricao_identificador_matriz_filial")]
    public string DescricaoIdentificadorMatrizFilial { get; set; }
}