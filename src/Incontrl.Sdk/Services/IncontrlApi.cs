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
        private readonly Lazy<IAppsApi> _appsApi;
        private readonly Lazy<IAppApi> _appApi;
        private readonly Lazy<ILookupsApi> _lookupsApi;

        public IncontrlApi(string appId, string apiKey) {
            _clientBase = new ClientBase(appId, apiKey);
            _subscriptionsApi = new Lazy<ISubscriptionsApi>(() => new SubscriptionsApi(_clientBase));
            _subscriptionApi = new Lazy<ISubscriptionApi>(() => new SubscriptionApi(_clientBase));
            _licenseApi = new Lazy<ILicenseApi>(() => new LicenseApi(_clientBase));
            _appsApi = new Lazy<IAppsApi>(() => new AppsApi(_clientBase));
            _appApi = new Lazy<IAppApi>(() => new AppApi(_clientBase));
            _lookupsApi = new Lazy<ILookupsApi>(() => new LookupsApi(_clientBase));
        }

        public Uri ApiAddress {
            get => _clientBase.ApiAddress;
            set => _clientBase.ApiAddress = value;
        }

        public Uri AuthorityAddress {
            get => _clientBase.AuthorityAddress;
            set => _clientBase.AuthorityAddress = value;
        }

        public IAppApi App(Guid appId) {
            var appApi = _appApi.Value;
            appApi.AppId = appApi.ToString();

            return appApi;
        }

        public IAppsApi Apps() => _appsApi.Value;

        public ILicenseApi License() => _licenseApi.Value;

        public Task LoginAsync(string userName, string password, ScopeFlags scopes = ScopeFlags.Core) => _clientBase.RequestResourceOwnerPasswordAsync(userName, password, scopes);

        public Task LoginAsync(ScopeFlags scopes = ScopeFlags.Core) => _clientBase.RequestClientCredentialsAsync(scopes);

        public Task LoginAsync(string refreshToken, ScopeFlags scopes = ScopeFlags.Core) => _clientBase.RequestRefreshTokenAsync(refreshToken, scopes);

        public ILookupsApi Lookups() => _lookupsApi.Value;

        public ISubscriptionApi Subscriptions(Guid subscriptionId) {
            var subscriptionApi = _subscriptionApi.Value;
            subscriptionApi.SubscriptionId = subscriptionId.ToString();

            return subscriptionApi;
        }

        public ISubscriptionApi Subscriptions(string subscriptionAlias) {
            var subscriptionApi = _subscriptionApi.Value;
            subscriptionApi.SubscriptionId = subscriptionAlias;

            return subscriptionApi;
        }

        public ISubscriptionsApi Subscriptions() => _subscriptionsApi.Value;

        public ISubscriptionsApi Subscriptions(bool globalAccess) {
            var subscriptionsApi = _subscriptionsApi.Value;
            subscriptionsApi.GlobalAccess = globalAccess;

            return subscriptionsApi;
        }
    }
}
