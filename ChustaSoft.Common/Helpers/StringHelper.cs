using ChustaSoft.Common.Resources;
using System;
using System.Linq;


namespace ChustaSoft.Common.Helpers
{
    public static class StringHelper
    {

        #region Extension Methods

        /// <summary>
        /// Transform a string changing first letter to upper, and the rest to lower
        /// </summary>
        /// <param name="str">String itself to transform</param>
        /// <returns>String transformed</returns>
        public static string ToUpperCamelCase(this string str)
        {
            CheckStringData(str);

            return char.ToUpper(str.First()) + str.Substring(1).ToLower();
        }

        /// <summary>
        /// Transform a string changing just the first letter to upper
        /// </summary>
        /// <param name="str">String itself to transform</param>
        /// <returns>String transformed</returns>
        public static string FirstToUpper(this string str)
        {
            CheckStringData(str);

            return char.ToUpper(str.First()) + str.Substring(1);
        }

        /// <summary>
        /// Transform a string changing just the first letter to lower
        /// </summary>
        /// <param name="str">String itself to transform</param>
        /// <returns>String transformed</returns>
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
