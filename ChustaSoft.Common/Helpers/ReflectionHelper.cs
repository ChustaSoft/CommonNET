using ChustaSoft.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace ChustaSoft.Common.Helpers
{
    public static class ReflectionHelper
    {

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

        /// <summary>
        /// Try to retrieve the value of a property inside an object by reflection
        /// </summary>
        /// <param name="obj">Object containing the property to retrieve</param>
        /// <param name="propertyName">Name of the property to be retrieved</param>
        /// <returns>Property value retrived</returns>
        public static object GetPropertyValue(this object obj, string propertyName)
        {
            var property = obj.GetType().GetProperty(propertyName);
            var value = property.GetValue(obj, null);

            return value;
        }

        /// <summary>
        /// Get properties list from an specified objetc
        /// </summary>
        /// <typeparam name="T">Generic Object type</typeparam>
        /// <param name="obj">Object to extract properties</param>
        /// <returns>List of PropertyInfo retrieved from the object</returns>
        public static IEnumerable<PropertyInfo> GetProperties<T>(this T obj)
        {
            foreach (var prop in typeof(T).GetProperties())
            {
                yield return new PropertyInfo
                {
                    Name = prop.Name,
                    Value = prop.GetValue(obj, null),
                    Type = prop.PropertyType
                };
            }
        }        

        /// <summary>
        /// Remove every data from an object using reflection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="avoidedProperties"></param>
        public static void Empty<T>(this T obj, IEnumerable<string> avoidedProperties = null)
        {
            foreach (var prop in typeof(T).GetProperties())
            {
                if (!avoidedProperties?.Contains(prop.Name) ?? true && prop.CanWrite)
                    prop.SetValue(obj, null, null);
            }
        }

    }
}
