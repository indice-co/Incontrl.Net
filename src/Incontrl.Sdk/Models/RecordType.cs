namespace Incontrl.Sdk.Models
{
    /// <summary>
    /// The category of Document Type.
    /// </summary>
    public enum RecordType : short
    {
        /// <summary>
        /// Accounts Payable
        /// </summary>
        AccountsPayable = -1,

        /// <summary>
        /// Accounts Neutral
        /// </summary>
        AccountsNeutral = 0,

        /// <summary>
        /// Accounts Receivable
        /// </summary>
        AccountsReceivable = 1
    }
}
