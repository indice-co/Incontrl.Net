using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Services
{
    internal class DocumentTrackingsApi(ClientBase clientBase) : IDocumentTrackingsApi
    {
        public string SubscriptionId { get; set; }
        public string DocumentId { get; set; }

        public Task<Tracker> CreateAsync(CreateDocumentTrackingRequest request, CancellationToken cancellationToken = default) => 
            clientBase.PostAsync<CreateDocumentTrackingRequest, Tracker>($"subscriptions/{SubscriptionId}/documents/{DocumentId}/trackings", request, cancellationToken);

        public Task<ResultSet<DocumentTracking>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default) =>
            clientBase.GetAsync<ResultSet<DocumentTracking>>($"subscriptions/{SubscriptionId}/documents/{DocumentId}/trackings", cancellationToken);
    }
}
