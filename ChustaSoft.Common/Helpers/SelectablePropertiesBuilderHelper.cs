using ChustaSoft.Common.Models;
using ChustaSoft.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace ChustaSoft.Common.Helpers
{
    public static class SelectablePropertiesBuilderHelper
    {

        #region Extension methods

        /// <summary>
        /// Select property from any object to add to a ISelectablePropertiesBuilder
        /// </summary>
        /// <typeparam name="TMain">Object type for getting properties</typeparam>
        /// <typeparam name="TProperty">Property type selected</typeparam>
        /// <param name="objectSource">Object for getting properties</param>
        /// <param name="navigationPropertyPath">Expression taking parameter</param>
        /// <returns></returns>
        public static SelectablePropertiesBuilder<T> SelectProperty<T, TProperty>(this T objectSource, Expression<Func<T, TProperty>> navigationPropertyPath)
        {
            var propertyInfo = GetPropertyInfo(navigationPropertyPath);

            var builder = SelectablePropertiesBuilder<T>.InitBuilder();
            builder.AddSelected(propertyInfo);

            return builder;
        }

        /// <summary>
        /// From an existing ISelectablePropertiesBuilder, add new propertyes to be selected
        /// </summary>
        /// <typeparam name="TMain">Object type for getting properties</typeparam>
        /// <typeparam name="TProperty">Property type selected</typeparam>
        /// <param name="builder">The builder managed</param>
        /// <param name="navigationPropertyPath">Expression taking parameter</param>
        /// <returns></returns>
        public static SelectablePropertiesBuilder<T> ThenSelectProperty<T, TProperty>(this SelectablePropertiesBuilder<T> builder, Expression<Func<T, TProperty>> navigationPropertyPath)
        {
            var propertyInfo = GetPropertyInfo(navigationPropertyPath);

            builder.AddSelected(propertyInfo);

            return builder;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TMain"></typeparam>
        /// <typeparam name="TSub"></typeparam>
        /// <param name="builder"></param>
        /// <param name="navigationPropertyPath"></param>
        /// <returns></returns>
        public static SelectablePropertiesBuilder<TSub> ThenSelectFromCollection<TMain, TSub>(this SelectablePropertiesBuilder<TMain> builder, Expression<Func<TMain, IEnumerable<TSub>>> navigationPropertyPath)
        {
            var propertyInfo = GetPropertyInfo(navigationPropertyPath);

            builder.QueueSelected(propertyInfo);

            return SelectablePropertiesBuilder<TSub>.InitBuilder();
        }

        #endregion


        #region Private methods

        private static PropertyInfo GetPropertyInfo<T, TProperty>(Expression<Func<T, TProperty>> navigationPropertyPath)
        {
            var member = (MemberExpression)navigationPropertyPath.Body;
            var propertyName = member.Member.Name;
            var propertyInfo = new PropertyInfo { Name = propertyName };

            return propertyInfo;
        }

        #endregion

    }
}
