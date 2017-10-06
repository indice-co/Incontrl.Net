using System;
using Incontrl.Net.Experimental;
using Incontrl.Net.Services;

namespace Incontrl.Net
{
    public sealed class IncontrlApi : ICoreApi
    {
        // Private fields.
        private ClientBase _clientBase;
        private Lazy<ISubscriptionsApi> _subscriptionsApi;
        private Lazy<ISubscriptionApi> _subscriptionApi;

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
            //_subscriptionApi = new Lazy<ISubscriptionApi>(() => new SubscriptionApi(_clientBase));
        }

        public ISubscriptionApi Subscription(Guid subscriptionId) {
            throw new NotImplementedException();
        }

        public ISubscriptionApi Subscription(string subscriptionAlias) {
            throw new NotImplementedException();
        }

        public ISubscriptionsApi Subscriptions() => _subscriptionsApi.Value;
    }
}
