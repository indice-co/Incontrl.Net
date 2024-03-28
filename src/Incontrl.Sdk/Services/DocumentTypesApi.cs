using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Services
{
    internal class DocumentTypesApi(ClientBase clientBase) : IDocumentTypesApi
    {
        public string SubscriptionId { get; set; }

        public Task<DocumentType> CreateAsync(CreateDocumentTypeRequest request, CancellationToken cancellationToken = default) => 
            clientBase.PostAsync<CreateDocumentTypeRequest, DocumentType>($"subscriptions/{SubscriptionId}/document-types", request, cancellationToken);

        public Task<ResultSet<DocumentType>> ListAsync(ListOptions<DocumentTypeFilter> options = null, CancellationToken cancellationToken = default) => 
            clientBase.GetAsync<ResultSet<DocumentType>>($"subscriptions/{SubscriptionId}/document-types", options, cancellationToken);
    }
}
