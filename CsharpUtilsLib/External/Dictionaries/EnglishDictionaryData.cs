namespace CsharpUtilsLib.External.Dictionaries;

public sealed class EnglishDictionaryData : BaseExternalData<List<EnglishDictionary>>
{
    protected override string Url => "https://api.dictionaryapi.dev/api/v2/entries/en/{0}";

    public async Task<List<EnglishDictionary>> GetDefinitionsFromWord(string word)
    {
        return await Request(parameters: word.ToLower());
    }
}