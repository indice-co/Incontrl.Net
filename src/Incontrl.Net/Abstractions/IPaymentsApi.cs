using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Abstractions
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPaymentsApi
    {
        /// <summary>
        /// 
        /// </summary>
        string SubscriptionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string BankAccountId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string BankTransactionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ResultSet<Payment>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Payment> CreateAsync(Payment request, CancellationToken cancellationToken = default(CancellationToken));
    }
}
