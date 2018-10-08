using System;
using System.Web;
using System.Collections.Specialized;


namespace ChustaSoft.Common.Helpers
{
    public static class UriHelper
    {
        private const string SPACE_STR = " ";
        private const string SPACE_TRANSFORM_STR = "%20";

        public static UriBuilder AddParameter(this UriBuilder uriBuilder, string paramName, object paramValue)
        {
            var uriQuery = GetUriQuery(uriBuilder);

            uriQuery[paramName] = paramValue.ToString();

            uriBuilder.Query = uriQuery.ToString();

            return uriBuilder;
        }
        
        private static NameValueCollection GetUriQuery(UriBuilder uriBuilder) => HttpUtility.ParseQueryString(uriBuilder.Query);

        private static string GetFormattedParam(object paramValue) => paramValue.ToString().TrimEnd().TrimStart().Replace(SPACE_STR, SPACE_TRANSFORM_STR);

    }
}
