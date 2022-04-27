using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Microsoft.AspNetCore.Mvc
{
    public static class ControllerBaseExtensions
    {

        private const string ACCESS_TOKEN_HEADER = "Authorization";
        private const string OID_CLAIM = "oid";


        /// <summary>
        /// Gets the user id from the autorization token header
        /// </summary>
        /// <param name="controllerBase">Controller from wich get the information</param>
        /// <param name="userIdClaim">Claim where the userd id is located</param>
        /// <returns>User id found in the access token authorization header</returns>
        public static string GetRequestUserId(this ControllerBase controllerBase, string userIdClaim = OID_CLAIM)
        {
            var jwt = GetTokenFromAuthHeader(controllerBase);
            var userId = jwt.Claims.FirstOrDefault(x => x.Type.Equals(userIdClaim, StringComparison.OrdinalIgnoreCase))?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                throw new InvalidOperationException("User id cannot be null");
            }

            return userId;
        }

        /// <summary>
        /// Gets the user email from the autorization token header
        /// </summary>
        /// <param name="controllerBase">Controller from wich get the information</param>
        /// <returns>Email string if found, empty otherwise</returns>
        public static string GetRequestUserEmail(this ControllerBase controllerBase)
        {
            var jwt = GetTokenFromAuthHeader(controllerBase);

            return jwt.Claims
               .Any(c => c.Type == "upn")
               ? jwt.Claims.FirstOrDefault(c => c.Type == "upn").Value
               : jwt.Claims.FirstOrDefault(c => c.Type == "sub")?.Value
               ?? 
               string.Empty;
        }


        private static JwtSecurityToken GetTokenFromAuthHeader(ControllerBase controllerBase)
        {
            var accessToken = controllerBase.Request.Headers[ACCESS_TOKEN_HEADER].FirstOrDefault()?.Split(" ")[1];
            var jwt = new JwtSecurityTokenHandler().ReadToken(accessToken) as JwtSecurityToken;

            return jwt;
        }

    }
}
