using System;
using System.Threading.Tasks;
using Incontrl.Net.Abstractions;
using Incontrl.Net.Services;

namespace Incontrl.Net
{
    public sealed class IncontrlApi : ICoreApi
    {
        // Private fields.
        private ClientBase _clientBase;
        private Lazy<ISubscriptionsApi> _subscriptionsApi;
        private Lazy<ISubscriptionApi> _subscriptionApi;
        private Lazy<ILicenseApi> _licenseApi;

        /// <summary>
        /// Class overloaded constructor.
        /// </summary>
        /// <param name="appId">The unique of the client application.</param>
        /// <param name="apiKey">The unique api key of the client application.</param>
        /// <param name="apiVersion">The version of the api. If not specified, the newest version is used.</param>
        public IncontrlApi(string appId, string apiKey, string apiVersion = null) {
            _clientBase = new ClientBase(apiVersion == null ? Api.BASE_ADDRESS : $"{Api.BASE_ADDRESS}/{apiVersion}", appId, apiKey);
            // Lazy load available services.
            _subscriptionsApi = new Lazy<ISubscriptionsApi>(() => new SubscriptionsApi(_clientBase));
            _subscriptionApi = new Lazy<ISubscriptionApi>(() => new SubscriptionApi(_clientBase));
            _licenseApi = new Lazy<ILicenseApi>(() => new LicenseApi(_clientBase));
        }

        public ICoreApi Configure(string apiAddress, string authorityAddress = null) {
            _clientBase.ApiAddress = new Uri(apiAddress);
            if (authorityAddress != null)
                _clientBase.AuthorityAddress = new Uri(authorityAddress);
            return this;
        }

        public ILicenseApi License() => _licenseApi.Value;
        public Task LoginAsync(string userName, string password) => _clientBase.RequestResourceOwnerPasswordAsync(userName, password);
        public Task LoginAsync() => _clientBase.RequestClientCredentialsAsync();
        public Task LoginAsync(string refreshToken) => _clientBase.RequestRefreshTokenAsync(refreshToken);

        public ISubscriptionApi Subscription(Guid subscriptionId) {
            var subscriptionApi = _subscriptionApi.Value;
            subscriptionApi.SubscriptionId = subscriptionId.ToString();

            return subscriptionApi;
        }

        public ISubscriptionApi Subscription(string subscriptionAlias) {
            var subscriptionApi = _subscriptionApi.Value;
            subscriptionApi.SubscriptionId = subscriptionAlias;

            return subscriptionApi;
        }

        public ISubscriptionsApi Subscriptions() => _subscriptionsApi.Value;
    }
}
