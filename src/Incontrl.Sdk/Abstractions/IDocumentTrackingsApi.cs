using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;
using Incontrl.Sdk.Types;

namespace Incontrl.Sdk.Abstractions
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDocumentTrackingsApi
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
        /// Retrieves a list of the document trackers that have been generated.
        /// </summary>
        /// <param name="options">An object of type <see cref="ListOptions"/> that is used to paginate or filter the request.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<ResultSet<DocumentTracking>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Creates a new document tracker for the specified document.
        /// </summary>
        /// <param name="request">An object of type <see cref="CreateDocumentTrackingRequest"/> that contains information about the document tracker to generate.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<Tracker> CreateAsync(CreateDocumentTrackingRequest request, CancellationToken cancellationToken = default(CancellationToken));
    }
}
