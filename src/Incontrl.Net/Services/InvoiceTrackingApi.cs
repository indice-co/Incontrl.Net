using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Abstractions;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Services
{
    internal class InvoiceTrackingApi : IInvoiceTrackingApi
    {
        private readonly ClientBase _clientBase;

        public InvoiceTrackingApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }
        public string InvoiceId { get; set; }

        public Task<Tracker> CreateAsync(CreateInvoiceTrackingRequest request, CancellationToken cancellationToken = default(CancellationToken)) => 
            _clientBase.PostAsync<CreateInvoiceTrackingRequest, Tracker>($"subscriptions/{SubscriptionId}/invoices/{InvoiceId}/trackings", request, cancellationToken);

        public Task<ResultSet<InvoiceTracking>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.GetAsync<ResultSet<InvoiceTracking>>($"subscriptions/{SubscriptionId}/invoices/{InvoiceId}/trackings", cancellationToken);
    }
}
