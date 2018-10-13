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

        private const string SLASH_SYMBOL = "/";
        private const string SPACE_TRANSFORM_CODE = "%20";

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
        /// Extension method useful for adding new URL parts with backslash.
        /// Method is taking into account if the provided base path has already backslash or not, also for urlPart parameter is controlled
        /// </summary>
        /// <param name="uriBuilder">Builder itself</param>
        /// <param name="urlPart">Part to add to path</param>
        /// <returns>UriBuilder itself</returns>
        public static UriBuilder AddPathPart(this UriBuilder uriBuilder, string urlPart)
        {
            var uriPartToAdd = ( urlPart.Contains(SLASH_SYMBOL) || uriBuilder.Path.EndsWith(SLASH_SYMBOL)) ? urlPart : SLASH_SYMBOL + urlPart;
            
            uriBuilder.Path += uriPartToAdd;

            return uriBuilder;
        }

        #endregion


        #region Private methods

        private static NameValueCollection GetUriQuery(UriBuilder uriBuilder) => HttpUtility.ParseQueryString(uriBuilder.Query);

        #endregion

    }
}
