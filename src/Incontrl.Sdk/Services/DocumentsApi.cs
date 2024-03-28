using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Services
{
    internal class DocumentsApi(ClientBase clientBase) : IDocumentsApi
    {
        public string SubscriptionId { get; set; }

        public Task<DocumentCalculationResult> CalculateAsync(DocumentCalculationRequest request, CancellationToken cancellationToken = default) =>
            clientBase.PutAsync<DocumentCalculationRequest, DocumentCalculationResult>($"subscriptions/{SubscriptionId}/documents/calculate", request, cancellationToken);

        public Task<DocumentCalculationResult> CalculateAsync(Document request, CancellationToken cancellationToken = default) =>
            clientBase.PutAsync<Document, DocumentCalculationResult>($"subscriptions/{SubscriptionId}/documents/calculate", request, cancellationToken);

        public Task<Document> CreateAsync(CreateDocumentRequest request, CancellationToken cancellationToken = default) =>
            clientBase.PostAsync<CreateDocumentRequest, Document>($"subscriptions/{SubscriptionId}/documents", request, cancellationToken);

        public Task<ResultSet<Document>> ListAsync(ListOptions<DocumentListFilter> options = null, CancellationToken cancellationToken = default) =>
            clientBase.GetAsync<ResultSet<Document>>($"subscriptions/{SubscriptionId}/documents", options, cancellationToken);

        public Task<ResultSet<Document, DocumentSummary>> ListAsync(ListOptions<DocumentListFilter> options = null, bool summary = false, CancellationToken cancellationToken = default) {
            if (summary) {
                var parameters = options.ToDictionary();
                parameters.Add(nameof(summary), bool.TrueString.ToLower());
                return clientBase.GetAsync<ResultSet<Document, DocumentSummary>>($"subscriptions/{SubscriptionId}/documents", parameters, cancellationToken);
            }
            return clientBase.GetAsync<ResultSet<Document, DocumentSummary>>($"subscriptions/{SubscriptionId}/documents", options, cancellationToken);
        }
    }
}
