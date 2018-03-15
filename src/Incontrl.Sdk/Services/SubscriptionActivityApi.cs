using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Services
{
    internal class SubscriptionActivityApi : ISubscriptionActivityApi
    {
        private readonly ClientBase _clientBase;

        public SubscriptionActivityApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }

        public Task<SubscriptionActivity> GetAsync(CancellationToken cancellationToken) =>
            _clientBase.GetAsync<SubscriptionActivity>($"subscriptions/{SubscriptionId}/activity", cancellationToken);
    }
}
