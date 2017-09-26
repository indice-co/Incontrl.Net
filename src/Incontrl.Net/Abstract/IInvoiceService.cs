using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Http;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Abstract
{
    public interface IInvoiceService
    {
        /// <summary>
        /// Gets a list of the invoices that are associated with a subscription.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="options"></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<JsonResponse<ResultSet<Invoice>>> GetAsync(Guid subscriptionId, ListOptions<InvoiceListFilter> options = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets a specific invoice for a specified subscription.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="invoiceId">The unique id of the invoice.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<JsonResponse<Invoice>> GetByIdAsync(Guid subscriptionId, Guid invoiceId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <param name="invoiceId"></param>
        /// <param name="format"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<FileResult> GetByIdAsync(Guid subscriptionId, Guid invoiceId, InvoiceFormat format, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the status of a specific invoice.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="invoiceId">The unique id of the invoice.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<JsonResponse<InvoiceStatus>> GetStatusAsync(Guid subscriptionId, Guid invoiceId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets type information for a specified invoice.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="invoiceId">The unique id of the invoice.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<JsonResponse<InvoiceType>> GetTypeAsync(Guid subscriptionId, Guid invoiceId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Creates a new invoice for a specified subscription.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="invoice">An object of type <see cref="CreateInvoiceRequest"/> that contains information about the newly created invoice.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<JsonResponse<Invoice>> CreateAsync(Guid subscriptionId, CreateInvoiceRequest invoice, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates a specified invoice.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="invoiceId">The unique id of the invoice.</param>
        /// <param name="invoice">An object of type <see cref="UpdateInvoiceRequest"/> that contains information about the invoice to be updated.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<JsonResponse<Invoice>> UpdateAsync(Guid subscriptionId, Guid invoiceId, UpdateInvoiceRequest invoice, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Changes the status of a specified invoice.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="invoiceId">The unique id of the invoice.</param>
        /// <param name="status">An object of type <see cref="UpdateInvoiceStatusRequest"/> that contains information about the status of the invoice to be updated.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<JsonResponse<InvoiceStatus>> UpdateStatusAsync(Guid subscriptionId, Guid invoiceId, UpdateInvoiceStatusRequest status, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates the type of a specified invoice.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="invoiceId">The unique id of the invoice.</param>
        /// <param name="type">An object of type <see cref="UpdateInvoiceTypeRequest"/> that contains information about the status of the invoice to be updated.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<JsonResponse<InvoiceType>> UpdateTypeAsync(Guid subscriptionId, Guid invoiceId, UpdateInvoiceTypeRequest type, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes the specified invoice.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="invoiceId">The unique id of the invoice.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task DeleteAsync(Guid subscriptionId, Guid invoiceId, CancellationToken cancellationToken = default(CancellationToken));
    }
}
