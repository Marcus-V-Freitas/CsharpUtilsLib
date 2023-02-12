namespace CsharpUtilsLib.External.Location;

public static class Locations
{
    public static async Task<CEP> GetCEP(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return null!;
        }

        string url = $"https://viacep.com.br/ws/{Texts.RemoveDocumentMask(input)}/json/";

        var http = new HttpWrapper();

        return await http.GET<CEP>(url);
    }
}