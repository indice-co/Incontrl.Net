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
        private readonly Lazy<IGlobalPaymentOptionsApi> _globalPaymentOptionsApi;
        private readonly Lazy<IInvitationApi> _invitationApi;

        public SubscriptionsApi(Func<ClientBase> clientBaseFactory) {
            _clientBase = clientBaseFactory();
            _metricsApi = new Lazy<IMetricsApi>(() => new MetricsApi(_clientBase));
            _globalPaymentOptionsApi = new Lazy<IGlobalPaymentOptionsApi>(() => new GlobalPaymentOptionsApi(_clientBase));
            _invitationApi = new Lazy<IInvitationApi>(() => new InvitationApi(_clientBase));
        }

        public bool GlobalAccess { get; set; }

        public Task<Subscription> CreateAsync(CreateSubscriptionRequest request, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.PostAsync<CreateSubscriptionRequest, Subscription>("subscriptions", request, cancellationToken);

        public IInvitationApi Invitation(string invitationId) {
            var invitationApi = _invitationApi.Value;
            invitationApi.InvitationId = invitationId;

            return invitationApi;
        }

        public Task<ResultSet<Subscription>> ListAsync(ListOptions<SubscriptionListFilter> options = null, CancellationToken cancellationToken = default(CancellationToken)) {
            if (GlobalAccess) {
                return _clientBase.GetAsync<ResultSet<Subscription>>("subscriptions/all", options, cancellationToken);
            }

            return _clientBase.GetAsync<ResultSet<Subscription>>($"subscriptions", options, cancellationToken);
        }

        public IMetricsApi Metrics() => _metricsApi.Value;

        public IGlobalPaymentOptionsApi PaymentOptions() => _globalPaymentOptionsApi.Value;
    }
}
