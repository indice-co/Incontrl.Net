using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Services
{
    internal class SubscriptionPlanApi : ISubscriptionPlanApi
    {
        private readonly Lazy<ISubscriptionPlanServicesApi> _subscriptionPlanServicesApi;
        private readonly ClientBase _clientBase;

        public SubscriptionPlanApi(ClientBase clientBase) {
            _clientBase = clientBase;
            _subscriptionPlanServicesApi = new Lazy<ISubscriptionPlanServicesApi>(() => new SubscriptionPlanServicesApi(clientBase));
        }

        public string SubscriptionId { get; set; }

        public Task<Plan> GetAsync(CancellationToken cancellationToken = default) =>
            _clientBase.GetAsync<Plan>($"subscriptions/{SubscriptionId}/plan", cancellationToken);

        public ISubscriptionPlanServicesApi Services(Guid serviceId) {
            var subscriptionPlanServicesApi = _subscriptionPlanServicesApi.Value;
            subscriptionPlanServicesApi.SubscriptionId = SubscriptionId;
            subscriptionPlanServicesApi.ServiceId = serviceId.ToString();
            return subscriptionPlanServicesApi;
        }

        public Task<Plan> UpdateAsync(Plan request, CancellationToken cancellationToken = default) =>
            _clientBase.PutAsync<Plan, Plan>($"subscriptions/{SubscriptionId}/plan", request, cancellationToken);
    }
}
