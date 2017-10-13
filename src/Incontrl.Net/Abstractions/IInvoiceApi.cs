using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Models;

namespace Incontrl.Net.Abstractions
{
    public interface IInvoiceApi
    {
        string SubscriptionId { get; set; }
        string InvoiceId { get; set; }

        /// <summary>
        /// Gets an invoice by it's unique id.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<Invoice> GetAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates an invoice.
        /// </summary>
        /// <param name="request">An object of type <see cref="UpdateInvoiceRequest"/> that contains information about the invoice to update.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<Invoice> UpdateAsync(UpdateInvoiceRequest request, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Permanently deletes the specified invoice.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Creates an instance of class InvoiceDocumentApi, that provides functionality to download an invoice in the specified mime type.
        /// </summary>
        /// <param name="format">An enum of type <see cref="InvoiceFormat"/> that describes the format of the document.</param>
        /// <returns></returns>
        IInvoiceDocumentApi As(InvoiceFormat format);

        /// <summary>
        /// Creates an instance of class InvoiceStatusApi, that provides functionality to retrieve or update an invoice's status information.
        /// </summary>
        IInvoiceStatusApi Status();

        /// <summary>
        /// Creates an instance of class InvoiceTrackingApi, that provides functionality to list or create invoice trackers.
        /// </summary>
        IInvoiceTrackingApi Trackings();

        /// <summary>
        /// Creates an instance of class InvoiceInvoiceTypeApi, that provides functionality to retrieve or update the invoice type of a specific invoice.
        /// </summary>
        IInvoiceInvoiceTypeApi Type();
    }
}
