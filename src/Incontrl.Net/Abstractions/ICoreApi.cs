using System;
using System.Threading.Tasks;
using Incontrl.Net.Models;

namespace Incontrl.Net.Abstractions
{
    /// <summary>
    /// Incontrl's core API interface.
    /// </summary>
    public interface ICoreApi
    {
        /// <summary>
        /// The Uri of the API.
        /// </summary>
        Uri ApiAddress { get; }

        /// <summary>
        /// Login by using your credentials as a user.
        /// </summary>
        /// <param name="userName">The user's name.</param>
        /// <param name="password">The user's password.</param>
        /// <param name="scopes">The scopes of the API to request.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task LoginAsync(string userName, string password, ScopeFlags scopes = ScopeFlags.Core);

        /// <summary>
        /// Login by using your client credentials.
        /// </summary>
        /// <param name="scopes">The scopes of the API to request.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task LoginAsync(ScopeFlags scopes = ScopeFlags.Core);

        /// <summary>
        /// Login by using a refresh token.
        /// </summary>
        /// <param name="refreshToken">The refresh token to use.</param>
        /// <param name="scopes">The scopes of the API to request.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task LoginAsync(string refreshToken, ScopeFlags scopes = ScopeFlags.Core);

        /// <summary>
        /// Creates an instance of class SubscriptionsApi, that provides functionality to list or create subscriptions.
        /// </summary>
        ISubscriptionsApi Subscriptions();

        /// <summary>
        /// Creates an instance of class SubscriptionApi, that gives access to a subscription's allowed operations.
        /// </summary>
        /// <param name="subscriptionId">The subscription's unique id.</param>
        ISubscriptionApi Subscription(Guid subscriptionId);

        /// <summary>
        /// Creates an instance of class SubscriptionApi, that gives access to a subscription's allowed operations.
        /// </summary>
        /// <param name="subscriptionAlias">The subscription's unique alias.</param>
        ISubscriptionApi Subscription(string subscriptionAlias);

        /// <summary>
        /// Creates an instance of class LicenseApi, that provides functionality to retrieve InContrl's license information.
        /// </summary>
        ILicenseApi License();

        /// <summary>
        /// Configures some settings for calling the API.
        /// </summary>
        /// <param name="apiAddress">The address of Incontrl's API.</param>
        /// <param name="authorityAddress">The address of the authority server.</param>
        ICoreApi Configure(string apiAddress, string authorityAddress = null);
    }
}
