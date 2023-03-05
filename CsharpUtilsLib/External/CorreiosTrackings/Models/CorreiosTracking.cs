namespace CsharpUtilsLib.External.CorreiosTrackings.Models;

public sealed class CorreiosTracking
{
    [Display(Name = "Status"), JsonPropertyName("status")]
    public string Status { get; set; }

    [Display(Name = "Data"), JsonPropertyName("date")]
    public DateTime? Data { get; set; }

    [Display(Name = "Local"), JsonPropertyName("local")]
    public string Local { get; set; }

    [Display(Name = "Origem"), JsonPropertyName("origem")]
    public string Origem { get; set; }

    [Display(Name = "Destino"), JsonPropertyName("destino")]
    public string Destino { get; set; }
}