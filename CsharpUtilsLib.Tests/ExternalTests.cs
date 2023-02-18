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
}