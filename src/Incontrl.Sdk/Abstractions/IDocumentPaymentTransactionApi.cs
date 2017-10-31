using System.Threading;
using System.Threading.Tasks;

namespace Incontrl.Sdk.Abstractions
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDocumentPaymentTransactionApi
    {
        /// <summary>
        /// 
        /// </summary>
        string SubscriptionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string DocumentId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string TransactionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IDocumentPaymentTransactionApprovalApi Approval();
    }
}
