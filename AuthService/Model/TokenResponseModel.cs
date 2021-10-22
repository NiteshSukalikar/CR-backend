using System;
using System.Collections.Generic;
using System.Text;

namespace AuthService.Model
{

    /// <summary>
    /// Defines the TokenResponseModel
    /// </summary>
    public class TokenResponseModel
    {
        /// <summary>
        /// Gets or sets the Data
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Gets or sets the Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the StatusCode
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether HasUpdatedToken
        /// Gets or sets the HasUpdatedToken
        /// </summary>
        public bool HasUpdatedToken { get; set; }

        /// <summary>
        /// Gets or sets the Token
        /// </summary>
        public object Token { get; set; }

        /// <summary>
        /// Gets or sets the Code
        /// </summary>
        public string Code { get; set; }
    }
}

