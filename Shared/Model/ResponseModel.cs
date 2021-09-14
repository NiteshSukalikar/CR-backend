using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Model
{
    
    public class ResponseModel
    {
        /// <summary>
        /// Gets or sets the ReturnCode
        /// </summary>
        public object ReturnCode { get; set; }

        public object Data { get; set; }

        /// <summary>
        /// Gets or sets the Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the StatusCode
        /// </summary>
        public string StatusCode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether HasUpdatedToken
        /// Gets or sets the HasUpdatedToken
        /// </summary>
        public bool HasUpdatedToken { get; set; }

        /// <summary>
        /// Gets or sets the Token
        /// </summary>
        public object Token { get; set; }
    }
}
