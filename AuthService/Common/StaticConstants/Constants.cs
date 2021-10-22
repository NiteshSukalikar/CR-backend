namespace AuthService.Common.StaticConstants
{
    /// <summary>
    /// Defines the <see cref="Constants" />
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Gets or sets the DbConn
        /// </summary>
        public static string DbConn { get; set; }

        public static string AzureDbConn { get; set; }
        public static string ImagePath { get; set; }
        public static string FolderName { get; set; }
        /// <summary>
        /// Defines the DefaultPageSize
        /// </summary>
        public const int DefaultPageSize = 30;

        /// <summary>
        /// Defines the DefaultPageNo
        /// </summary>
        public const int DefaultPageNo = 1;

        /// <summary>
        /// Defines the MaxPageSize
        /// </summary>
        public const int MaxPageSize = 500;

        /// <summary>
        /// Defines the CommentMaxLength
        /// </summary>
        public const int CommentMaxLength = 300;

        /// <summary>
        /// Defines the TextMaxLenght
        /// </summary>
        public const int TextMaxLenght = 5000;

        /// <summary>
        /// Gets or sets the TokenSecretKey
        /// </summary>
        public static string TokenSecretKey { get; set; }

        /// <summary>
        /// Gets or sets the TokenIssuer
        /// </summary>
        public static string TokenIssuer { get; set; }

        /// <summary>
        /// Gets or sets the TokenAudience
        /// </summary>
        public static string TokenAudience { get; set; }

        /// <summary>
        /// Gets or sets the TokenExpiryDays
        /// </summary>
        public static int TokenExpiryDays { get; set; }

        /// <summary>
        /// Gets or sets the LogFilePath
        /// </summary>
        public static string LogFilePath { get; set; }

        public const int InchoraCompanyId = 1;

        public const string keybytes ="7061737323313233";
        public const string iv = "7061737323313233";


        // Twilio account details -

        //public const string AccountSid = "ACcf8bf9b7d2fa61f709b9d70bbd2e7849";

        //public const string AuthToken = "cdd80676136cf902fe6284675872b650";

        //public const string VerificationSid = "VAd2538287192fd8216a46e2af3376d453";
        //https://www.twilio.com/console/verify/services

        //+12243238312
        // recovery code - G_jLi8sY8lZvVO8-90_fSYvvvKh6MX4blz2nXq0y

        public static string AccountSid { get; set; }
        public static string AuthToken { get; set; }
        public static string VerificationSid { get; set; }

    }
}
