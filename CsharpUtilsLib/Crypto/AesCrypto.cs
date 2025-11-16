namespace CsharpUtilsLib.Crypto;

public static class AesCrypto
{
    public static string Encrypt(string text, string secret)
    {
        // generate salt
        byte[] salt = new byte[8];

        RandomNumberGenerator.Fill(salt);
        DeriveKeyAndIV(secret, salt, out byte[] key, out byte[] iv);
        // encrypt bytes
        byte[] encryptedBytes = EncryptStringToBytesAes(text, key, iv);
        // add salt as first 8 bytes
        byte[] encryptedBytesWithSalt = new byte[salt.Length + encryptedBytes.Length + 8];
        Buffer.BlockCopy(Encoding.ASCII.GetBytes("Salted__"), 0, encryptedBytesWithSalt, 0, 8);
        Buffer.BlockCopy(salt, 0, encryptedBytesWithSalt, 8, salt.Length);
        Buffer.BlockCopy(encryptedBytes, 0, encryptedBytesWithSalt, salt.Length + 8, encryptedBytes.Length);
        // base64 encode
        return Convert.ToBase64String(encryptedBytesWithSalt);
    }

    public static string Decrypt(string encryptedText, string secret)
    {
        // base 64 decode
        byte[] encryptedBytesWithSalt = Convert.FromBase64String(encryptedText);

        // extract salt (first 8 bytes of encrypted)
        byte[] salt = new byte[8];
        byte[] encryptedBytes = new byte[encryptedBytesWithSalt.Length - salt.Length - 8];
        Buffer.BlockCopy(encryptedBytesWithSalt, 8, salt, 0, salt.Length);
        Buffer.BlockCopy(encryptedBytesWithSalt, salt.Length + 8, encryptedBytes, 0, encryptedBytes.Length);

        // get key and iv
        DeriveKeyAndIV(secret, salt, out byte[] key, out byte[] iv);
        return DecryptStringFromBytesAes(encryptedBytes, key, iv);
    }

    private static void DeriveKeyAndIV(string secret, byte[] salt, out byte[] key, out byte[] iv)
    {
        // generate key and iv
        List<byte> concatenatedHashes = new(48);

        byte[] password = Encoding.UTF8.GetBytes(secret);
        byte[] currentHash = [];
        MD5 md5 = MD5.Create();
        bool enoughBytesForKey = false;

        while (!enoughBytesForKey)
        {
            int preHashLength = currentHash.Length + password.Length + salt.Length;
            byte[] preHash = new byte[preHashLength];

            Buffer.BlockCopy(currentHash, 0, preHash, 0, currentHash.Length);
            Buffer.BlockCopy(password, 0, preHash, currentHash.Length, password.Length);
            Buffer.BlockCopy(salt, 0, preHash, currentHash.Length + password.Length, salt.Length);

            currentHash = md5.ComputeHash(preHash);
            concatenatedHashes.AddRange(currentHash);

            if (concatenatedHashes.Count >= 48)
                enoughBytesForKey = true;
        }

        key = new byte[32];
        iv = new byte[16];
        concatenatedHashes.CopyTo(0, key, 0, 32);
        concatenatedHashes.CopyTo(32, iv, 0, 16);

        md5.Clear();
    }

    private static byte[] EncryptStringToBytesAes(string text, byte[] key, byte[] iv)
    {
        MemoryStream msEncrypt;
        Aes aesAlg = null!;

        try
        {
            aesAlg = Aes.Create();
            aesAlg.Mode = CipherMode.CBC;
            aesAlg.KeySize = 256;
            aesAlg.BlockSize = 128;
            aesAlg.Key = key;
            aesAlg.IV = iv;

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            msEncrypt = new MemoryStream();
            using CryptoStream csEncrypt = new(msEncrypt, encryptor, CryptoStreamMode.Write);
            using StreamWriter swEncrypt = new(csEncrypt);
            swEncrypt.Write(text);
            swEncrypt.Flush();
            swEncrypt.Close();
        }
        finally
        {
            aesAlg?.Dispose();
        }

        return msEncrypt.ToArray();
    }

    private static string DecryptStringFromBytesAes(byte[] encryptedText, byte[] key, byte[] iv)
    {
        Aes aesAlg = null!;
        string text;

        try
        {
            aesAlg = Aes.Create();
            aesAlg.Mode = CipherMode.CBC;
            aesAlg.KeySize = 256;
            aesAlg.BlockSize = 128;
            aesAlg.Key = key;
            aesAlg.IV = iv;

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
            using MemoryStream msDecrypt = new(encryptedText);
            using CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read);
            using StreamReader srDecrypt = new(csDecrypt);
            text = srDecrypt.ReadToEnd();
            srDecrypt.Close();
        }
        finally
        {
            aesAlg?.Dispose();
        }
        return text;
    }
}