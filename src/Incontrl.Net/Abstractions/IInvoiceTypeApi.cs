using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Models;

namespace Incontrl.Net.Abstractions
{
    public interface IInvoiceTypeApi
    {
        string SubscriptionId { get; set; }
        string InvoiceTypeId { get; set; }

        /// <summary>
        /// Gets an invoice type by it's unique id.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<InvoiceType> GetAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Permanently deletes the specified invoice type.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates the specified invoice type.
        /// </summary>
        /// <param name="request">An object of type <see cref="UpdateInvoiceTypeRequest"/> that contains information about the invoice type to update.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<InvoiceType> UpdateAsync(UpdateInvoiceTypeRequest request, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Creates an object of type InvoiceTypeTemplateApi, that provides functionality to download or upload the template file of the invoice type.
        /// </summary>
        IInvoiceTypeTemplateApi Template();
    }
}
