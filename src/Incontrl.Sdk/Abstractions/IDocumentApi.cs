﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;
using Incontrl.Sdk.Services;

namespace Incontrl.Sdk.Abstractions
{
    /// <summary>
    /// An interface that contains document related operations.
    /// </summary>
    public interface IDocumentApi
    {
        /// <summary>
        /// The id of the subscription.
        /// </summary>
        string SubscriptionId { get; set; }
        /// <summary>
        /// The id of the document.
        /// </summary>
        string DocumentId { get; set; }
        /// <summary>
        /// Gets an document by it's unique id.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<Document> GetAsync(CancellationToken cancellationToken = default);
        /// <summary>
        /// Updates an document.
        /// </summary>
        /// <param name="request">An object of type <see cref="UpdateDocumentRequest"/> that contains information about the document to update.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<Document> UpdateAsync(UpdateDocumentRequest request, CancellationToken cancellationToken = default);
        /// <summary>
        /// Creates an instance of type <see cref="DocumentMyDataApi"/>, that provides functionality for integrating with AADE.
        /// </summary>
        IDocumentMyDataApi MyData();
        /// <summary>
        /// Gets the document lines.
        /// </summary>
        IDocumentLinesApi Lines(Guid lineId);
        /// <summary>
        /// Permanently deletes the specified document.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task DeleteAsync(CancellationToken cancellationToken = default);
        /// <summary>
        /// Creates an instance of class DocumentDocumentApi, that provides functionality to download an document in the specified mime type.
        /// </summary>
        /// <param name="format">An enum of type <see cref="DocumentFormat"/> that describes the format of the document.</param>
        IDocumentDocumentApi As(DocumentFormat format);
        /// <summary>
        /// Creates an instance of type <see cref="DocumentStatusApi"/>, that provides functionality to retrieve or update an document's status information.
        /// </summary>
        IDocumentStatusApi Status();
        /// <summary>
        /// Creates an instance of type <see cref="DocumentTrackingsApi"/>, that provides functionality to list or create document trackers.
        /// </summary>
        IDocumentTrackingsApi Trackings();
        /// <summary>
        /// Creates an instance of type <see cref="DocumentTrackingsApi"/>, that provides functionality to update document trackers.
        /// </summary>
        /// <param name="trackingId"></param>
        IDocumentTrackingApi Trackings(string trackingId);
        /// <summary>
        /// Creates an instance of type <see cref="DocumentDocumentTypeApi"/>, that provides functionality to retrieve or update the document type of a specific document.
        /// </summary>
        IDocumentDocumentTypeApi Type();
        /// <summary>
        /// Creates an instance of type <see cref="DocumentPaymentsApi"/>, that provides functionality for document payments.
        /// </summary>
        IDocumentPaymentsApi Payments();
    }
}
