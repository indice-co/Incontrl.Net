using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;

namespace Incontrl.Sdk.Services
{
    internal class SubscriptionActivity : ISubscriptionActivity
    {
        private readonly ClientBase _clientBase;

        public SubscriptionActivity(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }

        public Task<Models.SubscriptionActivity> GetAsync(CancellationToken cancellationToken) =>
            _clientBase.GetAsync<Models.SubscriptionActivity>($"subscriptions/{SubscriptionId}/activity", cancellationToken);
    }
}
