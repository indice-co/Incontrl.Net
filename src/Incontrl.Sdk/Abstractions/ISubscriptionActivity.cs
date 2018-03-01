using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Abstractions
{
    public interface ISubscriptionActivity
    {
        /// <summary>
        /// The id of the subscription.
        /// </summary>
        string SubscriptionId { get; set; }

        /// <summary>
        /// Retrieves the activity of the subscription.
        /// </summary>
        /// <param name="cancellationToken">Returns the task object representing the asynchronous operation.</param>
        /// <returns>>Returns the task object representing the asynchronous operation.</returns>
        Task<SubscriptionActivity> GetAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
