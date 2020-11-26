using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Services
{
    class DocumentLinesApi : IDocumentLinesApi
    {
        private readonly ClientBase _clientBase;

        public DocumentLinesApi(ClientBase clientBase) {
            _clientBase = clientBase;
        }

        public string SubscriptionId { get; set; }
        public string DocumentId { get; set; }
        public string LineId { get; set; }

        public Task<DocumentLine> UpdateClassification(UpdateDocumentLineRequest request, CancellationToken cancellationToken = default) =>
             _clientBase.PutAsync<UpdateDocumentLineRequest, DocumentLine>($"documents/{DocumentId}/lines/{LineId}/classification", request, cancellationToken);
    }
}
