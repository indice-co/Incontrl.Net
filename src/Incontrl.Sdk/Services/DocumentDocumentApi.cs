using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Services
{
    internal class DocumentDocumentApi : IDocumentDocumentApi
    {
        private readonly ClientBase _clientBase;

        public DocumentDocumentApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }
        public string DocumentId { get; set; }
        public DocumentFormat Format { get; set; }

        public Task<FileResult> DownloadAsync(CancellationToken cancellationToken = default(CancellationToken)) => 
            _clientBase.GetStreamAsync($"{_clientBase.ApiAddress}subscriptions/{SubscriptionId}/documents/{DocumentId}", new { format = "pdf" }, cancellationToken);
    }
}
