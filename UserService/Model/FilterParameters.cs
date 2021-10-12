namespace UserService.Model
{
    using System.Runtime.Serialization;

    /// <summary>
    /// The FilterParameters
    /// </summary>
    public class FilterParameters
    {
        /// <summary>
        /// Gets or sets the CreatedBy
        /// </summary>
        [DataMember(Name = "CreatedBy")]
        /// <summary>
        /// Gets or sets the CreatedBy
        /// </summary>
        public long CreatedBy { get; set; }
    }
}
