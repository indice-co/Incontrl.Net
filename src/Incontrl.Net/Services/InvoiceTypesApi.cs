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

        public async Task<SubscriptionInvoiceType> CreateAsync(CreateInvoiceTypeRequest invoiceType, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.PostAsync<CreateInvoiceTypeRequest, SubscriptionInvoiceType>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{SubscriptionId}/invoice-types", invoiceType, cancellationToken);

        public async Task<ResultSet<SubscriptionInvoiceType>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.GetAsync<ResultSet<SubscriptionInvoiceType>>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{SubscriptionId}/invoice-types", options, cancellationToken);
    }
}
