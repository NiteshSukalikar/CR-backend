namespace AuthService.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines the <see cref="LoginViewModel" />
    /// </summary>
    [DataContract]
    public class LoginViewModel
    {
        /// <summary>
        /// Gets or sets the Email
        /// </summary>
        [DataMember(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the UserName
        /// </summary>
        [DataMember(Name = "UserName")]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the Password
        /// </summary>
        [DataMember(Name = "Password")]
        public byte[] Password { get; set; }

        /// <summary>
        /// Gets or sets the IpAddress
        /// </summary>
        [DataMember(Name = "IpAddress")]
        public string IpAddress { get; set; }

        /// <summary>
        /// Gets or sets the UTCDate
        /// </summary>
        [DataMember(Name = "UTCDate")]
        public long UTCDate { get; set; }

        /// <summary>
        /// Gets or sets the LogoutDate
        /// </summary>
        [DataMember(Name = "LogoutDate")]
        public long LogoutDate { get; set; }
    }

    /// <summary>
    /// Defines the ResetPasswordModel
    /// </summary>
    public class ResetPasswordModel
    {
        /// <summary>
        /// Gets or sets the UserLogin
        /// </summary>
        [DataMember(Name = "UserLogin")]
        public string UserLogin { get; set; }

        /// <summary>
        /// Gets or sets the Password
        /// </summary>
        [DataMember(Name = "Password")]
        public string Password { get; set; }
    }

    /// <summary>
    /// Defines the ResponseObjectTest
    /// </summary>
    public class ResponseObjectTest
    {
        /// <summary>
        /// Gets or sets the code
        /// </summary>
        public int code { get; set; }

        /// <summary>
        /// Gets or sets the message
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// Gets or sets the data
        /// </summary>
        public string data { get; set; }
    }

    /// <summary>
    /// Defines the <see cref="AuthCommonModel" />
    /// </summary>
    public class AuthCommonModel
    {
        /// <summary>
        /// Gets or sets the userId
        /// </summary>
        [Required]
        public long userId { get; set; }
    }

    public class CreatePasswordModel
    {
        /// <summary>
        /// Gets or sets the UserLogin
        /// </summary>
        [DataMember(Name = "Guid")]
        public string Guid { get; set; }

        /// <summary>
        /// Gets or sets the Password
        /// </summary>
        [DataMember(Name = "Password")]
        public byte[] Password { get; set; }
    }
}
