namespace CsharpUtilsLib.Tests;

public sealed class AesCryptoTests
{
    [Fact]
    public void Encrypt_And_Decrypt_ReturnsOriginalText()
    {
        // Arrange
        string originalText = "Texto de teste";
        string secret = "senhaSuperSecreta123";

        // Act
        string encrypted = AesCrypto.Encrypt(originalText, secret);
        string decrypted = AesCrypto.Decrypt(encrypted, secret);

        // Assert
        Assert.Equal(originalText, decrypted);
    }

    [Fact]
    public void Encrypt_WithEmptyText_ReturnsNonEmptyEncrypted()
    {
        // Arrange
        string originalText = "";
        string secret = "senhaSuperSecreta123";

        // Act
        string encrypted = AesCrypto.Encrypt(originalText, secret);

        // Assert
        Assert.False(string.IsNullOrWhiteSpace(encrypted));
    }

    [Fact]
    public void Decrypt_WithWrongSecret_ThrowsException()
    {
        // Arrange
        string originalText = "Texto de teste";
        string secret = "senhaSuperSecreta123";
        string wrongSecret = "senhaErrada";
        string encrypted = AesCrypto.Encrypt(originalText, secret);

        // Act & Assert
        Assert.ThrowsAny<System.Security.Cryptography.CryptographicException>(() =>
        {
            AesCrypto.Decrypt(encrypted, wrongSecret);
        });
    }

    [Fact]
    public void Encrypt_And_Decrypt_WithUnicodeText_ReturnsOriginalText()
    {
        // Arrange
        string originalText = "Olá, mundo! 你好，世界！🌎";
        string secret = "senhaUnicode";

        // Act
        string encrypted = AesCrypto.Encrypt(originalText, secret);
        string decrypted = AesCrypto.Decrypt(encrypted, secret);

        // Assert
        Assert.Equal(originalText, decrypted);
    }
}