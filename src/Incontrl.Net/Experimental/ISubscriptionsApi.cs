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

        /// <summary>
        /// Creates a new subscription.
        /// </summary>
        /// <param name="subscription">An object of type <see cref="CreateSubscriptionRequest"/> containing information about the new subscription.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<JsonResponse<Subscription>> CreateAsync(CreateSubscriptionRequest subscription, CancellationToken cancellationToken = default(CancellationToken));
    }
}
