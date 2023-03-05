namespace CsharpUtilsLib.External.IBGEDataNews;

public sealed class IBGENewsData : BaseExternalData<SearchIBGENews>
{
    protected override string Url => "https://servicodados.ibge.gov.br/api/v3/noticias?qtd={0}&de={1}&ate={2}&busca={3}&destaque={4}";

    public async Task<SearchIBGENews> GetNewsByPeriod(DateTime? startPeriod = null, DateTime? endPeriod = null, int pageSize = 10, string searchTerm = null!, bool sortByHighlights = true)
    {
        startPeriod ??= DateTime.Now.AddDays(-1);
        endPeriod ??= DateTime.Now;

        return await Request(endpoint: null!, pageSize.ToString(), startPeriod?.ToString("dd/MM/yyyy")!, endPeriod?.ToString("dd/MM/yyyy")!, searchTerm?.ToString()!, sortByHighlights ? "1" : "0");
    }
}