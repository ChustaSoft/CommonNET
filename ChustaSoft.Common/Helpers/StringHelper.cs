using ChustaSoft.Common.Enums;
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

        /// <summary>
        /// Converts a string to an existing enum, naming must match.
        /// Currently is supporting first camel case Enum types, complex UpperCamelCase enum types not supported.
        /// </summary>
        /// <typeparam name="TEnum">Enum type to be casted</typeparam>
        /// <param name="str">string itself from where to receive Enum</param>
        /// <param name="stringCase">StringCase type, by default Invariant</param>
        /// <returns>Expected Enum type, or Exception if unsupported</returns>
        public static TEnum ToEnum<TEnum>(this string str, StringCase stringCase = StringCase.Invariant)
            where TEnum : struct, IConvertible
        {
            switch (stringCase)
            {
                case StringCase.Invariant:
                    return EnumsHelper.GetByString<TEnum>(str);

                case StringCase.Upper:
                case StringCase.Lower:
                    return EnumsHelper.GetByString<TEnum>(str.ToUpperCamelCase());

                default:
                    throw new ArgumentException(ExceptionResources.ArgumentException_UnsupportedEnumCast);
            }
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
