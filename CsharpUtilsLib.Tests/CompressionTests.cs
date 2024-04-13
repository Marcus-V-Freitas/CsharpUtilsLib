namespace CsharpUtilsLib.Tests;

public sealed class CompressionTests
{
    [Theory]
    [InlineData("Hello world", GenericCompressionType.Deflate, CompressionLevel.SmallestSize)]
    [InlineData("Hello world", GenericCompressionType.Brotli, CompressionLevel.SmallestSize)]
    [InlineData("Hello world", GenericCompressionType.Gzip, CompressionLevel.SmallestSize)]
    public void CompressAndDeCompressStringParameters(string expectedValue, GenericCompressionType compressionType, CompressionLevel compressionLevel)
    {
        byte[] bytes = GenericCompression.CompressString(expectedValue, compressionType: compressionType, compressionLevel: compressionLevel);
        string actualValue = GenericCompression.DecompressString(bytes, compressionType: compressionType);

        Assert.Equal(expectedValue, actualValue);
    }

    [Theory]
    [InlineData("Hello world", GenericCompressionType.Deflate, CompressionLevel.SmallestSize)]
    [InlineData("Hello world", GenericCompressionType.Brotli, CompressionLevel.SmallestSize)]
    [InlineData("Hello world", GenericCompressionType.Gzip, CompressionLevel.SmallestSize)]
    public async Task CompressAndDeCompressStringParametersAsync(string expectedValue, GenericCompressionType compressionType, CompressionLevel compressionLevel)
    {
        byte[] bytes = await GenericCompression.CompressStringAsync(expectedValue, compressionType: compressionType, compressionLevel: compressionLevel);
        string actualValue = await GenericCompression.DecompressStringAsync(bytes, compressionType: compressionType);

        Assert.Equal(expectedValue, actualValue);
    }

    [Theory]
    [InlineData("Hello world", "utf-8")]
    [InlineData("Hello world", "ascii")]
    [InlineData("Hello world", null)]
    public void CompressAndDeCompressStringEncoding(string expectedValue, string encodingName)
    {
        Encoding? encoding = encodingName == null ? null : Encoding.GetEncoding(encodingName);

        byte[] bytes = GenericCompression.CompressString(expectedValue, encoding: encoding!);
        string actualValue = GenericCompression.DecompressString(bytes, encoding: encoding!);

        Assert.Equal(expectedValue, actualValue);
    }

    [Theory]
    [InlineData("Hello world", "utf-8")]
    [InlineData("Hello world", "ascii")]
    [InlineData("Hello world", null)]
    public async Task CompressAndDeCompressStringEncodingAsync(string expectedValue, string encodingName)
    {
        Encoding? encoding = encodingName == null ? null : Encoding.GetEncoding(encodingName);

        byte[] bytes = await GenericCompression.CompressStringAsync(expectedValue, encoding: encoding!);
        string actualValue = await GenericCompression.DecompressStringAsync(bytes, encoding: encoding!);

        Assert.Equal(expectedValue, actualValue);
    }
}