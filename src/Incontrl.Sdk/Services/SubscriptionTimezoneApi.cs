using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Services
{
    internal class SubscriptionTimeZoneApi(ClientBase clientBase) : ISubscriptionTimeZoneApi
    {
        public string SubscriptionId { get; set; }

        public Task<Subscription> UpdateAsync(UpdateSubscriptionTimeZoneRequest request, CancellationToken cancellationToken = default) =>
            clientBase.PutAsync<UpdateSubscriptionTimeZoneRequest, Subscription>($"subscriptions/{SubscriptionId}/time-zone", request, cancellationToken);
    }
}
