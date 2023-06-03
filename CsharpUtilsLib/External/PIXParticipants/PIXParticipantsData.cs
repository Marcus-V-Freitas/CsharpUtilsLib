namespace CsharpUtilsLib.External.PIXParticipants
{
    public sealed class PIXParticipantsData : BaseExternalData<List<PixParticipant>>
    {
        protected override string Url => "https://brasilapi.com.br/api/pix/v1/participants";

        public async Task<List<PixParticipant>> GetPixParticipants()
        {
            return await Request(parameters: string.Empty);
        }
    }
}
