using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Models;

namespace Incontrl.Net.Abstractions
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBankAccountTransactionApi
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
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<BankTransaction> GetAsync(CancellationToken cancellationToken = default(CancellationToken));

        IPaymentsApi Payments();
    }
}
