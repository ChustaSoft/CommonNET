using ChustaSoft.Common.Utilities;
using System.Collections.Generic;
using System.Linq;


namespace ChustaSoft.Common.Helpers
{
    public static class CollectionsHelper
    {

        public static PaginatedList<T> Paginate<T>(this IEnumerable<T> data, int pageSize, int currentPageIndex = 0)
        {
            if (data.Count() < pageSize)
                currentPageIndex = 0;

            var paginatedData = data.Skip(currentPageIndex * pageSize).Take(pageSize);

            return new PaginatedList<T>(paginatedData, data.Count(), currentPageIndex + 1);
        }

    }
}
