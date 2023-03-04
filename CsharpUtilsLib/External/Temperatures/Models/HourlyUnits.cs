namespace CsharpUtilsLib.External.Temperatures.Models;

public sealed class HourlyUnits
{
    [Display(Name = "Time"), JsonPropertyName("time")]
    public string Time { get; set; }

    [Display(Name = "Temperature (2 m)"), JsonPropertyName("temperature_2m")]
    public string Temperature2m { get; set; }

    [Display(Name = "Relative Humidity (2 m)"), JsonPropertyName("relativehumidity_2m")]
    public string Relativehumidity2m { get; set; }

    [Display(Name = "Dewpoint (2 m)"), JsonPropertyName("dewpoint_2m")]
    public string Dewpoint2m { get; set; }

    [Display(Name = "Apparent Temperature"), JsonPropertyName("apparent_temperature")]
    public string ApparentTemperature { get; set; }

    [Display(Name = "Precipitation Probability"), JsonPropertyName("precipitation_probability")]
    public string PrecipitationProbability { get; set; }

    [Display(Name = "Precipitation (rain + showers + snow)e"), JsonPropertyName("precipitation")]
    public string Precipitation { get; set; }

    [Display(Name = "Rain"), JsonPropertyName("rain")]
    public string Rain { get; set; }

    [Display(Name = "Showers"), JsonPropertyName("showers")]
    public string Showers { get; set; }

    [Display(Name = "Snowfall"), JsonPropertyName("snowfall")]
    public string Snowfall { get; set; }

    [Display(Name = "Snow Depth"), JsonPropertyName("snow_depth")]
    public string SnowDepth { get; set; }

    [Display(Name = "Freezinglevel Height"), JsonPropertyName("freezinglevel_height")]
    public string FreezinglevelHeight { get; set; }

    [Display(Name = "Weathercode"), JsonPropertyName("weathercode")]
    public string Weathercode { get; set; }

    [Display(Name = "Sealevel Pressure"), JsonPropertyName("pressure_msl")]
    public string PressureMsl { get; set; }

    [Display(Name = "Surface Pressure"), JsonPropertyName("surface_pressure")]
    public string SurfacePressure { get; set; }

    [Display(Name = "Cloudcover Total"), JsonPropertyName("cloudcover")]
    public string Cloudcover { get; set; }

    [Display(Name = "Cloudcover Low"), JsonPropertyName("cloudcover_low")]
    public string CloudcoverLow { get; set; }

    [Display(Name = "Cloudcover Mid"), JsonPropertyName("cloudcover_mid")]
    public string CloudcoverMid { get; set; }

    [Display(Name = "Cloudcover High"), JsonPropertyName("cloudcover_high")]
    public string CloudcoverHigh { get; set; }

    [Display(Name = "Visibility"), JsonPropertyName("visibility")]
    public string Visibility { get; set; }

    [Display(Name = "Evapotranspiration"), JsonPropertyName("evapotranspiration")]
    public string Evapotranspiration { get; set; }

    [Display(Name = "Reference Evapotranspiration (ET 0)"), JsonPropertyName("et0_fao_evapotranspiration")]
    public string Et0FaoEvapotranspiration { get; set; }

    [Display(Name = "Vapor Pressure Deficit"), JsonPropertyName("vapor_pressure_deficit")]
    public string VaporPressureDeficit { get; set; }

    [Display(Name = "CAPE"), JsonPropertyName("cape")]
    public string Cape { get; set; }

    [Display(Name = "Wind Speed (10 m)"), JsonPropertyName("windspeed_10m")]
    public string Windspeed10m { get; set; }

    [Display(Name = "Wind Speed (80 m)"), JsonPropertyName("windspeed_80m")]
    public string Windspeed80m { get; set; }

    [Display(Name = "Wind Speed (120 m)"), JsonPropertyName("windspeed_120m")]
    public string Windspeed120m { get; set; }

    [Display(Name = "Wind Speed (180 m)"), JsonPropertyName("windspeed_180m")]
    public string Windspeed180m { get; set; }

    [Display(Name = "Wind Direction (10 m)"), JsonPropertyName("winddirection_10m")]
    public string Winddirection10m { get; set; }

    [Display(Name = "Wind Direction (80 m)"), JsonPropertyName("winddirection_80m")]
    public string Winddirection80m { get; set; }

    [Display(Name = "Wind Direction (120 m)"), JsonPropertyName("winddirection_120m")]
    public string Winddirection120m { get; set; }

    [Display(Name = "Wind Direction (180 m)"), JsonPropertyName("winddirection_180m")]
    public string Winddirection180m { get; set; }

    [Display(Name = "Wind Gusts (10 m)"), JsonPropertyName("windgusts_10m")]
    public string Windgusts10m { get; set; }

    [Display(Name = "Temperature (80 m)"), JsonPropertyName("temperature_80m")]
    public string Temperature80m { get; set; }

    [Display(Name = "Temperature (120 m)"), JsonPropertyName("temperature_120m")]
    public string Temperature120m { get; set; }

    [Display(Name = "Temperature (180 m)"), JsonPropertyName("temperature_180m")]
    public string Temperature180m { get; set; }

    [Display(Name = "Soil Temperature (0 cm)"), JsonPropertyName("soil_temperature_0cm")]
    public string SoilTemperature0cm { get; set; }

    [Display(Name = "Soil Temperature (6 cm)"), JsonPropertyName("soil_temperature_6cm")]
    public string SoilTemperature6cm { get; set; }

    [Display(Name = "Soil Temperature (18 cm)"), JsonPropertyName("soil_temperature_18cm")]
    public string SoilTemperature18cm { get; set; }

    [Display(Name = "Soil Temperature (54 cm)"), JsonPropertyName("soil_temperature_54cm")]
    public string SoilTemperature54cm { get; set; }

    [Display(Name = "Soil Moisture (0-1 cm)"), JsonPropertyName("soil_moisture_0_1cm")]
    public string SoilMoisture01cm { get; set; }

    [Display(Name = "Soil Moisture (1-3 cm)"), JsonPropertyName("soil_moisture_1_3cm")]
    public string SoilMoisture13cm { get; set; }

    [Display(Name = "Soil Moisture (3-9 cm)"), JsonPropertyName("soil_moisture_3_9cm")]
    public string SoilMoisture39cm { get; set; }

    [Display(Name = "Soil Moisture (9-27 cm)"), JsonPropertyName("soil_moisture_9_27cm")]
    public string SoilMoisture927cm { get; set; }

    [Display(Name = "Soil Moisture (27-81 cm)"), JsonPropertyName("soil_moisture_27_81cm")]
    public string SoilMoisture2781cm { get; set; }
}