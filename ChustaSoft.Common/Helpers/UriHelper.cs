using System;
using System.Web;
using System.Collections.Specialized;


namespace ChustaSoft.Common.Helpers
{

    /// <summary>
    /// Collection of utilities for Uri management
    /// </summary>
    public static class UriHelper
    {

        #region Fields

        private const string SPACE_STR = " ";
        private const string SLASH_STR = "/";
        private const string SPACE_TRANSFORM_STR = "%20";

        #endregion


        #region Extension Methods

        /// <summary>
        /// Extension method for UriBuilder allowing to add a parameter to the URL easily
        /// </summary>
        /// <param name="uriBuilder">Builder itself</param>
        /// <param name="paramName">Name of the parameter to add</param>
        /// <param name="paramValue">Value of the parameter to add</param>
        /// <returns>UriBuilder itself</returns>
        public static UriBuilder AddParameter(this UriBuilder uriBuilder, string paramName, object paramValue)
        {
            var uriQuery = GetUriQuery(uriBuilder);

            uriQuery[paramName] = paramValue.ToString();

            uriBuilder.Query = uriQuery.ToString();

            return uriBuilder;
        }

        /// <summary>
        /// Extension method useful for adding new URL parts with backslash (Don't needed)
        /// </summary>
        /// <param name="uriBuilder"></param>
        /// <param name="urlPart"></param>
        /// <returns></returns>
        public static UriBuilder AddPart(this UriBuilder uriBuilder, string urlPart)
        {
            var uriPartToAdd = urlPart.Contains(SLASH_STR) ? urlPart : SLASH_STR + urlPart;
            uriBuilder.Query += uriPartToAdd;

            return uriBuilder;
        }

        #endregion


        #region Private methods

        private static NameValueCollection GetUriQuery(UriBuilder uriBuilder) => HttpUtility.ParseQueryString(uriBuilder.Query);

        private static string GetFormattedParam(object paramValue) => paramValue.ToString().TrimEnd().TrimStart().Replace(SPACE_STR, SPACE_TRANSFORM_STR);

        #endregion

    }
}
