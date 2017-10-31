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

        public async Task<DocumentStatus> GetAsync(CancellationToken cancellationToken = default(CancellationToken)) => 
            (await _clientBase.GetAsync<DocumentStatusResponse>($"subscriptions/{SubscriptionId}/documents/{DocumentId}/status", cancellationToken)).Status;

        public async Task<DocumentStatus> UpdateAsync(DocumentStatus request, CancellationToken cancellationToken = default(CancellationToken)) =>
            (await _clientBase.PutAsync<UpdateDocumentStatusRequest, DocumentStatusResponse>($"subscriptions/{SubscriptionId}/documents/{DocumentId}/status", new UpdateDocumentStatusRequest { Status = request }, cancellationToken)).Status;
    }
}
