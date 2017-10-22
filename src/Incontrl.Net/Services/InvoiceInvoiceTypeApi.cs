using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Abstractions;
using Incontrl.Net.Models;

namespace Incontrl.Net.Services
{
    internal class InvoiceInvoiceTypeApi : IInvoiceInvoiceTypeApi
    {
        private readonly ClientBase _clientBase;

        public InvoiceInvoiceTypeApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }
        public string InvoiceId { get; set; }

        public Task<InvoiceType> GetAsync(CancellationToken cancellationToken = default(CancellationToken)) => 
            _clientBase.GetAsync<InvoiceType>($"subscriptions/{SubscriptionId}/invoices/{InvoiceId}/type", cancellationToken);

        public Task<InvoiceType> UpdateAsync(UpdateInvoiceTypeRequest request, CancellationToken cancellationToken = default(CancellationToken)) => 
            _clientBase.PutAsync<UpdateInvoiceTypeRequest, InvoiceType>($"subscriptions/{SubscriptionId}/invoices/{InvoiceId}/type", request, cancellationToken);
    }
}
