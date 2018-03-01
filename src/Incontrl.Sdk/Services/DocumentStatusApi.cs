using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Services
{
    internal class DocumentStatusApi : IDocumentStatusApi
    {
        private readonly ClientBase _clientBase;

        public DocumentStatusApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }
        public string DocumentId { get; set; }

        public Task<DocumentStatusResponse> GetAsync(CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.GetAsync<DocumentStatusResponse>($"subscriptions/{SubscriptionId}/documents/{DocumentId}/status", cancellationToken);

        public Task<DocumentStatusResponse> UpdateAsync(UpdateDocumentStatusRequest request, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.PutAsync<UpdateDocumentStatusRequest, DocumentStatusResponse>($"subscriptions/{SubscriptionId}/documents/{DocumentId}/status", request, cancellationToken);
    }
}
