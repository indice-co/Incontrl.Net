using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Abstractions
{
    public interface ISubscriptionStatusApi
    {
        string SubscriptionId { get; set; }

        /// <summary>
        /// Gets status information about the subscription.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<SubscriptionStatus> GetAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates the status information of the subscription.
        /// </summary>
        /// <param name="request">An enum of type <see cref="SubscriptionStatus"/> that describes the status of the subscription to update.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<SubscriptionStatus> UpdateAsync(SubscriptionStatus request, CancellationToken cancellationToken = default(CancellationToken));
    }
}
