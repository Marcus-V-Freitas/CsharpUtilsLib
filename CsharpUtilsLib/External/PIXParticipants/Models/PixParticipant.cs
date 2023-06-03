namespace CsharpUtilsLib.External.PIXParticipants.Models
{
    public sealed class PixParticipant
    {
        [Display(Name = "ISPB"), JsonPropertyName("ispb")]
        public string Ispb { get; set; }

        [Display(Name = "Nome"), JsonPropertyName("nome")]
        public string Nome { get; set; }

        [Display(Name = "Nome Reduzido"), JsonPropertyName("nome_reduzido")]
        public string NomeReduzido { get; set; }

        [Display(Name = "Modalidade de Participação"), JsonPropertyName("modalidade_participacao")]
        public string ModalidadeParticipacao { get; set; }

        [Display(Name = "Tipo de Participação"), JsonPropertyName("tipo_participacao")]
        public string TipoParticipacao { get; set; }

        [Display(Name = "Início da Operação"), JsonPropertyName("inicio_operacao")]
        public DateTime InicioOperacao { get; set; }
    }
}
