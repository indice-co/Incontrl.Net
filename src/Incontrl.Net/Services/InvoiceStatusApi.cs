using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Abstractions;
using Incontrl.Net.Models;

namespace Incontrl.Net.Services
{
    internal class InvoiceStatusApi : IInvoiceStatusApi
    {
        private readonly ClientBase _clientBase;

        public InvoiceStatusApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }
        public string InvoiceId { get; set; }

        public async Task<InvoiceStatus> GetAsync(CancellationToken cancellationToken = default(CancellationToken)) => 
            (await _clientBase.GetAsync<InvoiceStatusResponse>($"subscriptions/{SubscriptionId}/invoices/{InvoiceId}/status", cancellationToken)).Status;

        public async Task<InvoiceStatus> UpdateAsync(InvoiceStatus request, CancellationToken cancellationToken = default(CancellationToken)) =>
            (await _clientBase.PutAsync<UpdateInvoiceStatusRequest, InvoiceStatusResponse>($"subscriptions/{SubscriptionId}/invoices/{InvoiceId}/status", new UpdateInvoiceStatusRequest { Status = request }, cancellationToken)).Status;
    }
}
