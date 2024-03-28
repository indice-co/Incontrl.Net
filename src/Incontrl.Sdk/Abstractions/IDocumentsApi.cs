﻿using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Abstractions
{
    public interface IDocumentsApi
    {
        string SubscriptionId { get; set; }

        /// <summary>
        /// Retrieves a list of all the documents that have been created for a specific subscription.
        /// </summary>
        /// <param name="options">An object of type <see cref="ListOptions{DocumentListFilter}"/> that is used to paginate or filter the request.</param>
        /// <param name="summary">Specify whether to include a summary for the chosen documnets.</param>
        /// <param name="cancellationToken">Returns the task object representing the asynchronous operation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<ResultSet<Document, DocumentSummary>> ListAsync(ListOptions<DocumentListFilter> options = null, bool summary = false, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a new document.
        /// </summary>
        /// <param name="request">An object of type <see cref="CreateDocumentRequest"/> that contains information about the document to create.</param>
        /// <param name="cancellationToken">Returns the task object representing the asynchronous operation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<Document> CreateAsync(CreateDocumentRequest request, CancellationToken cancellationToken = default);

        Task<DocumentCalculationResult> CalculateAsync(DocumentCalculationRequest request, CancellationToken cancellationToken = default);
        Task<DocumentCalculationResult> CalculateAsync(Document request, CancellationToken cancellationToken = default);
    }
}
