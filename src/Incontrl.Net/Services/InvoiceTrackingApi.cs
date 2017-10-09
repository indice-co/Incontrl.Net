using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Abstract;
using Incontrl.Net.Http;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Services
{
    internal class InvoiceTrackingApi : IInvoiceTrackingApi
    {
        private ClientBase _clientBase;

        public InvoiceTrackingApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }
        public string InvoiceId { get; set; }

        public async Task<JsonResponse<Tracker>> CreateAsync(CreateInvoiceTrackingRequest tracking, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.PostAsync<CreateInvoiceTrackingRequest, Tracker>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{SubscriptionId}/invoices/{InvoiceId}/trackings", tracking, cancellationToken);

        public async Task<JsonResponse<ResultSet<InvoiceTracking>>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.GetAsync<ResultSet<InvoiceTracking>>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{SubscriptionId}/invoices/{InvoiceId}/trackings", cancellationToken);
    }
}
