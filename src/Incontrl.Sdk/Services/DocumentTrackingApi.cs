using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Services
{
    internal class DocumentTrackingApi(ClientBase clientBase) : IDocumentTrackingApi
    {
        public string SubscriptionId { get; set; }
        public string DocumentId { get; set; }
        public string TrackingId { get; set; }

        public Task<DocumentTracking> UpdateAsync(UpdateDocumentTrackingRequest request, CancellationToken cancellationToken = default) =>
            clientBase.PutAsync<UpdateDocumentTrackingRequest, DocumentTracking>($"subscriptions/{SubscriptionId}/documents/{DocumentId}/trackings/{TrackingId}", request, cancellationToken);
    }
}
