using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Abstractions
{
    /// <summary>
    /// An interface that contains operations related to document status.
    /// </summary>
    public interface IDocumentStatusApi
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
        /// Gets status information about a document.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<DocumentStatusResponse> GetAsync(CancellationToken cancellationToken = default);
        /// <summary>
        /// Updates the status of a specific document.
        /// </summary>
        /// <param name="request">An object of type <see cref="UpdateDocumentStatusRequest"/> that describes the status of a document.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<DocumentStatusResponse> UpdateAsync(UpdateDocumentStatusRequest request, CancellationToken cancellationToken = default);
        /// <summary>
        /// Gets list of available status options based on the current document and its status.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<ResultSet<DocumentStatusOption>> ListAvailableAsync(CancellationToken cancellationToken = default);
    }
}
