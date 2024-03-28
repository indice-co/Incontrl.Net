using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Services
{
    internal class SubscriptionsApi : ISubscriptionsApi
    {
        private readonly ClientBase _clientBase;
        private readonly Lazy<IMetricsApi> _metricsApi;
        private readonly Lazy<IReportsApi> _reportsApi;
        private readonly Lazy<IGlobalPaymentOptionsApi> _globalPaymentOptionsApi;
        private readonly Lazy<IInvitationApi> _invitationApi;

        public SubscriptionsApi(Func<ClientBase> clientBaseFactory) {
            _clientBase = clientBaseFactory();
            _metricsApi = new Lazy<IMetricsApi>(() => new MetricsApi(_clientBase));
            _reportsApi = new Lazy<IReportsApi>(() => new ReportsApi(_clientBase));
            _globalPaymentOptionsApi = new Lazy<IGlobalPaymentOptionsApi>(() => new GlobalPaymentOptionsApi(_clientBase));
            _invitationApi = new Lazy<IInvitationApi>(() => new InvitationApi(_clientBase));
        }

        public bool GlobalAccess { get; set; }

        public IReportsApi Reports() => _reportsApi.Value;

        public IGlobalPaymentOptionsApi PaymentOptions() => _globalPaymentOptionsApi.Value;

        public IMetricsApi Metrics() => _metricsApi.Value;

        public Task<Subscription> CreateAsync(CreateSubscriptionRequest request, CancellationToken cancellationToken = default) =>
            _clientBase.PostAsync<CreateSubscriptionRequest, Subscription>("subscriptions", request, cancellationToken);

        public IInvitationApi Invitation(string invitationId) {
            var invitationApi = _invitationApi.Value;
            invitationApi.InvitationId = invitationId;

            return invitationApi;
        }

        public Task<ResultSet<Subscription>> ListAsync(ListOptions<SubscriptionListFilter> options = null, CancellationToken cancellationToken = default) {
            if (GlobalAccess) {
                return _clientBase.GetAsync<ResultSet<Subscription>>("subscriptions/all", options, cancellationToken);
            }

            return _clientBase.GetAsync<ResultSet<Subscription>>($"subscriptions", options, cancellationToken);
        }
    }
}
