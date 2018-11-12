using ChustaSoft.Common.Resources;
using System;
using System.Linq;


namespace ChustaSoft.Common.Helpers
{
    public static class StringHelper
    {

        #region Extension Methods

        public static string ToUpperCamelCase(this string str)
        {
            CheckStringData(str);

            return char.ToUpper(str.First()) + str.Substring(1).ToLower();
        }

        public static string FirstToUpper(this string str)
        {
            CheckStringData(str);

            return char.ToUpper(str.First()) + str.Substring(1);
        }

        public static string FirstToLower(this string str)
        {
            CheckStringData(str);

            return char.ToLower(str.First()) + str.Substring(1);
        }

        #endregion

        
        #region Private methods

        private static void CheckStringData(string str)
        {
            if (string.IsNullOrEmpty(str))
                throw new ArgumentException(ExceptionResources.ArgumentException_StringHelper_WrongString, nameof(str));
        }

        #endregion

    }
}
