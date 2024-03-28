using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Services
{
    internal class SubscriptionPlanServicesApi(ClientBase clientBase) : ISubscriptionPlanServicesApi
    {
        public string SubscriptionId { get; set; }
        public string ServiceId { get; set; }

        public Task<Service> UpdateAsync(UpdateServiceRequest request, CancellationToken cancellationToken = default) => 
            clientBase.PutAsync<UpdateServiceRequest, Service>($"subscriptions/{SubscriptionId}/plan/services/{ServiceId}", request, cancellationToken);
    }
}
