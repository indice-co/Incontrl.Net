using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Abstractions;
using Incontrl.Net.Http;
using Incontrl.Net.Models;

namespace Incontrl.Net.Services
{
    internal class InvoiceStatusApi : IInvoiceStatusApi
    {
        private ClientBase _clientBase;

        public InvoiceStatusApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }
        public string InvoiceId { get; set; }

        public async Task<InvoiceStatus> GetAsync(CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.GetAsync<InvoiceStatus>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{SubscriptionId}/invoices/{InvoiceId}/status", cancellationToken);

        public async Task<InvoiceStatus> UpdateAsync(UpdateInvoiceStatusRequest status, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.PutAsync<UpdateInvoiceStatusRequest, InvoiceStatus>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{SubscriptionId}/invoices/{InvoiceId}/status", status, cancellationToken);
    }
}
