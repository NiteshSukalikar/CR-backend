namespace AuthService.ViewModel.Shared
{
    /// <summary>
    /// Defines the <see cref="ListResponseVM" />
    /// </summary>
    public class ListResponseVM
    {
        /// <summary>
        /// Gets or sets the Page
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Gets or sets the Count
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the TotalCount
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Gets or sets the Items
        /// </summary>
        public object Items { get; set; }
    }
}
