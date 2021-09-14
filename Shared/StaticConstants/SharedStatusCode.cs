using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.StaticConstants
{    
    public enum SharedStatusCode
    {
        /// <summary>
        /// Defines the NotSpecified
        /// </summary>
        NotSpecified = 0,
        //HTTP Error Codes
        Ok = 200,
        /// <summary>
        /// Defines the Created
        /// </summary>
        Created = 201,
        /// <summary>
        /// Defines the Accepted
        /// </summary>
        Accepted = 202,
        /// <summary>
        /// Defines the NonAuthoritativeInformation
        /// </summary>
        NonAuthoritativeInformation = 203,
        /// <summary>
        /// Defines the NoContent
        /// </summary>
        NoContent = 204,

        BadRequest = 401,

        /// <summary>
        /// Defines the RequestTimeout
        /// </summary>
        RequestTimeout = 408,
        /// <summary>
        /// Defines the publicServerError
        /// </summary>
        publicServerError = 500,
        /// <summary>
        /// Defines the NotImplemented
        /// </summary>
        NotImplemented = 501,
        /// <summary>
        /// Defines the BadGateway
        /// </summary>
        BadGateway = 502,
        /// <summary>
        /// Defines the ServiceUnavailable
        /// </summary>
        ServiceUnavailable = 503,
        /// <summary>
        /// Defines the GatewayTimeout
        /// </summary>
        GatewayTimeout = 504,
        /// <summary>
        /// Defines the HTTPVersionNotSupported
        /// </summary>
        HTTPVersionNotSupported = 505,
        /// <summary>
        ///  Too Many Requests
        /// </summary>
        TooManyRequests = 429
        //Custom Error Codes    
    }
}
