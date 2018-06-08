using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Services
{
    internal class SubscriptionMetricsApi : ISubscriptionMetricsApi
    {
        private readonly ClientBase _clientBase;

        public SubscriptionMetricsApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }

        public Task<ResultSet<MetricsRecord, Metrics>> ListAsync(ListOptions<RangeFilter> options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.GetAsync<ResultSet<MetricsRecord, Metrics>>($"subscriptions/{SubscriptionId}/metrics", cancellationToken);
    }
}
