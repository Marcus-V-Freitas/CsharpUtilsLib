namespace CsharpUtilsLib.External.CorreiosShippings.Models;

public sealed class CorreiosService
{
    [Display(Name = "Código"), XmlElement(ElementName = "Codigo")]
    public string Codigo { get; set; }

    [Display(Name = "Valor"), XmlElement(ElementName = "Valor")]
    public string Valor { get; set; }

    [Display(Name = "Prazo de Entrega"), XmlElement(ElementName = "PrazoEntrega")]
    public string PrazoEntrega { get; set; }

    [Display(Name = "Valor Sem Adicionais"), XmlElement(ElementName = "ValorSemAdicionais")]
    public string ValorSemAdicionais { get; set; }

    [Display(Name = "Valor de Mão Própria"), XmlElement(ElementName = "ValorMaoPropria")]
    public string ValorMaoPropria { get; set; }

    [Display(Name = "Valor de Aviso de Recebimento"), XmlElement(ElementName = "ValorAvisoRecebimento")]
    public string ValorAvisoRecebimento { get; set; }

    [Display(Name = "Valor Declarado"), XmlElement(ElementName = "ValorValorDeclarado")]
    public string ValorDeclarado { get; set; }

    [Display(Name = "Entrega Domiciliar"), XmlElement(ElementName = "EntregaDomiciliar")]
    public string EntregaDomiciliar { get; set; }

    [Display(Name = "Entrega Sábado"), XmlElement(ElementName = "EntregaSabado")]
    public string EntregaSabado { get; set; }

    [Display(Name = "Observações Finais"), XmlElement(ElementName = "obsFim")]
    public string ObservacoesFinais { get; set; }

    [Display(Name = "Erro"), XmlElement(ElementName = "Erro")]
    public string Erro { get; set; }

    [Display(Name = "Mensagem De Erro"), XmlElement(ElementName = "MsgErro")]
    public string MensagemErro { get; set; }
}