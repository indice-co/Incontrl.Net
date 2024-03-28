using System.Threading;
using System.Threading.Tasks;

namespace Incontrl.Sdk.Models
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDocumentTypePaymentOption
    {
        /// <summary>
        /// 
        /// </summary>
        string SubscriptionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string DocumentTypeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string PaymentOptionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task DeleteAsync(CancellationToken cancellationToken = default);
    }
}
