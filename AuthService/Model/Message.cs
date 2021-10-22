namespace AuthService.Model
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines the <see cref="Message{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DataContract]
    public class Message<T>
    {
        /// <summary>
        /// Gets or sets a value indicating whether IsSuccess
        /// </summary>
        [DataMember(Name = "IsSuccess")]
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Gets or sets the ReturnMessage
        /// </summary>
        [DataMember(Name = "ReturnMessage")]
        public string ReturnMessage { get; set; }

        /// <summary>
        /// Gets or sets the StatusCode
        /// </summary>
        [DataMember(Name = "StatusCode")]
        public string StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the Data
        /// </summary>
        [DataMember(Name = "Data")]
        public T Data { get; set; }
    }
}
