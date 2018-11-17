using ChustaSoft.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;


namespace ChustaSoft.Common.Helpers
{

    /// <summary>
    /// Collection of utilities for Enum types
    /// </summary>
    public static class EnumsHelper
    {

        #region Extension Methods

        /// <summary>
        /// Method to retrieve Description based on DescriptionAttribute from an Enum type.
        /// In case of not implementing, enum type itself would be returned as string
        /// </summary>
        /// <param name="obj">Enum type to get its description</param>
        /// <returns>Description of the Enum in case of success, otherise name itself as ToString </returns>
        public static string GetDescription(this Enum obj)
        {
            var fieldInfo = obj.GetType().GetField(obj.ToString());
            var attribArray = fieldInfo.GetCustomAttributes(false);

            if (attribArray.Length > 0)
            {
                var attrib = attribArray.FirstOrDefault(a => a.GetType() == typeof(DescriptionAttribute)) as DescriptionAttribute;

                if (attrib != null)
                    return attrib.Description;
            }
            return obj.ToString();
        }

        /// <summary>
        /// Get IEnumerable with all elements inside an Enum Type
        /// </summary>
        /// <typeparam name="T">Enum Type</typeparam>
        /// <returns>IEnumerable with all Enum Type</returns>
        public static IEnumerable<T> GetEnumList<T>() where T : struct, IConvertible
        {
            CheckIfIsEnum<T>();

            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        /// <summary>
        /// Get IDictionary with all elements inside an Enum Type
        /// </summary>
        /// <typeparam name="T">Enum Type</typeparam>
        /// <returns>IDictionary with all Enum Type</returns>
        public static IDictionary<int, T> GetEnumDictionary<T>() where T : struct, IConvertible
        {
            return GetEnumList<T>().ToDictionary(t => (int)(object)t, t => t);
        }

        #endregion


        #region Helper Methods

        /// <summary>
        /// Get Enum member of a type by a string
        /// </summary>
        /// <typeparam name="T">Enum Type</typeparam>
        /// <param name="str">String for getting the Enum type</param>
        /// <returns>Enum member retrived</returns>
        public static T GetByString<T>(string str) where T : struct, IConvertible
        {
            CheckIfIsEnum<T>();

            return (T)Enum.Parse(typeof(T), str);
        }

        /// <summary>
        /// Method to retrieve an Enum type from a strng based on DescriptionAttribute.
        /// In case of another type, ArgumentException will be thrown
        /// In case of error trying to find a type for an specific string, EnumNotFoundException will be thrown
        /// </summary>
        /// <typeparam name="T">Enum type</typeparam>
        /// <param name="str">string for find Enum type based on DescriptionAttribute</param>
        /// <returns></returns>
        public static T GetByDescription<T>(string str) where T : struct, IConvertible
        {
            CheckIfIsEnum<T>();

            var enumValues = Enum.GetValues(typeof(T)).Cast<T>();

            foreach (var enumValue in enumValues)
            {
                var enumType = enumValue as Enum;
                var enumDescription = enumType.GetDescription();

                if (enumDescription == str)
                    return enumValue;
            }
            throw new EnumNotFoundException(typeof(T), str);
        }

        #endregion

        
        #region Private methods

        private static void CheckIfIsEnum<T>()
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("T must be an enumerated type");
        }

        #endregion

    }
}
