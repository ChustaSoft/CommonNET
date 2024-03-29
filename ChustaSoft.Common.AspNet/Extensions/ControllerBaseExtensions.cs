﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Microsoft.AspNetCore.Mvc
{
    public static class ControllerBaseExtensions
    {

        private const string ACCESS_TOKEN_HEADER = "Authorization";
        

        /// <summary>
        /// Gets the user id from the autorization token header
        /// </summary>
        /// <param name="controllerBase">Controller from wich get the information</param>
        /// <param name="userIdClaim">Claim where the userd id is located</param>
        /// <returns>User id found in the access token authorization header</returns>
        public static string GetRequestUserId(this ControllerBase controllerBase)
        {
            var jwt = controllerBase.GetTokenFromAuthHeader();
            
            return
                jwt.Claims.FirstOrDefault(c => c.Type.Equals("oid", StringComparison.OrdinalIgnoreCase))?.Value ??
                jwt.Claims.FirstOrDefault(c => c.Type.Equals("nameid", StringComparison.OrdinalIgnoreCase))?.Value ??
                throw new InvalidOperationException("User id cannot be null");
        }

        /// <summary>
        /// Gets the user email from the autorization token header
        /// </summary>
        /// <param name="controllerBase">Controller from wich get the information</param>
        /// <returns>Email string if found, empty otherwise</returns>
        public static string GetRequestUserEmail(this ControllerBase controllerBase)
        {
            var claims = controllerBase.GetClaims();

            return
                claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value ??
                claims.FirstOrDefault(c => c.Type == "upn")?.Value ??
                claims.FirstOrDefault(c => c.Type == "sub")?.Value ??
                throw new InvalidOperationException("User email not found");
        }


        private static IEnumerable<Claim> GetClaims(this ControllerBase controllerBase)
        {
            var identityClaims = (controllerBase.HttpContext.User?.Identity as ClaimsIdentity)?.Claims;

            if(identityClaims != null && identityClaims.Any())
                return identityClaims;
            else
                return controllerBase.GetTokenFromAuthHeader().Claims;
        }

        public static JwtSecurityToken GetTokenFromAuthHeader(this ControllerBase controllerBase)
        {
            var accessToken = controllerBase.Request.Headers[ACCESS_TOKEN_HEADER].FirstOrDefault()?.Split(" ")[1];
            var jwt = new JwtSecurityTokenHandler().ReadToken(accessToken) as JwtSecurityToken;

            return jwt;
        }

    }
}
