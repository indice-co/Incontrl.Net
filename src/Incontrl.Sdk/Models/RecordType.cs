namespace Incontrl.Sdk.Models
{
    /// <summary>
    /// The category of Document Type.
    /// </summary>
    public enum RecordType : short
    {
        /// <summary>
        /// Accounts payable.
        /// </summary>
        AccountsPayable = -1,

        /// <summary>
        /// Accounts neutral.
        /// </summary>
        AccountsNeutral = 0,

        /// <summary>
        /// Accounts receivable.
        /// </summary>
        AccountsReceivable = 1
    }
}
