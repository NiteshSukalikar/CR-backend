namespace AuthService.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines the <see cref="UserModel" />
    /// </summary>
    [DataContract]
    public class UserModel
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        [Required]
        [DataMember(Name = "Id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the FirstName
        /// </summary>
        [DataMember(Name = "FirstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the LastName
        /// </summary>
        [DataMember(Name = "LastName")]
        public string LastName { get; set; }

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
        /// Gets or sets the ContactNumber
        /// </summary>
        [DataMember(Name = "ContactNumber")]
        public string ContactNumber { get; set; }

        /// <summary>
        /// Gets or sets the Password
        /// </summary>
        [DataMember(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the SourceId
        /// </summary>
        [DataMember(Name = "SourceId")]
        public long SourceId { get; set; }

        /// <summary>
        /// Gets or sets the Status
        /// </summary>
        [DataMember(Name = "Status")]
        public bool Status { get; set; }

        /// <summary>
        /// Gets or sets the ActiveStatusId
        /// </summary>
        [DataMember(Name = "ActiveStatusId")]
        public byte ActiveStatusId { get; set; }

        /// <summary>
        /// Gets or sets the CreatedBy
        /// </summary>
        [DataMember(Name = "CreatedBy")]
        public long CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the CreatedOn
        /// </summary>
        [DataMember(Name = "CreatedOn")]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the UpdatedBy
        /// </summary>
        [DataMember(Name = "UpdatedBy")]
        public long UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the UpdatedOn
        /// </summary>
        [DataMember(Name = "UpdatedOn")]
        public DateTime UpdatedOn { get; set; }

        /// <summary>
        /// Gets or sets the UserId
        /// </summary>
        [DataMember(Name = "UserId")]
        public long UserId { get; set; }
        /// <summary>
        /// Gets or sets the UserId
        /// </summary>
        [DataMember(Name = "CompanyName")]
        public string CompanyName { get; set; }

        [DataMember(Name = "MemberTypeId")]
        public string MemberTypeId { get; set; }
    }
}
