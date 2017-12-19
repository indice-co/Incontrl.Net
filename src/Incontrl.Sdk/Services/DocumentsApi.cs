using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Incontrl.Sdk.Types;

namespace Incontrl.Sdk.Services
{
    internal class DocumentsApi : IDocumentsApi
    {
        private readonly ClientBase _clientBase;

        public DocumentsApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }

        public Task<Document> CreateAsync(CreateDocumentRequest request, CancellationToken cancellationToken = default(CancellationToken)) => 
            _clientBase.PostAsync<CreateDocumentRequest, Document>($"{_clientBase.ApiAddress}subscriptions/{SubscriptionId}/documents", request, cancellationToken);

        public Task<ResultSet<Document>> ListAsync(ListOptions<DocumentListFilter> options = null, CancellationToken cancellationToken = default(CancellationToken)) => 
            _clientBase.GetAsync<ResultSet<Document>>($"{_clientBase.ApiAddress}subscriptions/{SubscriptionId}/documents", options, cancellationToken);

        public Task<ResultSet<Document, DocumentSummary>> ListAsync(ListOptions<DocumentListFilter> options = null, bool summary = false, CancellationToken cancellationToken = default(CancellationToken)) {
            if (summary) {
                return _clientBase.GetAsync<ResultSet<Document, DocumentSummary>>($"{_clientBase.ApiAddress}subscriptions/{SubscriptionId}/documents", new { options, summary }, cancellationToken);
            }

            return _clientBase.GetAsync<ResultSet<Document, DocumentSummary>>($"{_clientBase.ApiAddress}subscriptions/{SubscriptionId}/documents", options, cancellationToken);
        }
    }
}
