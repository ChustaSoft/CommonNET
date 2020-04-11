using ChustaSoft.Common.Resources;
using ChustaSoft.Common.Utilities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;


namespace ChustaSoft.Common.Helpers
{
    /// <summary>
    /// Collection of utilities used on collection types
    /// </summary>
    public static class CollectionsHelper
    {

        #region Extension methods

        /// <summary>
        /// Extension method to create a IReadOnlyList PaginatedList from an IEnumerable
        /// </summary>
        /// <typeparam name="T">Collection type</typeparam>
        /// <param name="data">Collection to paginate</param>
        /// <param name="pageSize">Configured page size</param>
        /// <param name="currentPageIndex">Page index for the pagination (Zero based)</param>
        /// <returns>PaginatedList for requested data</returns>
        public static PaginatedList<T> Paginate<T>(this IEnumerable<T> data, int pageSize, int currentPageIndex = 0)
        {
            CheckPageIndex(data, pageSize, ref currentPageIndex);

            var paginatedData = data.Skip(currentPageIndex * pageSize).Take(pageSize);

            return new PaginatedList<T>(paginatedData, data.Count(), currentPageIndex++);
        }

        /// <summary>
        /// Adds multiple elements to a ConcurrentBag
        /// </summary>
        /// <typeparam name="T">Typed objetc</typeparam>
        /// <param name="this">ConcurrentBag itself</param>
        /// <param name="items">Items to add into ConcurrentBag</param>
        public static void AddRange<T>(this ConcurrentBag<T> @this, IEnumerable<T> items)
        {
            foreach (var element in items)
            {
                @this.Add(element);
            }
        }

        #endregion


        #region Private methods

        private static void CheckPageIndex<T>(IEnumerable<T> data, int pageSize, ref int currentPageIndex)
        {
            var dataCount = data.Count();
            if (((dataCount / pageSize) < currentPageIndex && dataCount > pageSize) || currentPageIndex < 0)
                throw new InvalidOperationException(ExceptionResources.InvalidOperationException_PageIndexError);

            else if (dataCount < pageSize)
                currentPageIndex = 0;
        }

        #endregion

    }
}
