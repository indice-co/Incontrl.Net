using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Services
{
    internal class TaxesApi(ClientBase clientBase) : ITaxesApi
    {
        public string SubscriptionId { get; set; }

        public Task<TaxDefinition> CreateAsync(TaxDefinition request, CancellationToken cancellationToken = default) =>
            clientBase.PostAsync<TaxDefinition, TaxDefinition>($"subscriptions/{SubscriptionId}/taxes", request, cancellationToken);

        public Task<ResultSet<TaxDefinition>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default) => 
            clientBase.GetAsync<ResultSet<TaxDefinition>>($"subscriptions/{SubscriptionId}/taxes", options, cancellationToken);
    }
}
