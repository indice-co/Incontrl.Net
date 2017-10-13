using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Models;

namespace Incontrl.Net.Abstractions
{
    public interface IInvoiceInvoiceTypeApi
    {
        string SubscriptionId { get; set; }
        string InvoiceId { get; set; }

        /// <summary>
        /// Gets the invoice type of the specified invoice.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<InvoiceType> GetAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates the invoice type of the specified invoice.
        /// </summary>
        /// <param name="request">An object of type <see cref="UpdateInvoiceTypeRequest"/> that contains information about the invoice type of the invoice that is to be updated.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<InvoiceType> UpdateAsync(UpdateInvoiceTypeRequest request, CancellationToken cancellationToken = default(CancellationToken));
    }
}
