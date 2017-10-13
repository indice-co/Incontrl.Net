using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Abstractions
{
    public interface IInvoiceTypesApi
    {
        string SubscriptionId { get; set; }

        /// <summary>
        /// Creates a new invoice type.
        /// </summary>
        /// <param name="invoiceType">An object of type <see cref="CreateInvoiceTypeRequest"/> that contains information about the invoice type to create.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<InvoiceType> CreateAsync(CreateInvoiceTypeRequest request, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Retrieves a list of the available invoice types.
        /// </summary>
        /// <param name="options">An object of type <see cref="ListOptions"/> that is used to paginate or filter the request.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<ResultSet<InvoiceType>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
