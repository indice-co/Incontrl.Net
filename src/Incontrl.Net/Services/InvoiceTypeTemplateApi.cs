using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Abstractions;
using Incontrl.Net.Models;

namespace Incontrl.Net.Services
{
    internal class InvoiceTypeTemplateApi : IInvoiceTypeTemplateApi
    {
        private ClientBase _clientBase;

        public InvoiceTypeTemplateApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }
        public string InvoiceTypeId { get; set; }

        public async Task<FileResult> DownloadAsync(CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.GetStreamAsync($"subscriptions/{SubscriptionId}/invoice-types/{InvoiceTypeId}/template", cancellationToken);

        public async Task UploadAsync(byte[] fileContent, string fileName, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.PostFileAsync($"subscriptions/{SubscriptionId}/invoice-types/{InvoiceTypeId}/template", fileContent, fileName, cancellationToken);
    }
}
