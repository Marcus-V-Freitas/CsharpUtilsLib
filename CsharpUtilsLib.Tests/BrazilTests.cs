namespace CsharpUtilsLib.Tests;

public sealed class BrazilTests
{
    [Theory]
    [InlineData("1008795-13.2023.8.26.0053")]
    [InlineData("0600098-08.2021.6.26.0376")]
    [InlineData("1000024-91.2017.9.13.0002")]
    [InlineData("0000128-41.2023.8.03.0006")]
    [InlineData("0000432-81.2012.8.14.0018")]
    public void ValidProcessNumber(string processNumber)
    {
        var resultIsTrue = BrazilProcessNumber.IsValidProcessNumber(processNumber, out _);

        Assert.True(resultIsTrue);
    }
}