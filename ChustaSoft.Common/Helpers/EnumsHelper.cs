using ChustaSoft.Common.Exceptions;
using System;
using System.ComponentModel;
using System.Linq;


namespace ChustaSoft.Common.Helpers
{
    public static class EnumsHelper
    {

        #region Extension Methods

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
