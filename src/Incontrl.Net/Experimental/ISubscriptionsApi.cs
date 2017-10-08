using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Http;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Experimental
{
    public interface ISubscriptionsApi
    {
        Task<JsonResponse<ResultSet<Subscription>>> ListAsync(ListOptions<SubscriptionListFilter> options = null, CancellationToken cancellationToken = default(CancellationToken));
        Task<JsonResponse<Subscription>> CreateAsync(CreateSubscriptionRequest subscription, CancellationToken cancellationToken = default(CancellationToken));
    }
}
