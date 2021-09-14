using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Model
{
    /// <summary>
    /// Defines the <see cref="ApplicationSettings" />
    /// </summary>
    public class ApplicationSettings
    {
        /// <summary>
        /// Gets or sets the JWT_Secret
        /// </summary>
        public string JWT_Secret { get; set; }

        /// <summary>
        /// Gets or sets the Client_URL
        /// </summary>
        public string Client_URL { get; set; }
    }
}
