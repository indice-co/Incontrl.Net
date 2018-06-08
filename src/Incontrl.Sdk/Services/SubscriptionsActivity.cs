using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Indice.Types;

namespace Incontrl.Sdk.Services
{
    internal class SubscriptionsActivity : ISubscriptionsActivity
    {
        private readonly ClientBase _clientBase;

        public SubscriptionsActivity(ClientBase clientBase) => _clientBase = clientBase;

        public Task<ResultSet<Models.SubscriptionActivity>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.GetAsync<ResultSet<Models.SubscriptionActivity>>($"subscriptions/activity", options, cancellationToken);
    }
}
