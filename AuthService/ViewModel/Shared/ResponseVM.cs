namespace AuthService.ViewModel.Shared
{
    /// <summary>
    /// Defines the <see cref="ResponseVM" />
    /// </summary>
    public class ResponseVM
    {
        /// <summary>
        /// Gets or sets the Data
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Gets or sets the Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the StatucCode
        /// </summary>
        public int StatucCode { get; set; }
    }
}
