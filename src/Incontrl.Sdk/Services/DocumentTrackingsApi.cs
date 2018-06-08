using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Services
{
    internal class DocumentTrackingsApi : IDocumentTrackingsApi
    {
        private readonly ClientBase _clientBase;

        public DocumentTrackingsApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }
        public string DocumentId { get; set; }

        public Task<Tracker> CreateAsync(CreateDocumentTrackingRequest request, CancellationToken cancellationToken = default(CancellationToken)) => 
            _clientBase.PostAsync<CreateDocumentTrackingRequest, Tracker>($"subscriptions/{SubscriptionId}/documents/{DocumentId}/trackings", request, cancellationToken);

        public Task<ResultSet<DocumentTracking>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.GetAsync<ResultSet<DocumentTracking>>($"subscriptions/{SubscriptionId}/documents/{DocumentId}/trackings", cancellationToken);
    }
}
