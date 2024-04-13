namespace CsharpUtilsLib.Compression;

public static class GenericCompression
{
    private static readonly Encoding _defaultEncoding = Encoding.UTF8;
    private static readonly Dictionary<GenericCompressionType, Type> _compressionTypes = new()
    {
        { GenericCompressionType.Gzip, typeof(GZipStream) },
        { GenericCompressionType.Brotli, typeof(BrotliStream) },
        { GenericCompressionType.Deflate, typeof(DeflateStream) },
    };

    private static Stream CreateCompressStream(GenericCompressionType compressionType, MemoryStream memoryStream, CompressionLevel compressionLevel)
    {
        return (Stream)_compressionTypes[compressionType].CreateInstance(memoryStream, compressionLevel);
    }

    private static Stream CreateDecompressStream(GenericCompressionType compressionType, MemoryStream memoryStream)
    {
        return (Stream)_compressionTypes[compressionType].CreateInstance(memoryStream, CompressionMode.Decompress);
    }

    public static byte[] Compress(byte[] bytes, GenericCompressionType compressionType = GenericCompressionType.Gzip, CompressionLevel compressionLevel = CompressionLevel.Optimal)
    {
        if (bytes == null)
        {
            return null!;
        }

        using (var memoryStream = new MemoryStream())
        {
            using (var uncompressedStream = CreateCompressStream(compressionType, memoryStream, compressionLevel))
            {
                uncompressedStream.Write(bytes, 0, bytes.Length);
            }

            return memoryStream.ToArray();
        }
    }

    public static byte[] CompressString(string text, GenericCompressionType compressionType = GenericCompressionType.Gzip, CompressionLevel compressionLevel = CompressionLevel.Optimal, Encoding encoding = null!)
    {
        if (text == null)
        {
            return null!;
        }

        byte[] bytes = (encoding ?? _defaultEncoding).GetBytes(text);

        return Compress(bytes, compressionType, compressionLevel);
    }

    public static byte[] Decompress(byte[] bytes, GenericCompressionType compressionType = GenericCompressionType.Gzip)
    {
        if (bytes == null)
        {
            return null!;
        }

        using (var memoryStream = new MemoryStream(bytes))
        {
            using (var outputStream = new MemoryStream())
            {
                using (var decompressedStream = CreateDecompressStream(compressionType, memoryStream))
                {
                    decompressedStream.CopyTo(outputStream);
                }

                return outputStream.ToArray();
            }
        }
    }

    public static string DecompressString(byte[] bytes, GenericCompressionType compressionType = GenericCompressionType.Gzip, Encoding encoding = null!)
    {
        if (bytes == null)
        {
            return null!;
        }

        byte[] decompressedBytes = Decompress(bytes, compressionType);

        return (encoding ?? _defaultEncoding).GetString(decompressedBytes);
    }

    public static async Task<byte[]> CompressAsync(byte[] bytes, GenericCompressionType compressionType = GenericCompressionType.Gzip, CompressionLevel compressionLevel = CompressionLevel.Optimal)
    {
        if (bytes == null)
        {
            return null!;
        }

        await using (var memoryStream = new MemoryStream())
        {
            await using (var uncompressedStream = CreateCompressStream(compressionType, memoryStream, compressionLevel))
            {
                await uncompressedStream.WriteAsync(bytes, 0, bytes.Length);
            }

            return memoryStream.ToArray();
        }
    }

    public static async Task<byte[]> CompressStringAsync(string text, GenericCompressionType compressionType = GenericCompressionType.Gzip, CompressionLevel compressionLevel = CompressionLevel.Optimal, Encoding encoding = null!)
    {
        if (text == null)
        {
            return null!;
        }

        byte[] bytes = (encoding ?? _defaultEncoding).GetBytes(text);

        return await CompressAsync(bytes, compressionType, compressionLevel);
    }

    public static async Task<byte[]> DecompressAsync(byte[] bytes, GenericCompressionType compressionType = GenericCompressionType.Gzip)
    {
        if (bytes == null)
        {
            return null!;
        }

        await using (var memoryStream = new MemoryStream(bytes))
        {
            await using (var outputStream = new MemoryStream())
            {
                await using (var decompressedStream = CreateDecompressStream(compressionType, memoryStream))
                {
                    await decompressedStream.CopyToAsync(outputStream);
                }

                return outputStream.ToArray();
            }
        }
    }

    public static async Task<string> DecompressStringAsync(byte[] bytes, GenericCompressionType compressionType = GenericCompressionType.Gzip, Encoding encoding = null!)
    {
        if (bytes == null)
        {
            return null!;
        }

        byte[] decompressedBytes = await DecompressAsync(bytes, compressionType);

        return (encoding ?? _defaultEncoding).GetString(decompressedBytes);
    }
}

public enum GenericCompressionType
{
    Gzip = 0,
    Brotli = 1,
    Deflate = 2
}