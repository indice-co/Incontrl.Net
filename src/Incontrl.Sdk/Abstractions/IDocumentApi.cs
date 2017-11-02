﻿using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Abstractions
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDocumentApi
    {
        /// <summary>
        /// 
        /// </summary>
        string SubscriptionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string DocumentId { get; set; }

        /// <summary>
        /// Gets an document by it's unique id.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<Document> GetAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates an document.
        /// </summary>
        /// <param name="request">An object of type <see cref="UpdateDocumentRequest"/> that contains information about the document to update.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<Document> UpdateAsync(UpdateDocumentRequest request, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Permanently deletes the specified document.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Creates an instance of class DocumentDocumentApi, that provides functionality to download an document in the specified mime type.
        /// </summary>
        /// <param name="format">An enum of type <see cref="DocumentFormat"/> that describes the format of the document.</param>
        /// <returns></returns>
        IDocumentDocumentApi As(DocumentFormat format);

        /// <summary>
        /// Creates an instance of class DocumentStatusApi, that provides functionality to retrieve or update an document's status information.
        /// </summary>
        IDocumentStatusApi Status();

        /// <summary>
        /// Creates an instance of class DocumentTrackingApi, that provides functionality to list or create document trackers.
        /// </summary>
        IDocumentTrackingApi Trackings();

        /// <summary>
        /// Creates an instance of class DocumentDocumentTypeApi, that provides functionality to retrieve or update the document type of a specific document.
        /// </summary>
        IDocumentDocumentTypeApi Type();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IDocumentPaymentsApi Payments();
    }
}