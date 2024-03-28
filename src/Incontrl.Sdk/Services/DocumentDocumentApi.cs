using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Services
{
    internal class DocumentDocumentApi(ClientBase clientBase) : IDocumentDocumentApi
    {
        public string SubscriptionId { get; set; }
        public string DocumentId { get; set; }
        public DocumentFormat Format { get; set; }

        public Task<FileResult> DownloadAsync(CancellationToken cancellationToken = default) => 
            clientBase.GetStreamAsync($"subscriptions/{SubscriptionId}/documents/{DocumentId}", new { format = "pdf" }, cancellationToken);
    }
}
