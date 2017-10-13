using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Abstractions
{
    public interface IInvoiceTrackingApi
    {
        string SubscriptionId { get; set; }
        string InvoiceId { get; set; }

        /// <summary>
        /// Retrieves a list of the invoice trackers that have been generated.
        /// </summary>
        /// <param name="options">An object of type <see cref="ListOptions"/> that is used to paginate or filter the request.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<ResultSet<InvoiceTracking>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Creates a new invoice tracker for the specified invoice.
        /// </summary>
        /// <param name="tracking">An object of type <see cref="CreateInvoiceTrackingRequest"/> that contains information about the invoice tracker to generate.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<Tracker> CreateAsync(CreateInvoiceTrackingRequest request, CancellationToken cancellationToken = default(CancellationToken));
    }
}
