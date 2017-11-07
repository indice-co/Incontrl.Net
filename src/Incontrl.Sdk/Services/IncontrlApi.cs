using System;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Incontrl.Sdk.Services;

namespace Incontrl.Sdk
{
    public sealed class IncontrlApi : ICoreApi
    {
        private readonly ClientBase _clientBase;
        private readonly Lazy<ISubscriptionsApi> _subscriptionsApi;
        private readonly Lazy<ISubscriptionApi> _subscriptionApi;
        private readonly Lazy<ILicenseApi> _licenseApi;

        public IncontrlApi(string appId, string apiKey, string coreApiAddress = null, string authorityAddress = null, string apiVersion = null) {
            // Optional parameters coreApiAddress and authorityAddress are used to ovveride the production endpoints, so we can use the SDK for development.
            var apiAddress = string.IsNullOrEmpty(coreApiAddress) ? Api.CoreApiAddress : coreApiAddress;
            var authority = string.IsNullOrEmpty(authorityAddress) ? IdentityServerConstants.Authority : authorityAddress;
            _clientBase = new ClientBase(apiVersion == null ? apiAddress : $"{apiAddress}/{apiVersion}", authority, appId, apiKey);
            _subscriptionsApi = new Lazy<ISubscriptionsApi>(() => new SubscriptionsApi(_clientBase));
            _subscriptionApi = new Lazy<ISubscriptionApi>(() => new SubscriptionApi(_clientBase));
            _licenseApi = new Lazy<ILicenseApi>(() => new LicenseApi(_clientBase));
        }

        public Uri ApiAddress => _clientBase.ApiAddress;

        public ILicenseApi License() => _licenseApi.Value;

        public Task LoginAsync(string userName, string password, ScopeFlags scopes = ScopeFlags.Core) => _clientBase.RequestResourceOwnerPasswordAsync(userName, password, scopes);

        public Task LoginAsync(ScopeFlags scopes = ScopeFlags.Core) => _clientBase.RequestClientCredentialsAsync(scopes);

        public Task LoginAsync(string refreshToken, ScopeFlags scopes = ScopeFlags.Core) => _clientBase.RequestRefreshTokenAsync(refreshToken, scopes);

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

        public ISubscriptionsApi Subscriptions(bool globalAccess) => _subscriptionsApi.Value;
    }
}
