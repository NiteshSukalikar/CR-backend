namespace AuthService.Model
{
    /// <summary>
    /// Defines the <see cref="CheckAccessTokenModel" />
    /// </summary>
    public class CheckAccessTokenModel
    {
        /// <summary>
        /// Gets or sets the access_token
        /// </summary>
        public string access_token { get; set; }

        /// <summary>
        /// Gets or sets the refresh_token
        /// </summary>
        public string refresh_token { get; set; }
    }
}
