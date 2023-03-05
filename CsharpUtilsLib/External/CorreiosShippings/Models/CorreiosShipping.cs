namespace CsharpUtilsLib.External.CorreiosShippings.Models;

[XmlRoot(ElementName = "Servicos")]
public sealed class CorreiosShipping
{
    [Display(Name = "Serviço"), XmlElement(ElementName = "cServico")]
    public CorreiosService Servico { get; set; }
}