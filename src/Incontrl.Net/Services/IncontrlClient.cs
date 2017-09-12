using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Services
{
    public sealed class IncontrlClient
    {
        private ClientBase _clientBase;

        /// <summary>
        /// Class overloaded constructor.
        /// </summary>
        /// <param name="clientName">The name of the registered client.</param>
        /// <param name="clientSecret">The secret key of the client.</param>
        public IncontrlClient(string clientName, string clientSecret, string apiVersion = null) {
            _clientBase = new ClientBase(apiVersion == null ? Api.BaseAddress : $"{Api.BaseAddress}/{apiVersion}", clientName, clientSecret);
        }

        #region Subscriptions

        #region GET Operations
        /// <summary>
        /// Gets a list of all subscriptions.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<JsonResponse<ResultSet<SubscriptionInfo>>> GetSubscriptionsAsync(ListOptions<SubscriptionListFilter> options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.GetAsync<ResultSet<SubscriptionInfo>>(Api.EndPoints.GetSubscriptions, null, cancellationToken);

        /// <summary>
        /// Finds a subscription by it's unique id.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<JsonResponse<SubscriptionInfo>> GetSubscriptionByIdAsync(Guid subscriptionId, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.GetAsync<SubscriptionInfo>(string.Format(Api.EndPoints.GetSubscriptionById, subscriptionId), cancellationToken);


        /// <summary>
        /// Finds the company information for a specified subscription.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<JsonResponse<OrganisationInfo>> GetSubscriptionCompanyAsync(Guid subscriptionId, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.GetAsync<OrganisationInfo>(string.Format(Api.EndPoints.GetSubscriptionCompany, subscriptionId), cancellationToken);

        /// <summary>
        /// Finds the contact information for a specified subscription.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<JsonResponse<ContactInfo>> GetSubscriptionContactAsync(Guid subscriptionId, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.GetAsync<ContactInfo>(string.Format(Api.EndPoints.GetSubscriptionContact, subscriptionId), cancellationToken);

        /// <summary>
        /// Retrieves status information for a specified subscription.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<JsonResponse<SubscriptionStatusInfo>> GetSubscriptionStatusAsync(Guid subscriptionId, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.GetAsync<SubscriptionStatusInfo>(string.Format(Api.EndPoints.GetSubscriptionStatus, subscriptionId), cancellationToken);
        #endregion

        #region POST Operations
        /// <summary>
        /// Creates a new subscription.
        /// </summary>
        /// <param name="subscription">An object of type <see cref="CreateSubscriptionRequest"/> containing information about the new subscription.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<JsonResponse<SubscriptionInfo>> CreateSubscriptionAsync(CreateSubscriptionRequest subscription, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.PostAsync<CreateSubscriptionRequest, SubscriptionInfo>(Api.EndPoints.CreateSubscription, subscription, cancellationToken);
        #endregion

        #region PUT Operations
        /// <summary>
        /// Updates the company information for a specified subscription.
        /// </summary>
        /// <param name="company">An object of type <see cref="UpdateSubscriptionCompanyRequest"/> containing information about the subscription's company to be updated.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<JsonResponse<OrganisationInfo>> UpdateSubscriptionCompanyAsync(Guid subscriptionId, UpdateSubscriptionCompanyRequest company, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.PutAsync<UpdateSubscriptionCompanyRequest, OrganisationInfo>(string.Format(Api.EndPoints.UpdateSubscriptionCompany, subscriptionId), company, cancellationToken);

        /// <summary>
        /// Updates the status information for a specified subscription.
        /// </summary>
        /// <param name="status">An object of type <see cref="UpdateSubscriptionStatusRequest"/> containing information about the subscription's status to be updated.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<JsonResponse<SubscriptionStatusInfo>> UpdateSubscriptionStatusAsync(Guid subscriptionId, UpdateSubscriptionStatusRequest status, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.PutAsync<UpdateSubscriptionStatusRequest, SubscriptionStatusInfo>(string.Format(Api.EndPoints.UpdateSubscriptionStatus, subscriptionId), status, cancellationToken);
        #endregion

        #endregion
    }
}