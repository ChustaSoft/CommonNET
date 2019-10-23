using ChustaSoft.Common.Models;
using System.Collections.Generic;
using System.Linq;

namespace ChustaSoft.Common.Helpers
{
    public static class ReflectionHelper
    {

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

        public static void Empty<T>(this T obj, IEnumerable<string> avoidedProperties = null)
        {
            foreach (var prop in typeof(T).GetProperties())
            {
                if(!avoidedProperties?.Contains(prop.Name) ?? true && prop.CanWrite)
                    prop.SetValue(obj, null, null);
            }
        }

    }
}
