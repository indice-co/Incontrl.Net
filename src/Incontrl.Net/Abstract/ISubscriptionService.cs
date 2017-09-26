using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Http;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Abstract
{
    public interface ISubscriptionService
    {
        /// <summary>
        /// Gets a list of all subscriptions.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<JsonResponse<ResultSet<Subscription>>> GetAsync(ListOptions<SubscriptionListFilter> options = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Finds a subscription by it's unique id.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<JsonResponse<Subscription>> GetByIdAsync(Guid subscriptionId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Finds the company information for a specified subscription.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<JsonResponse<Organisation>> GetCompanyAsync(Guid subscriptionId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Finds the contact information for a specified subscription.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<JsonResponse<Contact>> GetContactAsync(Guid subscriptionId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Retrieves status information for a specified subscription.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<JsonResponse<SubscriptionStatus>> GetStatusAsync(Guid subscriptionId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Creates a new subscription.
        /// </summary>
        /// <param name="subscription">An object of type <see cref="CreateSubscriptionRequest"/> containing information about the new subscription.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<JsonResponse<Subscription>> CreateAsync(CreateSubscriptionRequest subscription, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates the company information for a specified subscription.
        /// </summary>
        /// <param name="company">An object of type <see cref="UpdateCompanyRequest"/> containing information about the subscription's company to be updated.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<JsonResponse<Organisation>> UpdateCompanyAsync(Guid subscriptionId, UpdateCompanyRequest company, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates the status information for a specified subscription.
        /// </summary>
        /// <param name="status">An object of type <see cref="UpdateSubscriptionStatusRequest"/> containing information about the subscription's status to be updated.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<JsonResponse<SubscriptionStatus>> UpdateStatusAsync(Guid subscriptionId, UpdateSubscriptionStatusRequest status, CancellationToken cancellationToken = default(CancellationToken));
    }
}
