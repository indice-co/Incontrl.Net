using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Services
{
    internal class DocumentDocumentTypeApi : IDocumentDocumentTypeApi
    {
        private readonly ClientBase _clientBase;

        public DocumentDocumentTypeApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }
        public string DocumentId { get; set; }

        public Task<DocumentType> GetAsync(CancellationToken cancellationToken = default(CancellationToken)) => 
            _clientBase.GetAsync<DocumentType>($"subscriptions/{SubscriptionId}/documents/{DocumentId}/type", cancellationToken);

        public Task<DocumentType> UpdateAsync(UpdateDocumentDocumentType request, CancellationToken cancellationToken = default(CancellationToken)) => 
            _clientBase.PutAsync<UpdateDocumentDocumentType, DocumentType>($"subscriptions/{SubscriptionId}/documents/{DocumentId}/type", request, cancellationToken);
    }
}
