using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Services
{
    internal class SubscriptionActivityApi(ClientBase clientBase) : ISubscriptionActivityApi
    {
        public string SubscriptionId { get; set; }

        public Task<SubscriptionActivity> GetAsync(CancellationToken cancellationToken) =>
            clientBase.GetAsync<SubscriptionActivity>($"subscriptions/{SubscriptionId}/activity", cancellationToken);
    }
}
