namespace CsharpUtilsLib.External.DDDs.Models
{
    public sealed class DDD
    {
        [Display(Name = "State"), JsonPropertyName("state")]
        public string State { get; set; }

        [Display(Name = "Cities"), JsonPropertyName("cities")]
        public List<string> Cities { get; set; }
    }
}
