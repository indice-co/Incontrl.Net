using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Services
{
    internal class TaxApi : ITaxApi
    {
        private readonly ClientBase _clientBase;

        public TaxApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }
        public string TaxId { get; set; }

        public Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken)) => 
            _clientBase.DeleteAsync($"subscriptions/{SubscriptionId}/taxes/{TaxId}", cancellationToken);

        public Task<TaxDefinition> GetAsync(CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.GetAsync<TaxDefinition>($"subscriptions/{SubscriptionId}/taxes/{TaxId}", cancellationToken);

        public Task<TaxDefinition> UpdateAsync(TaxDefinition request, CancellationToken cancellationToken = default(CancellationToken)) => 
            _clientBase.PutAsync<TaxDefinition, TaxDefinition>($"subscriptions/{SubscriptionId}/taxes/{TaxId}", request, cancellationToken);
    }
}
