using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Abstractions;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Services
{
    internal class InvoiceTypesApi : IInvoiceTypesApi
    {
        private readonly ClientBase _clientBase;

        public InvoiceTypesApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }

        public Task<InvoiceType> CreateAsync(CreateInvoiceTypeRequest request, CancellationToken cancellationToken = default(CancellationToken)) => 
            _clientBase.PostAsync<CreateInvoiceTypeRequest, InvoiceType>($"subscriptions/{SubscriptionId}/invoice-types", request, cancellationToken);

        public Task<ResultSet<InvoiceType>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken)) => 
            _clientBase.GetAsync<ResultSet<InvoiceType>>($"subscriptions/{SubscriptionId}/invoice-types", options, cancellationToken);
    }
}
