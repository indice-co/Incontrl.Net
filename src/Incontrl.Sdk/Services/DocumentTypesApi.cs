using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Incontrl.Sdk.Types;

namespace Incontrl.Sdk.Services
{
    internal class DocumentTypesApi : IDocumentTypesApi
    {
        private readonly ClientBase _clientBase;

        public DocumentTypesApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }

        public Task<DocumentType> CreateAsync(CreateDocumentTypeRequest request, CancellationToken cancellationToken = default(CancellationToken)) => 
            _clientBase.PostAsync<CreateDocumentTypeRequest, DocumentType>($"{_clientBase.ApiAddress}/subscriptions/{SubscriptionId}/document-types", request, cancellationToken);

        public Task<ResultSet<DocumentType>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken)) => 
            _clientBase.GetAsync<ResultSet<DocumentType>>($"{_clientBase.ApiAddress}/subscriptions/{SubscriptionId}/document-types", options, cancellationToken);
    }
}
