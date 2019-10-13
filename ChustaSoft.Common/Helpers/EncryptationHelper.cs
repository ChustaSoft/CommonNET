using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;


namespace ChustaSoft.Common.Helpers
{
    public static class EncryptationHelper
    {

        #region Constants

        private const PaddingMode DEFAULT_PADDING_MODE = PaddingMode.ANSIX923;

        #endregion


        #region Public methods

        public static string CreateHash(string primaryText, string secondaryText)
        {
            if (primaryText == null || secondaryText == null)
                throw new ArgumentNullException();

            var concatenatedText = string.Concat(primaryText, secondaryText);

            return CreateHash(concatenatedText);
        }

        public static string CreateHash(string text)
        {
            var hashTool = new SHA512Managed();
            var PasswordAsByte = Encoding.UTF8.GetBytes(text);
            var EncryptedBytes = hashTool.ComputeHash(PasswordAsByte);

            hashTool.Clear();

            return Convert.ToBase64String(EncryptedBytes);
        }
        
        public static string Encrypt(string plainText, string passPhrase)
        {
            var key = Encoding.UTF8.GetBytes(passPhrase);

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

        public static string Decrypt(string cipherText, string passPhrase)
        {
            var fullCipher = Convert.FromBase64String(cipherText);
            var key = Encoding.UTF8.GetBytes(passPhrase);
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

        #endregion

    }
}
