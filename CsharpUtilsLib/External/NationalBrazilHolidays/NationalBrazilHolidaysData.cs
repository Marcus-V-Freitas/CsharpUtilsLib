namespace CsharpUtilsLib.External.NationalBrazilHolidays;

public sealed class NationalBrazilHolidaysData : BaseExternalData<List<NationalBrazilHoliday>>
{
    protected override string Url => "https://brasilapi.com.br/api/feriados/v1/{0}";

    public NationalBrazilHolidaysData() : base() { }

    public NationalBrazilHolidaysData(HttpWrapper http) : base(http) { }

    public async Task<List<NationalBrazilHoliday>> GetHolidaysByYear(string year)
    {
        return await Request(parameters: year);
    }
}