using ChustaSoft.Common.Builders;
using ChustaSoft.Common.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChustaSoft.Common.Helpers
{
    public static class ActionResponseBuilderHelper
    {

        #region Public methods

        /// <summary>
        /// Extension method for allowing add single elements to the existing data inside an ActionResponse in case of being a Collection
        /// </summary>
        /// <typeparam name="T">Type of Data inside ActionResponse</typeparam>
        /// <typeparam name="TElement">Type of element to add</typeparam>
        /// <param name="builder">The builder itself</param>
        /// <param name="element">Element to add</param>
        /// <returns>The builder itself</returns>
        public static ActionResponseBuilder<T> AddElement<T, TElement>(this ActionResponseBuilder<T> builder, TElement element) where T : ICollection<TElement>
        {
            ValidateDataCollection<T, TElement>(builder);

            AddSingleElement(builder, element);

            return builder;
        }

        /// <summary>
        /// Extension method for allowing add a collection of elements to the existing data inside an ActionResponse in case of being a Collection
        /// </summary>
        /// <typeparam name="T">Type of Data inside ActionResponse</typeparam>
        /// <typeparam name="TElement">Type of element to add</typeparam>
        /// <param name="builder">The builder itself</param>
        /// <param name="element">Element collection to add</param>
        /// <returns>The builder itself</returns>
        public static ActionResponseBuilder<T> AddRange<T, TElement>(this ActionResponseBuilder<T> builder, ICollection<TElement> elements) where T : ICollection<TElement>
        {
            ValidateDataCollection<T, TElement>(builder);

            foreach (var element in elements.ToList())
                AddSingleElement(builder, element);

            return builder;
        }

        #endregion


        #region Private methods

        private static void AddSingleElement<T, TElement>(ActionResponseBuilder<T> builder, TElement element) where T : ICollection<TElement>
        {
            builder.GetActionResponse().Data.Add(element);
        }

        private static void ValidateDataCollection<T, TElement>(ActionResponseBuilder<T> builder) where T : ICollection<TElement>
        {
            if (builder.GetActionResponse().Data == null)
                throw new ArgumentException(ExceptionResources.ArgumentException_ActionResponseBuilder_DataNull);
        }

        #endregion

    }
}
