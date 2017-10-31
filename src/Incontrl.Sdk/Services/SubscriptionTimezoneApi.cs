using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Services
{
    internal class SubscriptionTimeZoneApi : ISubscriptionTimeZoneApi
    {
        private readonly ClientBase _clientBase;

        public SubscriptionTimeZoneApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }

        public Task<Subscription> UpdateAsync(UpdateSubscriptionTimeZoneRequest request, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.PutAsync<UpdateSubscriptionTimeZoneRequest, Subscription>($"subscriptions/{SubscriptionId}/time-zone", request, cancellationToken);
    }
}
