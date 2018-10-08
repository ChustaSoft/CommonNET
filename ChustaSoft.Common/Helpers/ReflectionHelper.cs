using System;
using System.Linq;


namespace ChustaSoft.Common.Helpers
{
    public static class ReflectionHelper
    {
        
        #region Extension methods

        public static T GetSingleImplementation<T>(this T targetType)
        {
            var type = typeof(T);
            var implementation = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Single(p => type.IsAssignableFrom(p) && p.Name != type.Name);

            return (T)Activator.CreateInstance(implementation);
        }

        #endregion

    }
}
