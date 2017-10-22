using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Abstractions;
using Incontrl.Net.Models;

namespace Incontrl.Net.Services
{
    internal class InvoiceDocumentApi : IInvoiceDocumentApi
    {
        private readonly ClientBase _clientBase;

        public InvoiceDocumentApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }
        public string InvoiceId { get; set; }
        public InvoiceFormat Format { get; set; }

        public Task<FileResult> DownloadAsync(CancellationToken cancellationToken = default(CancellationToken)) => 
            _clientBase.GetStreamAsync($"subscriptions/{SubscriptionId}/invoices/{InvoiceId}", new { format = "pdf" }, cancellationToken);
    }
}
