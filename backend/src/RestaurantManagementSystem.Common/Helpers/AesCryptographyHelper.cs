using System;
using System.IO;
using System.Security.Cryptography;

namespace RestaurantManagementSystem.Common.Helpers
{
    /// <summary>
    /// Helper class for the AES Cryptography
    /// </summary>
    public static class AesCryptographyHelper
    {
        /// <summary>
        /// Encrypt
        /// </summary>
        /// <param name="text">String to be encrypted</param>
        /// <param name="keyString">Aes Key</param>
        /// <returns>Encrypted string</returns>
        public static string EncryptString(string text, string keyString)
        {
            var key = Convert.FromBase64String(keyString);

            using (var aesAlg = Aes.Create())
            {
                using (var encryptor = aesAlg.CreateEncryptor(key, aesAlg.IV))
                {
                    using (var msEncrypt = new MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(text);
                        }

                        var iv = aesAlg.IV;

                        var decryptedContent = msEncrypt.ToArray();

                        var result = new byte[iv.Length + decryptedContent.Length];

                        Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
                        Buffer.BlockCopy(decryptedContent, 0, result, iv.Length, decryptedContent.Length);

                        return Convert.ToBase64String(result);
                    }
                }
            }
        }

        /// <summary>
        /// Decrypt
        /// </summary>
        /// <param name="cipherText">Encrypted string</param>
        /// <param name="keyString">Aes Key</param>
        /// <returns>Decrypted string</returns>
        public static string DecryptString(string cipherText, string keyString)
        {
            var fullCipher = Convert.FromBase64String(cipherText);

            var iv = new byte[16];
            var cipher = new byte[16];

            Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, iv.Length);
            var key = Convert.FromBase64String(keyString);

            using (var aesAlg = Aes.Create())
            {
                using (var decryptor = aesAlg.CreateDecryptor(key, iv))
                {
                    string result;
                    using (var msDecrypt = new MemoryStream(cipher))
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using var srDecrypt = new StreamReader(csDecrypt);
                        result = srDecrypt.ReadToEnd();
                    }

                    return result;
                }
            }
        }
    }
}
