using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Services
{
    internal class DocumentTypeTemplateApi : IDocumentTypeTemplateApi
    {
        private readonly ClientBase _clientBase;

        public DocumentTypeTemplateApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }
        public string DocumentTypeId { get; set; }

        public Task<FileResult> DownloadAsync(CancellationToken cancellationToken = default(CancellationToken)) => 
            _clientBase.GetStreamAsync($"subscriptions/{SubscriptionId}/document-types/{DocumentTypeId}/template", cancellationToken);

        public Task UploadAsync(byte[] fileContent, string fileName, CancellationToken cancellationToken = default(CancellationToken)) => 
            _clientBase.PostFileAsync($"subscriptions/{SubscriptionId}/document-types/{DocumentTypeId}/template", fileContent, fileName, cancellationToken);
    }
}
