using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Http;
using Incontrl.Net.Models;

namespace Incontrl.Net.Experimental
{
    public interface ISubscriptionApi
    {
        /// <summary>
        /// Finds a subscription by it's unique id.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<JsonResponse<Subscription>> GetAsync(CancellationToken cancellationToken = default(CancellationToken));

        ISubscriptionCompanyApi Company();
        ISubscriptionContactApi Contact();
        ISubscriptionStatusApi Status();
    }
}
