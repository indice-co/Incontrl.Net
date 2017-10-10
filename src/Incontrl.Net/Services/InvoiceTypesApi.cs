using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Abstractions;
using Incontrl.Net.Http;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Services
{
    internal class InvoiceTypesApi : IInvoiceTypesApi
    {
        private ClientBase _clientBase;

        public InvoiceTypesApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }

        public async Task<InvoiceType> CreateAsync(CreateInvoiceTypeRequest request, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.PostAsync<CreateInvoiceTypeRequest, InvoiceType>($"subscriptions/{SubscriptionId}/invoice-types", request, cancellationToken);

        public async Task<ResultSet<InvoiceType>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.GetAsync<ResultSet<InvoiceType>>($"subscriptions/{SubscriptionId}/invoice-types", options, cancellationToken);
    }
}
