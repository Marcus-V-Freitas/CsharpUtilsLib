namespace CsharpUtilsLib.External.Temperatures;

public sealed class TemperatureData : BaseExternalData<Temperature>
{
    private const string _hourly = "temperature_2m,relativehumidity_2m,dewpoint_2m,apparent_temperature,precipitation_probability,precipitation,rain,showers,snowfall,snow_depth,freezinglevel_height,weathercode,pressure_msl,surface_pressure,cloudcover,cloudcover_low,cloudcover_mid,cloudcover_high,visibility,evapotranspiration,et0_fao_evapotranspiration,vapor_pressure_deficit,cape,windspeed_10m,windspeed_80m,windspeed_120m,windspeed_180m,winddirection_10m,winddirection_80m,winddirection_120m,winddirection_180m,windgusts_10m,temperature_80m,temperature_120m,temperature_180m,soil_temperature_0cm,soil_temperature_6cm,soil_temperature_18cm,soil_temperature_54cm,soil_moisture_0_1cm,soil_moisture_1_3cm,soil_moisture_3_9cm,soil_moisture_9_27cm,soil_moisture_27_81cm";

    protected override string Url => "https://api.open-meteo.com/v1/forecast?latitude={0}&longitude={1}&hourly={2}&timeformat={3}";

    public async Task<Temperature> GetTemperatureByLogLat(long latitude, long longitude, string timeformat = "unixtime")
    {
        return await Request(endpoint: null!, latitude.ToString(), longitude.ToString(), _hourly, timeformat);
    }
}