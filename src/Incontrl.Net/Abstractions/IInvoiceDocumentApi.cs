using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Models;

namespace Incontrl.Net.Abstractions
{
    public interface IInvoiceDocumentApi
    {
        string SubscriptionId { get; set; }
        string InvoiceId { get; set; }
        InvoiceFormat Format { get; set; }

        /// <summary>
        /// Downloads an invoice as a Stream in the specified mime type.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<FileResult> DownloadAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
