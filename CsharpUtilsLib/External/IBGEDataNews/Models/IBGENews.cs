namespace CsharpUtilsLib.External.IBGEDataNews.Models;

public sealed class IBGENews
{
    [Display(Name = "Id"), JsonPropertyName("id")]
    public int? Id { get; set; }

    [Display(Name = "Tipo"), JsonPropertyName("tipo")]
    public string Tipo { get; set; }

    [Display(Name = "Título"), JsonPropertyName("titulo")]
    public string Titulo { get; set; }

    [Display(Name = "Introducao"), JsonPropertyName("introducao")]
    public string Introducao { get; set; }

    [Display(Name = "Data Publicação"), JsonPropertyName("data_publicacao")]
    public string DataPublicacao { get; set; }

    [Display(Name = "Produto Id"), JsonPropertyName("produto_id")]
    public int? ProdutoId { get; set; }

    [Display(Name = "Produtos"), JsonPropertyName("produtos")]
    public string Produtos { get; set; }

    [Display(Name = "Editorias"), JsonPropertyName("editorias")]
    public string Editorias { get; set; }

    [Display(Name = "Imagens"), JsonPropertyName("imagens")]
    public string Imagens { get; set; }

    [Display(Name = "Produtos Relacionados"), JsonPropertyName("produtos_relacionados")]
    public string ProdutosRelacionados { get; set; }

    [Display(Name = "Destaque"), JsonPropertyName("destaque")]
    public bool? Destaque { get; set; }

    [Display(Name = "Link"), JsonPropertyName("link")]
    public string Link { get; set; }
}