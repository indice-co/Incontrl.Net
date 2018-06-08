using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Services
{
    internal class TaxesApi : ITaxesApi
    {
        private readonly ClientBase _clientBase;

        public TaxesApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }

        public Task<TaxDefinition> CreateAsync(TaxDefinition request, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.PostAsync<TaxDefinition, TaxDefinition>($"subscriptions/{SubscriptionId}/taxes", request, cancellationToken);

        public Task<ResultSet<TaxDefinition>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken)) => 
            _clientBase.GetAsync<ResultSet<TaxDefinition>>($"subscriptions/{SubscriptionId}/taxes", options, cancellationToken);
    }
}
