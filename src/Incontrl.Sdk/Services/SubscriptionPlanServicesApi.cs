using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Services
{
    internal class SubscriptionPlanServicesApi : ISubscriptionPlanServicesApi
    {
        private readonly ClientBase _clientBase;

        public SubscriptionPlanServicesApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }
        public string ServiceId { get; set; }

        public Task<Service> UpdateAsync(UpdateServiceRequest request, CancellationToken cancellationToken = default) => 
            _clientBase.PutAsync<UpdateServiceRequest, Service>($"subscriptions/{SubscriptionId}/plan/services/{ServiceId}", request, cancellationToken);
    }
}
