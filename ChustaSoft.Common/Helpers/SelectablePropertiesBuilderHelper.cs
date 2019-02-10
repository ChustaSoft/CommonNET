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
        /// Select property from any object to add to a SelectablePropertiesBuilder
        /// </summary>
        /// <typeparam name="TMain">Object type for getting properties</typeparam>
        /// <typeparam name="TProperty">Property type selected</typeparam>
        /// <param name="objectSource">Object for getting properties</param>
        /// <param name="navigationPropertyPath">Expression taking parameter</param>
        /// <returns>Generated SelectablePropertiesBuilder</returns>
        public static SelectablePropertiesBuilder<TMain> SelectProperty<TMain, TProperty>(this TMain objectSource, Expression<Func<TMain, TProperty>> navigationPropertyPath)
        {
            var propertyInfo = GetPropertyInfo(navigationPropertyPath);

            var builder = SelectablePropertiesBuilder<TMain>.InitBuilder();
            builder.AddSelected(propertyInfo);

            return builder;
        }

        /// <summary>
        /// From an existing SelectablePropertiesBuilder, add new propertyes to be selected
        /// </summary>
        /// <typeparam name="TMain">Object type for getting properties</typeparam>
        /// <typeparam name="TProperty">Property type selected</typeparam>
        /// <param name="builder">The builder managed</param>
        /// <param name="navigationPropertyPath">Expression taking parameter</param>
        /// <returns>SelectablePropertiesBuilder itself</returns>
        public static SelectablePropertiesBuilder<TMain> ThenSelectProperty<TMain, TProperty>(this SelectablePropertiesBuilder<TMain> builder, Expression<Func<TMain, TProperty>> navigationPropertyPath)
        {
            var propertyInfo = GetPropertyInfo(navigationPropertyPath);

            builder.AddSelected(propertyInfo);

            return builder;
        }

        /// <summary>
        /// From an existing SelectablePropertiesBuilder, add new propertyes to be selected
        /// </summary>
        /// <typeparam name="TMain">Parent object type</typeparam>
        /// <typeparam name="TSub">Nested Object type for getting properties</typeparam>
        /// <typeparam name="TProperty">Property type selected</typeparam>
        /// <param name="builder">The builder managed</param>
        /// <param name="navigationPropertyPath">Expression taking parameter</param>
        /// <returns>SelectablePropertiesBuilder itself</returns>
        public static SelectablePropertiesBuilder<TMain, TSub> ThenSelectProperty<TMain, TSub, TProperty>(this SelectablePropertiesBuilder<TMain, TSub> builder, Expression<Func<TSub, TProperty>> navigationPropertyPath)
        {
            var propertyInfo = GetPropertyInfo(navigationPropertyPath);

            builder.AddSelected(propertyInfo);

            return builder;
        }

        /// <summary>
        /// From an existing SelectablePropertiesBuilder, start selecting properties from a Nested collection
        /// </summary>
        /// <typeparam name="TMain">Parent object type</typeparam>
        /// <typeparam name="TSub">Nested Object type for getting properties</typeparam>
        /// <param name="builder">The builder managed</param>
        /// <param name="navigationPropertyPath">Expression for select nested collection</param>
        /// <returns>SelectablePropertiesBuilder itself</returns>
        public static SelectablePropertiesBuilder<TMain, TSub> ThenSelectFromCollection<TMain, TSub>(this SelectablePropertiesBuilder<TMain> builder, Expression<Func<TMain, IEnumerable<TSub>>> navigationPropertyPath)
        {
            var propertyInfo = GetPropertyInfo(navigationPropertyPath);

            return SelectablePropertiesBuilder<TMain, TSub>.InitBuilder(builder, propertyInfo);
        }

        /// <summary>
        /// From an existing SelectablePropertiesBuilder, start selecting properties from a Complex object
        /// </summary>
        /// <typeparam name="TMain">Parent object type</typeparam>
        /// <typeparam name="TSub">Nested Object type for getting properties</typeparam>
        /// <param name="builder">The builder managed</param>
        /// <param name="navigationPropertyPath">Expression for select nested collection</param>
        /// <returns>SelectablePropertiesBuilder itself</returns>
        public static SelectablePropertiesBuilder<TMain, TSub> ThenSelectFromProperty<TMain, TSub>(this SelectablePropertiesBuilder<TMain> builder, Expression<Func<TMain, TSub>> navigationPropertyPath)
        {
            var propertyInfo = GetPropertyInfo(navigationPropertyPath);

            return SelectablePropertiesBuilder<TMain, TSub>.InitBuilder(builder, propertyInfo);
        }

        /// <summary>
        /// From an existing SelectablePropertiesBuilder, for finishing adding properties from nested collections
        /// </summary>
        /// <typeparam name="TMain">Parent object type</typeparam>
        /// <typeparam name="TSub">Nested Object type for getting properties</typeparam>
        /// <param name="builder">The builder managed</param>
        /// <returns>The parent SelectablePropertiesBuilder</returns>
        public static SelectablePropertiesBuilder<TMain> BackToParent<TMain, TSub>(this SelectablePropertiesBuilder<TMain, TSub> builder)
        {
            return builder.BackToParent();
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
