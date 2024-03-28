using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Services
{
    internal class MetricsApi(ClientBase clientBase) : IMetricsApi
    {
        public Task<ResultSet<MetricsRecord, Metrics>> ListAsync(ListOptions<RangeFilter> options = null, CancellationToken cancellationToken = default) =>
            clientBase.GetAsync<ResultSet<MetricsRecord, Metrics>>("subscriptions/all/metrics", cancellationToken);
    }
}
