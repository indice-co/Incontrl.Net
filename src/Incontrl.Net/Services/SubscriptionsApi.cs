using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Abstractions;
using Incontrl.Net.Http;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Services
{
    internal class SubscriptionsApi : ISubscriptionsApi
    {
        private ClientBase _clientBase;

        public SubscriptionsApi(ClientBase clientBase) => _clientBase = clientBase;

        public async Task<Subscription> CreateAsync(CreateSubscriptionRequest subscription, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.PostAsync<CreateSubscriptionRequest, Subscription>(Api.SUBSCRIPTION_ENDPOINTS_PREFIX, subscription, cancellationToken);

        public async Task<ResultSet<Subscription>> ListAsync(ListOptions<SubscriptionListFilter> options = null, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.GetAsync<ResultSet<Subscription>>(Api.SUBSCRIPTION_ENDPOINTS_PREFIX, options, cancellationToken);
    }
}
