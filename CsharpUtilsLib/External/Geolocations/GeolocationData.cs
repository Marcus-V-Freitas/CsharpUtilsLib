namespace CsharpUtilsLib.External.Geolocations;

public sealed class GeolocationData : BaseExternalData<SearchGeolocation>
{
    protected override string Url => "https://geocoding-api.open-meteo.com/v1/search?name={0}";

    public async Task<SearchGeolocation> GetInfosFromCityName(string cityName)
    {
        return await Request(parameters: Uri.EscapeDataString(cityName.ToLower()));
    }
}