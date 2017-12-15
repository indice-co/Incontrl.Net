using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Services
{
    internal class SubscriptionPlanApi : ISubscriptionPlanApi
    {
        private readonly ClientBase _clientBase;

        public SubscriptionPlanApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }

        public Task<Plan> GetAsync(CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.GetAsync<Plan>($"{_clientBase.ApiAddress}subscriptions/{SubscriptionId}/plan", cancellationToken);

        public Task<Plan> UpdateAsync(Plan request, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.PutAsync<Plan, Plan>($"{_clientBase.ApiAddress}subscriptions/{SubscriptionId}/plan", request, cancellationToken);
    }
}
