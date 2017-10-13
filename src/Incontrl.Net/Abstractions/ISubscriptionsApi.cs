using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Abstractions
{
    public interface ISubscriptionsApi
    {
        /// <summary>
        /// Retrieves a list of the available subscriptions.
        /// </summary>
        /// <param name="options">An object of type <see cref="ListOptions{SubscriptionListFilter}"/> that is used to paginate or filter the request.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<ResultSet<Subscription>> ListAsync(ListOptions<SubscriptionListFilter> options = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Creates a new subscription.
        /// </summary>
        /// <param name="request">An object of type <see cref="CreateSubscriptionRequest"/> that contains information about the subscription to create.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<Subscription> CreateAsync(CreateSubscriptionRequest request, CancellationToken cancellationToken = default(CancellationToken));
    }
}
