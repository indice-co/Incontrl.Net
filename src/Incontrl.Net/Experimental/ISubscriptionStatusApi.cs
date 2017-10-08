using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Http;
using Incontrl.Net.Models;

namespace Incontrl.Net.Experimental
{
    public interface ISubscriptionStatusApi
    {
        string SubscriptionId { get; set; }
        Task<JsonResponse<SubscriptionStatus>> GetAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<JsonResponse<SubscriptionStatus>> UpdateAsync(UpdateSubscriptionStatusRequest status, CancellationToken cancellationToken = default(CancellationToken));
    }
}
