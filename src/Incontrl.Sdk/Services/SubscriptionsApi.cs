using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Incontrl.Sdk.Types;

namespace Incontrl.Sdk.Services
{
    internal class SubscriptionsApi : ISubscriptionsApi
    {
        private readonly ClientBase _clientBase;
        private readonly Lazy<IMetricsApi> _metricsApi;

        public SubscriptionsApi(ClientBase clientBase) {
            _clientBase = clientBase;
            _metricsApi = new Lazy<IMetricsApi>(() => new MetricsApi(_clientBase));
        }

        public bool GlobalAccess { get; set; }

        public Task<Subscription> CreateAsync(CreateSubscriptionRequest request, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.PostAsync<CreateSubscriptionRequest, Subscription>($"{_clientBase.ApiAddress}/subscriptions", request, cancellationToken);

        public Task<ResultSet<Subscription>> ListAsync(ListOptions<SubscriptionListFilter> options = null, CancellationToken cancellationToken = default(CancellationToken)) {
            if (GlobalAccess) {
                return _clientBase.GetAsync<ResultSet<Subscription>>($"{_clientBase.ApiAddress}/subscriptions/all", options, cancellationToken);
            }

            return _clientBase.GetAsync<ResultSet<Subscription>>($"{_clientBase.ApiAddress}/subscriptions", options, cancellationToken);
        }

        public IMetricsApi Metrics() => _metricsApi.Value;
    }
}
