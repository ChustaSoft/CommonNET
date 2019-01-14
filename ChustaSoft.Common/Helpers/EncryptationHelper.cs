using System;

namespace ChustaSoft.Common.Helpers
{
    public static class EncryptationHelper
    {

        public static string CreateHash(string primaryText, string secondaryText)
        {
            if (primaryText == null || secondaryText == null)
                throw new ArgumentNullException();

            var concatenatedText = string.Concat(primaryText, secondaryText);

            return CreateHash(concatenatedText);
        }

        public static string CreateHash(string text)
        {
            System.Security.Cryptography.SHA512Managed HashTool = new System.Security.Cryptography.SHA512Managed();
            Byte[] PasswordAsByte = System.Text.Encoding.UTF8.GetBytes(text);
            Byte[] EncryptedBytes = HashTool.ComputeHash(PasswordAsByte);
            HashTool.Clear();

            return Convert.ToBase64String(EncryptedBytes);
        }

    }
}
