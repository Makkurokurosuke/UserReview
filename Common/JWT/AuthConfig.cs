﻿using Microsoft.IdentityModel.Tokens;
using Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class AuthConfig
    {

        /// <summary>
        /// API token Audience (aud) claim
        /// </summary>
        public const string ApiJwtAudience = "ReviewAPIAudience";
        /// <summary>
        /// API token Issuer (iss) claim
        /// </summary>
        public const string ApiJwtIssuer = "ReviewAPIIssur";
        /// <summary>
        /// API token Expiration (exp) in seconds
        /// </suemmary>
        public const int ApiJwtExpirationSec = 30 * 60 * 60 * 24;

        /// <summary>
        /// API common key pass
        /// </summary>
        private const string ApiSecurityTokenPass = "1234567890QWERTYUIOPASDFGHJKLZXCVBNN";

        /// <summary>
        /// API token generation singleton common key
        /// </summary>
        private static SymmetricSecurityKey signingKey;

        /// <summary>
        /// Get API Singleton common key
        /// </summary>
        public static SymmetricSecurityKey ApiJwtSigningKey
        {
            get
            {
                if (signingKey == null)
                {
                    byte[] key = Encoding.UTF8.GetBytes(ApiSecurityTokenPass.ToCharArray(), 0, 32);
                    signingKey = new SymmetricSecurityKey(key);
                }
                return signingKey;
            }
        }
    }
}
