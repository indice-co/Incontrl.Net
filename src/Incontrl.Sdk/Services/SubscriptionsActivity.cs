using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Indice.Types;

namespace Incontrl.Sdk.Services
{
    internal class SubscriptionsActivity(ClientBase clientBase) : ISubscriptionsActivity
    {
        public Task<ResultSet<Models.SubscriptionActivity>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default) =>
            clientBase.GetAsync<ResultSet<Models.SubscriptionActivity>>($"subscriptions/activity", options, cancellationToken);
    }
}
