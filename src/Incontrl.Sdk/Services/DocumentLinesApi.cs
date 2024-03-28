using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Services
{
    class DocumentLinesApi(ClientBase clientBase) : IDocumentLinesApi
    {
        public string SubscriptionId { get; set; }
        public string DocumentId { get; set; }
        public string LineId { get; set; }

        public Task<DocumentLine> UpdateClassification(UpdateDocumentLineRequest request, CancellationToken cancellationToken = default) =>
             clientBase.PutAsync<UpdateDocumentLineRequest, DocumentLine>($"documents/{DocumentId}/lines/{LineId}/classification", request, cancellationToken);
    }
}
