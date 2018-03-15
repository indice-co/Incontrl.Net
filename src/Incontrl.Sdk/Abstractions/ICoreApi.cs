using System;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;
using Incontrl.Sdk.Services;

namespace Incontrl.Sdk.Abstractions
{
    /// <summary>
    /// Incontrl's APIs interface.
    /// </summary>
    public interface ICoreApi
    {
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
        /// Creates an instance of class <see cref="SubscriptionsApi"/>, that provides functionality to list or create subscriptions.
        /// </summary>
        ISubscriptionsApi Subscriptions();

        /// <summary>
        /// Creates an instance of class <see cref="SubscriptionApi"/>, that gives access to a subscription's allowed operations.
        /// </summary>
        /// <param name="subscriptionId">The subscription's unique id.</param>
        ISubscriptionApi Subscriptions(Guid subscriptionId);

        /// <summary>
        /// Creates an instance of class <see cref="SubscriptionApi"/>, that gives access to a subscription's allowed operations.
        /// </summary>
        /// <param name="subscriptionAlias">The subscription's unique alias.</param>
        ISubscriptionApi Subscriptions(string subscriptionAlias);

        /// <summary>
        /// Creates an instance of class <see cref="LicenseApi"/>, that provides functionality to retrieve InContrl's license information.
        /// </summary>
        ILicenseApi License();

        /// <summary>
        /// Creates an instance of class <see cref="AppsApi"/>, that provides functionality to manage applications.
        /// </summary>
        IAppsApi Apps();

        /// <summary>
        /// Creates an instance of class <see cref="UsersApi"/>, that provides functionality to manage users.
        /// </summary>
        IMembersApi Users();

        /// <summary>
        /// Creates an instance of class <see cref="AppApi"/>, that gives access to a applications's allowed operations.
        /// </summary>
        /// <param name="appId">The application's unique id.</param>
        IAppApi App(Guid appId);

        /// <summary>
        /// Creates an instance of class <see cref="LookupsApi"/>, that gives access to some of Incontrl lookups.
        /// </summary>
        ILookupsApi Lookups();

        /// <summary>
        /// Creates an instance of class <see cref="SubscriptionsApi"/>, that provides functionality to list or create subscriptions.
        /// </summary>
        /// <param name="globalAccess">Request global access for the request.</param>
        ISubscriptionsApi Subscriptions(bool globalAccess);

        /// <summary>
        /// Creates an instance of class <see cref="EmailApi"/>, that provides functionality to send email messages.
        /// </summary>
        /// <returns></returns>
        IEmailApi Email();
    }
}
