using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Abstractions
{
    public interface IDocumentTrackingApi
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
        /// The id of the tracking.
        /// </summary>
        string TrackingId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<DocumentTracking> UpdateAsync(UpdateDocumentTrackingRequest request, CancellationToken cancellationToken = default);
    }
}
