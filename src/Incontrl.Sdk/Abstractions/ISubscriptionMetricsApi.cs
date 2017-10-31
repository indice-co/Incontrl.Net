using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;
using Incontrl.Sdk.Types;

namespace Incontrl.Sdk.Abstractions
{
    public interface ISubscriptionMetricsApi
    {
        /// <summary>
        /// 
        /// </summary>
        string SubscriptionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ResultSet<MetricsRecord, Metrics>> ListAsync(ListOptions<RangeFilter> options = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
