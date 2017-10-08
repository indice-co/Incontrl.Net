using System;
using System.Threading.Tasks;
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
            _subscriptionApi = new Lazy<ISubscriptionApi>(() => new SubscriptionApi(_clientBase));
        }

        public Task LoginAsync(string userName, string password) => _clientBase.LoginAsync(userName, password);

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
