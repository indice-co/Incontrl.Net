using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Services
{
    internal class DocumentTypeTemplateApi(ClientBase clientBase) : IDocumentTypeTemplateApi
    {
        public string SubscriptionId { get; set; }
        public string DocumentTypeId { get; set; }

        public Task<FileResult> DownloadAsync(CancellationToken cancellationToken = default) => 
            clientBase.GetStreamAsync($"subscriptions/{SubscriptionId}/document-types/{DocumentTypeId}/template", cancellationToken);

        public Task UploadAsync(Stream fileContent, string fileName, CancellationToken cancellationToken = default) => 
            clientBase.PostFileAsync($"subscriptions/{SubscriptionId}/document-types/{DocumentTypeId}/template", fileContent, fileName, cancellationToken);
    }
}
