using ChustaSoft.Common.Resources;
using ChustaSoft.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ChustaSoft.Common.Helpers
{
    public static class CollectionsHelper
    {

        public static PaginatedList<T> Paginate<T>(this IEnumerable<T> data, int pageSize, int currentPageIndex = 0)
        {
            CheckPageIndex(data, pageSize, ref currentPageIndex);

            var paginatedData = data.Skip(currentPageIndex * pageSize).Take(pageSize);

            return new PaginatedList<T>(paginatedData, data.Count(), currentPageIndex++);
        }

        private static void CheckPageIndex<T>(IEnumerable<T> data, int pageSize, ref int currentPageIndex)
        {
            var dataCount = data.Count();
            if (((dataCount / pageSize) < currentPageIndex && dataCount > pageSize) || currentPageIndex < 0)
                throw new InvalidOperationException(ExceptionResources.InvalidOperationException_PageIndexError);

            else if (dataCount < pageSize)
                currentPageIndex = 0;
        }
    }
}
