using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Services
{
    internal class DocumentStatusApi(ClientBase clientBase) : IDocumentStatusApi
    {
        public string SubscriptionId { get; set; }
        public string DocumentId { get; set; }

        public Task<DocumentStatusResponse> GetAsync(CancellationToken cancellationToken = default) =>
            clientBase.GetAsync<DocumentStatusResponse>($"subscriptions/{SubscriptionId}/documents/{DocumentId}/status", cancellationToken);
        
        public Task<DocumentStatusResponse> UpdateAsync(UpdateDocumentStatusRequest request, CancellationToken cancellationToken = default) =>
            clientBase.PutAsync<UpdateDocumentStatusRequest, DocumentStatusResponse>($"subscriptions/{SubscriptionId}/documents/{DocumentId}/status", request, cancellationToken);
        
        public Task<ResultSet<DocumentStatusOption>> ListAvailableAsync(CancellationToken cancellationToken = default) =>
            clientBase.GetAsync<ResultSet<DocumentStatusOption>>($"subscriptions/{SubscriptionId}/documents/{DocumentId}/available-states", cancellationToken);
    }
}
