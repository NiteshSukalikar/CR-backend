namespace AuthService.Model.Auth
{
    /// <summary>
    /// Defines the ResponseTokenVM
    /// </summary>
    public class ResponseTokenVM
    {
        /// <summary>
        /// Gets or sets the Token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets the UserId
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Gets or sets the IpAddress
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// Gets or sets the LoginUserName
        /// </summary>
        public string LoginUserName { get; set; }

        /// <summary>
        /// Gets or sets the lastLoginDate
        /// </summary>
        public long lastLoginDate { get; set; }

        /// <summary>
        /// Gets or sets the access_token
        /// </summary>
        public string access_token { get; set; }

        /// <summary>
        /// Gets or sets the refresh_token
        /// </summary>
        public string refresh_token { get; set; }

        /// <summary>
        /// Gets or sets the guid
        /// </summary>
        public string guid { get; set; }

        /// <summary>
        /// Gets or sets the data
        /// </summary>
        public object data { get; set; }

        /// <summary>
        /// Gets or sets the StatusCode
        /// </summary>
        public string StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the UserRole
        /// </summary>
        public string UserRole { get; set; }

        public long MemberType { get; set; }
        public long AssociateId { get; set; }
        public long IsMandate { get; set; }

        public string MembershipType { get; set; }
    }
}
