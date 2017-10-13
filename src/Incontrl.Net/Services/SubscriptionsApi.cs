using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Abstractions;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Services
{
    internal class SubscriptionsApi : ISubscriptionsApi
    {
        private readonly ClientBase _clientBase;

        public SubscriptionsApi(ClientBase clientBase) => _clientBase = clientBase;

        public async Task<Subscription> CreateAsync(CreateSubscriptionRequest request, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.PostAsync<CreateSubscriptionRequest, Subscription>("subscriptions", request, cancellationToken);

        public async Task<ResultSet<Subscription>> ListAsync(ListOptions<SubscriptionListFilter> options = null, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.GetAsync<ResultSet<Subscription>>("subscriptions", options, cancellationToken);
    }
}
