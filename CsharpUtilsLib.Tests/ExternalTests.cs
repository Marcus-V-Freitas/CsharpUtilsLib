namespace CsharpUtilsLib.Tests;

public sealed class ExternalTests
{
    [Theory]
    [InlineData("brazil", "Federative Republic of Brazil")]
    [InlineData("United States", "United States of America")]
    public async Task CountriesAPI(string inputName, string expectedOfficialName)
    {
        CountryData countryData = new CountryData();

        var result = await countryData.GetCountryByOption(CountryOptions.FullName, inputName);

        Assert.Equal(expectedOfficialName, result.Name.Official);
    }

    [Theory]
    [InlineData("Hello World", "Olá Mundo")]
    [InlineData("Good morning everybody", "Bom dia a todos")]
    public async Task GoogleTranslateAPI(string inputPhrase, string expectedOutput)
    {
        GoogleTranslate googleTranslate = new GoogleTranslate();

        var result = await googleTranslate.Translate(inputPhrase, "en", "pt-br");

        Assert.Equal(expectedOutput, result, ignoreCase: true);
    }

    [Theory]
    [InlineData("04583-115", "Vila Cordeiro")]
    [InlineData("01048-100", "República")]
    public async Task CEPAPI(string inputZipCode, string expectedDistrict)
    {
        CEPData cepData = new CEPData();

        var result = await cepData.GetLocation(inputZipCode);

        Assert.Equal(expectedDistrict, result.Bairro);
    }

    [Theory]
    [InlineData("191.9.12.15", "São Paulo")]
    [InlineData("8.8.8.8", "Mountain View")]
    public async Task IPAPI(string ipAdress, string expectedCity)
    {
        IPData ipData = new IPData();

        var result = await ipData.GetInfosFromIP(ipAdress);

        Assert.Equal(expectedCity, result.City, ignoreCase: true);
    }

    [Theory]
    [InlineData("33.014.556/0001-96", "LOJAS AMERICANAS S.A.")]
    [InlineData("00.000.000/0001-91", "BANCO DO BRASIL SA")]
    public async Task CompaniesAPI(string cnpj, string expectedName)
    {
        CompaniesData companiesData = new CompaniesData();

        var result = await companiesData.GetCompanyByCNPJ(cnpj);

        Assert.Equal(expectedName, result.RazaoSocial);
    }

    [Theory]
    [InlineData("SELIC")]
    [InlineData("CDI")]
    public async Task TaxAPI(string tax)
    {
        TaxData taxData = new TaxData();

        var result = await taxData.GetTaxByName(tax);

        Assert.NotNull(result);
    }

    [Theory]
    [InlineData("3305.10.00", "Xampus")]
    [InlineData("0105.15.00", "Galinhas-d'angola (pintadas)")]
    public async Task NCMApi(string code, string expectedName)
    {
        NCMData ncmData = new NCMData();

        var result = await ncmData.GetNCMByCode(code);

        Assert.Equal(result.Descricao, expectedName, ignoreCase: true);
    }

    [Theory]
    [InlineData("001004-9", "Palio EX 1.0 mpi 2p")]
    [InlineData("093004-0", "Tiggo 7 Pro 1.6 Turbo 16V Aut.")]
    public async Task FIPEAPI(string code, string expectedName)
    {
        FIPEData fipeData = new FIPEData();

        var result = await fipeData.GetFiPEByCode(code);

        Assert.Equal(result.FirstOrDefault()!.Modelo, expectedName, ignoreCase: true);
    }

    [Theory]
    [InlineData("2022", "Natal", "2022-12-25")]
    [InlineData("2023", "Carnaval", "2023-02-21")]
    public async Task NationalBrazilHolidaysAPI(string year, string holidayName, string expectedDate)
    {
        NationalBrazilHolidaysData holidaysData = new NationalBrazilHolidaysData();

        var result = await holidaysData.GetHolidaysByYear(year);
        var holidayDate = result.FirstOrDefault(x => x.Name == holidayName)!.Date;

        Assert.Equal(holidayDate, expectedDate);
    }

    [Theory]
    [InlineData("Salmon Avocado Salad", "Seafood")]
    [InlineData("Japanese gohan rice", "Side")]
    public async Task MealAPI(string meal, string expectCategory)
    {
        MealData mealData = new MealData();

        var result = await mealData.GetMealByName(meal);

        Assert.Equal(result.Meals?.FirstOrDefault()?.Category, expectCategory);
    }

    [Theory]
    [InlineData(-23.5, -46.5, "GMT")]
    [InlineData(40.42, -3.70, "GMT")]
    public async Task TemperatureAPI(long latitude, long logintude, string expectTimeZoneAbbreviation)
    {
        TemperatureData temperatureData = new TemperatureData();

        var result = await temperatureData.GetTemperatureByLogLat(latitude, logintude);

        Assert.Equal(result.TimezoneAbbreviation, expectTimeZoneAbbreviation);
    }

    [Theory]
    [InlineData("São Paulo", -23.5475, -46.63611)]
    public async Task GeolocationAPI(string cityName, double expectedLatitude, double expectedLongitude)
    {
        GeolocationData geolocationData = new GeolocationData();

        var result = await geolocationData.GetInfosFromCityName(cityName);

        Assert.Equal(result.Results.FirstOrDefault()!.Latitude, expectedLatitude);
        Assert.Equal(result.Results.FirstOrDefault()!.Longitude, expectedLongitude);
    }

    [Theory]
    [InlineData("avocado", "https://en.wiktionary.org/wiki/avocado")]
    [InlineData("money", "https://en.wiktionary.org/wiki/money")]
    public async Task EnglishDictionaryAPI(string word, string expectedSourceUrl)
    {
        EnglishDictionaryData englishDictionaryData = new EnglishDictionaryData();

        var result = await englishDictionaryData.GetDefinitionsFromWord(word);

        string sourceUrl = result.FirstOrDefault()!.SourceUrls.FirstOrDefault()!;

        Assert.Equal(sourceUrl, expectedSourceUrl);
    }

    [Theory]
    [InlineData("WALM34", "Walmart Inc.")]
    [InlineData("BOAC34", "Bank of America Corporation")]
    public async Task TickerAPI(string word, string expectlongCompanyName)
    {
        TickerData tickerData = new TickerData();

        var result = await tickerData.GetTickerByName(word);

        string longCompanyName = result?.Results?.FirstOrDefault()!.LongName!;

        Assert.Equal(longCompanyName, expectlongCompanyName);
    }

    [Theory]
    [InlineData("USD", "BRL", "Dólar Americano/Real Brasileiro")]
    [InlineData("USD", "EUR", "Dólar Americano/Euro")]
    public async Task CurrencyAPI(string baseCurrency, string anotherCurrency, string expectName)
    {
        CurrencyData currencyData = new CurrencyData();

        var result = await currencyData.ConvertCurrencies(baseCurrency, anotherCurrency);

        string name = result?.Currency?.FirstOrDefault()!.Name!;

        Assert.Equal(name, expectName);
    }

    [Theory]
    [InlineData("QB942322947BR", "Objeto entregue ao destinatário")]
    [InlineData("IX021419098BR", "Objeto entregue ao destinatário")]
    public async Task CorreiosTrackingAPI(string trackingCode, string expectedFinalStatus)
    {
        CorreiosTrackingData correiosTrackingData = new CorreiosTrackingData();

        var result = await correiosTrackingData.GetByTrackingCode(trackingCode, asc: false);

        string finalStatus = result?.FirstOrDefault()!.Status!;

        Assert.Equal(finalStatus, expectedFinalStatus);
    }

    [Theory]
    [InlineData("03/03/2023", "04/03/2023", "PNAD Contínua: taxa de desocupação é de 8,6% e taxa de subutilização é de 18,8% no trimestre encerrado em fevereiro")]
    [InlineData("01/01/2022", "02/01/2022", "Começa contagem regressiva para o início da coleta do Censo 2022")]
    public async Task IBGENewsAPI(string startDate, string endDate, string expectMainNewsTitle)
    {
        IBGENewsData ibgeNewsData = new IBGENewsData();

        DateTime start = startDate.ConvertToDatetime();
        DateTime end = endDate.ConvertToDatetime();

        var result = await ibgeNewsData.GetNewsByPeriod(start, end, sortByHighlights: true);

        string mainNewsTitle = result?.Items?.FirstOrDefault()!.Titulo!;

        Assert.Equal(mainNewsTitle, expectMainNewsTitle);
    }

    [Theory]
    [InlineData("Brazil", "29/10/2022", "29/01/2023", "6.47")]
    [InlineData("Argentina", "01/01/2021", "31/12/2022", "9.68")]
    public async Task InflationAPI(string country, string startDate, string endDate, string expectedhighestValue)
    {
        InflationData inflationData = new InflationData();

        DateTime start = startDate.ConvertToDatetime();
        DateTime end = endDate.ConvertToDatetime();

        var result = await inflationData.GetByCountryInPeriod(country, start, end);

        var highestValue = result.Inflation?.Max(x => x.Value)!;

        Assert.Equal(highestValue, expectedhighestValue);
    }

    [Fact]
    public async Task CorreiosShippingAPI()
    {
        var request = new CorreiosShippingRequest("95020450", "71939360", 23.78, ShippingFormat.BoxOrPackage,
                                                  40, 71.50, 58, false, 0, false, ShippingService.RetailSEDEX,
                                                  0, ShippingIndicator.PriceAndTerm);

        CorreiosShippingData correiosShipping = new CorreiosShippingData();

        var result = await correiosShipping.GetByShippingDetails(request);

        Assert.Equal("991,30", result.Servico.Valor);
    }
}