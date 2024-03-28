using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Abstractions
{
    public interface IDocumentTypeApi
    {
        string SubscriptionId { get; set; }
        string DocumentTypeId { get; set; }

        /// <summary>
        /// Gets an document type by it's unique id.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<DocumentType> GetAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Permanently deletes the specified document type.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task DeleteAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates the specified document type.
        /// </summary>
        /// <param name="request">An object of type <see cref="UpdateDocumentTypeRequest"/> that contains information about the document type to update.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<DocumentType> UpdateAsync(UpdateDocumentTypeRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates an object of type DocumentTypeTemplateApi, that provides functionality to download or upload the template file of the document type.
        /// </summary>
        IDocumentTypeTemplateApi Template();

        IDocumentTypePaymentOptions PaymentOptions();
        IDocumentTypePaymentOption PaymentOptions(Guid paymentOptionId);
    }
}
