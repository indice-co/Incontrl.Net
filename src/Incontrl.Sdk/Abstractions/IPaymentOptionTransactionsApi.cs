using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;
using Incontrl.Sdk.Types;

namespace Incontrl.Sdk.Abstractions
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPaymentOptionTransactionsApi
    {
        /// <summary>
        /// 
        /// </summary>
        string SubscriptionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string PaymentOptionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Transaction> CreateAsync(Transaction request, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task BulkCreateAsync(BulkLoadTransactionsRequest request, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ResultSet<Transaction>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
