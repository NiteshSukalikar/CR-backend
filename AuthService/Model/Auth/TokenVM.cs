namespace AuthService.Model.Auth
{
    /// <summary>
    /// Defines the <see cref="TokenVM" />
    /// </summary>
    public class TokenVM
    {
        /// <summary>
        /// Gets or sets the AccessToken
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the ExpiresIn
        /// </summary>
        public int ExpiresIn { get; set; }

        /// <summary>
        /// Gets or sets the ErrorMessage
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
