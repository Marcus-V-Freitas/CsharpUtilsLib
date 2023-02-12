namespace CsharpUtilsLib.Crypto;

public static class AesCrypto
{
    public static string Encrypt(string text, string secret)
    {
        // generate salt
        var rng = new RNGCryptoServiceProvider();
        byte[] key;
        byte[] iv;
        byte[] salt = new byte[8];

        rng.GetNonZeroBytes(salt);
        DeriveKeyAndIV(secret, salt, out key, out iv);
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
        byte[] key;
        byte[] iv;
        DeriveKeyAndIV(secret, salt, out key, out iv);
        return DecryptStringFromBytesAes(encryptedBytes, key, iv);
    }

    private static void DeriveKeyAndIV(string secret, byte[] salt, out byte[] key, out byte[] iv)
    {
        // generate key and iv
        List<byte> concatenatedHashes = new List<byte>(48);

        byte[] password = Encoding.UTF8.GetBytes(secret);
        byte[] currentHash = new byte[0];
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
        // Declare the stream used to encrypt to an in memory
        // array of bytes.
        MemoryStream msEncrypt;

        // Declare the RijndaelManaged object
        // used to encrypt the data.
        RijndaelManaged aesAlg = null!;

        try
        {
            // Create a RijndaelManaged object
            // with the specified key and IV.
            aesAlg = new RijndaelManaged { Mode = CipherMode.CBC, KeySize = 256, BlockSize = 128, Key = key, IV = iv };

            // Create an encryptor to perform the stream transform.
            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            // Create the streams used for encryption.
            msEncrypt = new MemoryStream();
            using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
            {
                using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                {
                    //Write all data to the stream.
                    swEncrypt.Write(text);
                    swEncrypt.Flush();
                    swEncrypt.Close();
                }
            }
        }
        finally
        {
            // Clear the RijndaelManaged object.
            if (aesAlg != null)
                aesAlg.Clear();
        }

        // Return the encrypted bytes from the memory stream.
        return msEncrypt.ToArray();
    }

    private static string DecryptStringFromBytesAes(byte[] encryptedText, byte[] key, byte[] iv)
    {
        // Declare the RijndaelManaged object
        // used to decrypt the data.
        RijndaelManaged aesAlg = null;

        // Declare the string used to hold
        // the decrypted text.
        string text;

        try
        {
            // Create a RijndaelManaged object
            // with the specified key and IV.
            aesAlg = new RijndaelManaged { Mode = CipherMode.CBC, KeySize = 256, BlockSize = 128, Key = key, IV = iv };

            // Create a decrytor to perform the stream transform.
            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
            // Create the streams used for decryption.
            using (MemoryStream msDecrypt = new MemoryStream(encryptedText))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        // Read the decrypted bytes from the decrypting stream
                        // and place them in a string.
                        text = srDecrypt.ReadToEnd();
                        srDecrypt.Close();
                    }
                }
            }
        }
        finally
        {
            // Clear the RijndaelManaged object.
            if (aesAlg != null)
                aesAlg.Clear();
        }
        return text;
    }
}