namespace Incontrl.Sdk.Models
{
    /// <summary>
    /// An enum that describes the status of the document.
    /// </summary>
    public enum DocumentStatus : short
    {
        /// <summary>
        /// Draft
        /// </summary>
        Draft = 0,

        /// <summary>
        /// Issued
        /// </summary>
        Issued = 1,

        /// <summary>
        /// Overdue
        /// </summary>
        Overdue = 2,

        /// <summary>
        /// Partial
        /// </summary>
        Partial = 3,

        /// <summary>
        /// Paid
        /// </summary>
        Paid = 4,

        /// <summary>
        /// Void
        /// </summary>
        Void = 5,

        /// <summary>
        /// Deleted
        /// </summary>
        Deleted = 6
    }
}
