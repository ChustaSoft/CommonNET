using ChustaSoft.Common.Exceptions;
using System;
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

            object[] attribArray = fieldInfo.GetCustomAttributes(false);

            if (attribArray.Length > 0)
            {
                var attrib = attribArray.FirstOrDefault(a => a.GetType() == typeof(DescriptionAttribute)) as DescriptionAttribute;

                if (attrib != null)
                    return attrib.Description;
            }
            return obj.ToString();
        }

        #endregion


        #region Helper Methods

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
            if (typeof(T).IsEnum)
            {
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
            else throw new ArgumentException("T must be an enumerated type");
        }

        #endregion

    }
}
