using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Abstract;
using Incontrl.Net.Models;

namespace Incontrl.Net.Services
{
    internal class InvoiceDocumentApi : IInvoiceDocumentApi
    {
        private ClientBase _clientBase;

        public InvoiceDocumentApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }
        public string InvoiceId { get; set; }
        public InvoiceFormat Format { get; set; }

        public async Task<FileResult> DownloadAsync(CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.GetStreamAsync($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{SubscriptionId}/invoices/{InvoiceId}", new { format = "pdf" }, cancellationToken);
    }
}
