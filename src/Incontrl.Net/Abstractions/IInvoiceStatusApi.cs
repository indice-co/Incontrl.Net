using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Models;

namespace Incontrl.Net.Abstractions
{
    public interface IInvoiceStatusApi
    {
        string SubscriptionId { get; set; }
        string InvoiceId { get; set; }

        /// <summary>
        /// Gets status information about an invoice.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<InvoiceStatus> GetAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates the status of a specific invoice.
        /// </summary>
        /// <param name="request">An enum of type <see cref="InvoiceStatus"/> that describes the status of an invoice.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<InvoiceStatus> UpdateAsync(InvoiceStatus request, CancellationToken cancellationToken = default(CancellationToken));
    }
}
