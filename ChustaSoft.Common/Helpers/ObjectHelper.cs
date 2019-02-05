using System;
using System.ComponentModel;
using System.Linq;


namespace ChustaSoft.Common.Helpers
{
    /// <summary>
    /// Class for generic object purpose methods
    /// </summary>
    public static class ObjectHelper
    {
        
        #region Extension methods

        /// <summary>
        /// Extension method for any type, specifying a property name, could get the description 
        /// </summary>
        /// <param name="type">Object type to found a property decorated with DescriptionAttribute</param>
        /// <param name="property">The property to extract the description</param>
        /// <returns>Description of the property</returns>
        public static string GetDescription(this Type type, string property)
        {
            var properties = type.GetProperties().Where(p => p.Name == property.ToString());
            var description = properties.Select(p =>
                    Attribute.IsDefined(p, typeof(DescriptionAttribute))
                    ? (Attribute.GetCustomAttribute(p, typeof(DescriptionAttribute)) as DescriptionAttribute).Description : p.Name)
                .ToArray()
                .First();

            return description;
        }

        #endregion

    }
}
