using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Services
{
    internal class DocumentsApi : IDocumentsApi
    {
        private readonly ClientBase _clientBase;

        public DocumentsApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }

        public Task<DocumentCalculationResult> CalculateAsync(DocumentCalculationRequest request, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.PutAsync<DocumentCalculationRequest, DocumentCalculationResult>($"subscriptions/{SubscriptionId}/documents/calculate", request, cancellationToken);

        public Task<DocumentCalculationResult> CalculateAsync(Document request, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.PutAsync<Document, DocumentCalculationResult>($"subscriptions/{SubscriptionId}/documents/calculate", request, cancellationToken);

        public Task<Document> CreateAsync(CreateDocumentRequest request, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.PostAsync<CreateDocumentRequest, Document>($"subscriptions/{SubscriptionId}/documents", request, cancellationToken);

        public Task<ResultSet<Document>> ListAsync(ListOptions<DocumentListFilter> options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.GetAsync<ResultSet<Document>>($"subscriptions/{SubscriptionId}/documents", options, cancellationToken);

        public Task<ResultSet<Document, DocumentSummary>> ListAsync(ListOptions<DocumentListFilter> options = null, bool summary = false, CancellationToken cancellationToken = default(CancellationToken)) {
            if (summary) {
                var parameters = options.ToDictionary();
                parameters.Add(nameof(summary), bool.TrueString.ToLower());
                return _clientBase.GetAsync<ResultSet<Document, DocumentSummary>>($"subscriptions/{SubscriptionId}/documents", parameters, cancellationToken);
            }

            return _clientBase.GetAsync<ResultSet<Document, DocumentSummary>>($"subscriptions/{SubscriptionId}/documents", options, cancellationToken);
        }
    }
}
