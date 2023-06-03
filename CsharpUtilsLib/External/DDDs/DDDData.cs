namespace CsharpUtilsLib.External.DDDs
{
    public sealed class DDDData : BaseExternalData<DDD>
    {
        protected override string Url => "https://brasilapi.com.br/api/ddd/v1/{0}";

        public async Task<DDD> GetDDDInfos(string ddd)
        {
            return await Request(parameters: ddd);
        }
    }
}
