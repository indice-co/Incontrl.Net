using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Http;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Abstract
{
    public interface IInvoiceTypeService
    {
        /// <summary>
        /// Gets the invoice types for a specified subscription.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="options"></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<JsonResponse<ResultSet<SubscriptionInvoiceType>>> GetAsync(Guid subscriptionId, ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets a specific invoice type by using it's id.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="invoiceTypeId">The unique id of the invoice type.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<JsonResponse<SubscriptionInvoiceType>> GetByIdAsync(Guid subscriptionId, Guid invoiceTypeId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <param name="invoiceTypeId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<FileResult> GetTemplateAsync(Guid subscriptionId, Guid invoiceTypeId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Creates a new invoice type for the specified subscription.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="invoiceType">An object of type <see cref="CreateInvoiceTypeRequest"/> that contains information about the newly created invoice type.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<JsonResponse<SubscriptionInvoiceType>> CreateAsync(Guid subscriptionId, CreateInvoiceTypeRequest invoiceType, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <param name="invoiceTypeId"></param>
        /// <param name="fileContent"></param>
        /// <param name="fileName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task UpdateTemplateAsync(Guid subscriptionId, Guid invoiceTypeId, byte[] fileContent, string fileName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates a specific invoice type by it's id.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="invoiceTypeId">The unique id of the invoice type.</param>
        /// <param name="invoiceType"></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<JsonResponse<Invoice>> UpdateAsync(Guid subscriptionId, Guid invoiceTypeId, UpdateSubscriptionInvoiceTypeRequest invoiceType, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes a specific invoice type by it's id.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="invoiceTypeId">The unique id of the invoice type.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task DeleteAsync(Guid subscriptionId, Guid invoiceTypeId, CancellationToken cancellationToken = default(CancellationToken));
    }
}
