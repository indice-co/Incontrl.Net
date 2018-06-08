using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Abstractions
{
    public interface IMetricsApi
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ResultSet<MetricsRecord, Metrics>> ListAsync(ListOptions<RangeFilter> options = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
