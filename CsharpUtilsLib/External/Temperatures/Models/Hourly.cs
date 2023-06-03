namespace CsharpUtilsLib.External.Temperatures.Models;

public sealed class Hourly
{
    [Display(Name = "Time"), JsonPropertyName("time")]
    public List<int?> Time { get; set; }

    [Display(Name = "Temperature (2 m)"), JsonPropertyName("temperature_2m")]
    public List<double?> Temperature2m { get; set; }

    [Display(Name = "Relative Humidity (2 m)"), JsonPropertyName("relativehumidity_2m")]
    public List<int?> Relativehumidity2m { get; set; }

    [Display(Name = "Dewpoint (2 m)"), JsonPropertyName("dewpoint_2m")]
    public List<double?> Dewpoint2m { get; set; }

    [Display(Name = "Apparent Temperature"), JsonPropertyName("apparent_temperature")]
    public List<double?> ApparentTemperature { get; set; }

    [Display(Name = "Precipitation Probability"), JsonPropertyName("precipitation_probability")]
    public List<int?> PrecipitationProbability { get; set; }

    [Display(Name = "Precipitation (rain + showers + snow)e"), JsonPropertyName("precipitation")]
    public List<double?> Precipitation { get; set; }

    [Display(Name = "Rain"), JsonPropertyName("rain")]
    public List<double?> Rain { get; set; }

    [Display(Name = "Showers"), JsonPropertyName("showers")]
    public List<double?> Showers { get; set; }

    [Display(Name = "Snowfall"), JsonPropertyName("snowfall")]
    public List<double?> Snowfall { get; set; }

    [Display(Name = "Snow Depth"), JsonPropertyName("snow_depth")]
    public List<double?> SnowDepth { get; set; }

    [Display(Name = "Freezinglevel Height"), JsonPropertyName("freezinglevel_height")]
    public List<double?> FreezinglevelHeight { get; set; }

    [Display(Name = "Weathercode"), JsonPropertyName("weathercode")]
    public List<int?> Weathercode { get; set; }

    [Display(Name = "Sealevel Pressure"), JsonPropertyName("pressure_msl")]
    public List<double?> PressureMsl { get; set; }

    [Display(Name = "Surface Pressure"), JsonPropertyName("surface_pressure")]
    public List<double?> SurfacePressure { get; set; }

    [Display(Name = "Cloudcover Total"), JsonPropertyName("cloudcover")]
    public List<int?> Cloudcover { get; set; }

    [Display(Name = "Cloudcover Low"), JsonPropertyName("cloudcover_low")]
    public List<int?> CloudcoverLow { get; set; }

    [Display(Name = "Cloudcover Mid"), JsonPropertyName("cloudcover_mid")]
    public List<int?> CloudcoverMid { get; set; }

    [Display(Name = "Cloudcover High"), JsonPropertyName("cloudcover_high")]
    public List<int?> CloudcoverHigh { get; set; }

    [Display(Name = "Visibility"), JsonPropertyName("visibility")]
    public List<double?> Visibility { get; set; }

    [Display(Name = "Evapotranspiration"), JsonPropertyName("evapotranspiration")]
    public List<double?> Evapotranspiration { get; set; }

    [Display(Name = "Reference Evapotranspiration (ET 0)"), JsonPropertyName("et0_fao_evapotranspiration")]
    public List<double?> Et0FaoEvapotranspiration { get; set; }

    [Display(Name = "Vapor Pressure Deficit"), JsonPropertyName("vapor_pressure_deficit")]
    public List<double?> VaporPressureDeficit { get; set; }

    [Display(Name = "CAPE"), JsonPropertyName("cape")]
    public List<double?> Cape { get; set; }

    [Display(Name = "Wind Speed (10 m)"), JsonPropertyName("windspeed_10m")]
    public List<double?> Windspeed10m { get; set; }

    [Display(Name = "Wind Speed (80 m)"), JsonPropertyName("windspeed_80m")]
    public List<double?> Windspeed80m { get; set; }

    [Display(Name = "Wind Speed (120 m)"), JsonPropertyName("windspeed_120m")]
    public List<double?> Windspeed120m { get; set; }

    [Display(Name = "Wind Speed (180 m)"), JsonPropertyName("windspeed_180m")]
    public List<double?> Windspeed180m { get; set; }

    [Display(Name = "Wind Direction (10 m)"), JsonPropertyName("winddirection_10m")]
    public List<int?> Winddirection10m { get; set; }

    [Display(Name = "Wind Direction (80 m)"), JsonPropertyName("winddirection_80m")]
    public List<int?> Winddirection80m { get; set; }

    [Display(Name = "Wind Direction (120 m)"), JsonPropertyName("winddirection_120m")]
    public List<int?> Winddirection120m { get; set; }

    [Display(Name = "Wind Direction (180 m)"), JsonPropertyName("winddirection_180m")]
    public List<int?> Winddirection180m { get; set; }

    [Display(Name = "Wind Gusts (10 m)"), JsonPropertyName("windgusts_10m")]
    public List<double?> Windgusts10m { get; set; }

    [Display(Name = "Temperature (80 m)"), JsonPropertyName("temperature_80m")]
    public List<double?> Temperature80m { get; set; }

    [Display(Name = "Temperature (120 m)"), JsonPropertyName("temperature_120m")]
    public List<double?> Temperature120m { get; set; }

    [Display(Name = "Temperature (180 m)"), JsonPropertyName("temperature_180m")]
    public List<double?> Temperature180m { get; set; }

    [Display(Name = "Soil Temperature (0 cm)"), JsonPropertyName("soil_temperature_0cm")]
    public List<double?> SoilTemperature0cm { get; set; }

    [Display(Name = "Soil Temperature (6 cm)"), JsonPropertyName("soil_temperature_6cm")]
    public List<double?> SoilTemperature6cm { get; set; }

    [Display(Name = "Soil Temperature (18 cm)"), JsonPropertyName("soil_temperature_18cm")]
    public List<double?> SoilTemperature18cm { get; set; }

    [Display(Name = "Soil Temperature (54 cm)"), JsonPropertyName("soil_temperature_54cm")]
    public List<double?> SoilTemperature54cm { get; set; }

    [Display(Name = "Soil Moisture (0-1 cm)"), JsonPropertyName("soil_moisture_0_1cm")]
    public List<double?> SoilMoisture01cm { get; set; }

    [Display(Name = "Soil Moisture (1-3 cm)"), JsonPropertyName("soil_moisture_1_3cm")]
    public List<double?> SoilMoisture13cm { get; set; }

    [Display(Name = "Soil Moisture (3-9 cm)"), JsonPropertyName("soil_moisture_3_9cm")]
    public List<double?> SoilMoisture39cm { get; set; }

    [Display(Name = "Soil Moisture (9-27 cm)"), JsonPropertyName("soil_moisture_9_27cm")]
    public List<double?> SoilMoisture927cm { get; set; }

    [Display(Name = "Soil Moisture (27-81 cm)"), JsonPropertyName("soil_moisture_27_81cm")]
    public List<double?> SoilMoisture2781cm { get; set; }
}