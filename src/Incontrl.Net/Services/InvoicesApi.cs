using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Abstractions;
using Incontrl.Net.Http;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Services
{
    internal class InvoicesApi : IInvoicesApi
    {
        private ClientBase _clientBase;

        public InvoicesApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }

        public async Task<Invoice> CreateAsync(CreateInvoiceRequest invoice, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.PostAsync<CreateInvoiceRequest, Invoice>($"subscriptions/{SubscriptionId}/invoices", invoice, cancellationToken);

        public async Task<ResultSet<Invoice>> ListAsync(ListOptions<InvoiceListFilter> options = null, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.GetAsync<ResultSet<Invoice>>($"subscriptions/{SubscriptionId}/invoices", options, cancellationToken);
    }
}
