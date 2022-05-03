using ChustaSoft.Common.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ChustaSoft.Common.Extensions
{
    public static class MvcOptionsExtensions
    {

        public static void AddActionPerformanceFilter(this MvcOptions mvcOptions)
        {
            mvcOptions.Filters.Add(typeof(TrackActionPerformanceFilter));
        }

        public static void AddPagePerformanceFilter(this MvcOptions mvcOptions)
        {
            mvcOptions.Filters.Add(typeof(TrackPagePerformanceFilter));
        }
    }
}
