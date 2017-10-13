using System;
using System.Threading.Tasks;
using Incontrl.Net.Abstractions;
using Incontrl.Net.Services;

namespace Incontrl.Net
{
    public sealed class IncontrlApi : ICoreApi
    {
        // Private fields.
        private readonly ClientBase _clientBase;
        private readonly Lazy<ISubscriptionsApi> _subscriptionsApi;
        private readonly Lazy<ISubscriptionApi> _subscriptionApi;
        private readonly Lazy<ILicenseApi> _licenseApi;

        /// <summary>
        /// Class overloaded constructor.
        /// </summary>
        /// <param name="appId">The unique of the client application.</param>
        /// <param name="apiKey">The unique api key of the client application.</param>
        /// <param name="apiVersion">The version of the api. If not specified, the newest version is used.</param>
        public IncontrlApi(string appId, string apiKey, string apiVersion = null) {
            _clientBase = new ClientBase(apiVersion == null ? Api.BASE_ADDRESS : $"{Api.BASE_ADDRESS}/{apiVersion}", appId, apiKey);
            _subscriptionsApi = new Lazy<ISubscriptionsApi>(() => new SubscriptionsApi(_clientBase));
            _subscriptionApi = new Lazy<ISubscriptionApi>(() => new SubscriptionApi(_clientBase));
            _licenseApi = new Lazy<ILicenseApi>(() => new LicenseApi(_clientBase));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiAddress"></param>
        /// <param name="authorityAddress"></param>
        /// <returns></returns>
        public ICoreApi Configure(string apiAddress, string authorityAddress = null) {
            _clientBase.ApiAddress = new Uri(apiAddress);

            if (authorityAddress != null) {
                _clientBase.AuthorityAddress = new Uri(authorityAddress);
            }

            return this;
        }

        /// <summary>
        /// Creates an instance of class LicenseApi, that provides functionality to retrieve InContrl's license information.
        /// </summary>
        /// <returns></returns>
        public ILicenseApi License() => _licenseApi.Value;

        /// <summary>
        /// Login by using your credentials as a user.
        /// </summary>
        /// <param name="userName">The user's name.</param>
        /// <param name="password">The user's password.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        public Task LoginAsync(string userName, string password) => _clientBase.RequestResourceOwnerPasswordAsync(userName, password);

        /// <summary>
        /// Login by using your client credentials.
        /// </summary>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        public Task LoginAsync() => _clientBase.RequestClientCredentialsAsync();

        /// <summary>
        /// Login by using a refresh token.
        /// </summary>
        /// <param name="refreshToken">The refresh token to use.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        public Task LoginAsync(string refreshToken) => _clientBase.RequestRefreshTokenAsync(refreshToken);

        /// <summary>
        /// Creates an instance of class SubscriptionApi, that gives access to a subscription's allowed operations.
        /// </summary>
        /// <param name="subscriptionId">The subscription's unique id.</param>
        public ISubscriptionApi Subscription(Guid subscriptionId) {
            var subscriptionApi = _subscriptionApi.Value;
            subscriptionApi.SubscriptionId = subscriptionId.ToString();

            return subscriptionApi;
        }

        /// <summary>
        /// Creates an instance of class SubscriptionApi, that gives access to a subscription's allowed operations.
        /// </summary>
        /// <param name="subscriptionAlias">The subscription's unique alias.</param>
        /// <returns></returns>
        public ISubscriptionApi Subscription(string subscriptionAlias) {
            var subscriptionApi = _subscriptionApi.Value;
            subscriptionApi.SubscriptionId = subscriptionAlias;

            return subscriptionApi;
        }

        /// <summary>
        /// Creates an instance of class SubscriptionsApi, that provides functionality to list or create subscriptions.
        /// </summary>
        public ISubscriptionsApi Subscriptions() => _subscriptionsApi.Value;
    }
}
