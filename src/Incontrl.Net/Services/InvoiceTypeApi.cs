using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Experimental;
using Incontrl.Net.Http;
using Incontrl.Net.Models;

namespace Incontrl.Net.Services
{
    internal class InvoiceTypeApi : IInvoiceTypeApi
    {
        private ClientBase _clientBase;

        public InvoiceTypeApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }
        public string InvoiceId { get; set; }

        public async Task<JsonResponse<InvoiceType>> GetAsync(CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.GetAsync<InvoiceType>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{SubscriptionId}/invoices/{InvoiceId}/type", cancellationToken);

        public async Task<JsonResponse<InvoiceType>> UpdateAsync(UpdateInvoiceTypeRequest type, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.PutAsync<UpdateInvoiceTypeRequest, InvoiceType>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{SubscriptionId}/invoices/{InvoiceId}/type", type, cancellationToken);
    }
}
