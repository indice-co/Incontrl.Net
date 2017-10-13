using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Abstractions
{
    public interface IInvoicesApi
    {
        string SubscriptionId { get; set; }

        /// <summary>
        /// Retrieves a list of all the invoices that have been created for a specific subscription.
        /// </summary>
        /// <param name="options">An object of type <see cref="ListOptions{InvoiceListFilter}"/> that is used to paginate or filter the request.</param>
        /// <param name="cancellationToken">Returns the task object representing the asynchronous operation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<ResultSet<Invoice>> ListAsync(ListOptions<InvoiceListFilter> options = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Creates a new invoice.
        /// </summary>
        /// <param name="request">An object of type <see cref="CreateInvoiceRequest"/> that contains information about the invoice to create.</param>
        /// <param name="cancellationToken">Returns the task object representing the asynchronous operation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<Invoice> CreateAsync(CreateInvoiceRequest request, CancellationToken cancellationToken = default(CancellationToken));
    }
}
