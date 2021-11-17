using ChustaSoft.Common.Exceptions;
using System;
using System.IO;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Text;

namespace ChustaSoft.Common.Helpers
{
    public static class EncryptationHelper
    {

        private const PaddingMode DEFAULT_PADDING_MODE = PaddingMode.ANSIX923;
        private const HashAlgorithmType DEFAULT_ALGORITHM_HASH = HashAlgorithmType.Sha512;


        /// <summary>
        /// One way hash encryption for two different strings
        /// </summary>
        /// <param name="primaryText">First text to encrypt</param>
        /// <param name="secondaryText">Second text to encrypt</param>
        /// <param name="hashAlgorithmType">Algorith choosen. Sha512 by default. Supports also MD5</param>
        /// <returns>Encryted result of concatenated strings</returns>
        public static string CreateHash(string primaryText, string secondaryText, HashAlgorithmType hashAlgorithmType = DEFAULT_ALGORITHM_HASH)
        {
            if (primaryText == null || secondaryText == null)
                throw new ArgumentNullException();

            var concatenatedText = string.Concat(primaryText, secondaryText);

            return CreateHash(concatenatedText, hashAlgorithmType);
        }

        /// <summary>
        /// One way hash encryption for a single string
        /// </summary>
        /// <param name="primaryText">Text to encrypt</param>
        /// <param name="hashAlgorithmType">Algorith choosen. Sha512 by default. Supports also MD5</param>
        /// <returns>Encryted result for specified string</returns>
        public static string CreateHash(string text, HashAlgorithmType hashAlgorithmType = DEFAULT_ALGORITHM_HASH)
        {
            switch (hashAlgorithmType)
            {
                case HashAlgorithmType.Md5:
                    return CreateMD5Hash(text);

                case HashAlgorithmType.Sha512:
                    return CreateSha512Hash(text);

                default:
                    throw new UnsupportedAlgorithmException(hashAlgorithmType);
            }

        }

        /// <summary>
        /// Encryption method with AES algorythm, needs only a text and private key to encrypt
        /// </summary>
        /// <param name="plainText">Text to encrypt</param>
        /// <param name="passPhrase">Private key</param>
        /// <returns>Encrypted string</returns>
        public static string Encrypt(string plainText, string passPhrase)
        {
            byte[] key = Get32ByteArrayKey(passPhrase);

            using (var aesAlg = Aes.Create())
            {
                aesAlg.Padding = DEFAULT_PADDING_MODE;

                using (var encryptor = aesAlg.CreateEncryptor(key, aesAlg.IV))
                {
                    using (var msEncrypt = new MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                            swEncrypt.Write(plainText);

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
        /// Decryption method for a specified string
        /// </summary>
        /// <param name="cipherText">Encrypted string</param>
        /// <param name="passPhrase">Private key</param>
        /// <returns>Decrypted string result</returns>
        public static string Decrypt(string cipherText, string passPhrase)
        {
            var fullCipher = Convert.FromBase64String(cipherText);
            var key = Get32ByteArrayKey(passPhrase);
            var iv = new byte[16];
            var cipher = new byte[fullCipher.Length - iv.Length];

            Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, fullCipher.Length - iv.Length);

            using (var aesAlg = Aes.Create())
            {
                aesAlg.Padding = DEFAULT_PADDING_MODE;

                using (var decryptor = aesAlg.CreateDecryptor(key, iv))
                using (var msDecrypt = new MemoryStream(cipher))
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (var srDecrypt = new StreamReader(csDecrypt))
                    return srDecrypt.ReadToEnd();
            }
        }


        private static byte[] Get32ByteArrayKey(string passPhrase)
        {
            return Encoding.UTF8.GetBytes(CreateMD5Hash(passPhrase));
        }

        private static string CreateSha512Hash(string text)
        {
            var hashTool = SHA512.Create();
            var passwordAsByte = Encoding.UTF8.GetBytes(text);
            var encryptedBytes = hashTool.ComputeHash(passwordAsByte);

            hashTool.Clear();

            return Convert.ToBase64String(encryptedBytes);
        }

        private static string CreateMD5Hash(string text)
        {
            using (var md5 = MD5.Create())
            {
                byte[] hash = md5.ComputeHash(Encoding.Default.GetBytes(text));
                var md5GuidHash = new Guid(hash).ToString("N");

                return md5GuidHash;
            }
        }

    }
}
