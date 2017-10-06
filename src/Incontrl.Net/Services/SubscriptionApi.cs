using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Experimental;
using Incontrl.Net.Http;
using Incontrl.Net.Models;

namespace Incontrl.Net.Services
{
    internal class SubscriptionApi : ISubscriptionApi
    {
        private ClientBase _clientBase;
        private Guid _subscriptionId;

        public SubscriptionApi(ClientBase clientBase, Guid subscriptionId) {
            _clientBase = clientBase;
            _subscriptionId = subscriptionId;
        }

        public ISubscriptionCompanyApi Company() {
            throw new NotImplementedException();
        }

        public ISubscriptionContactApi Contact() {
            throw new NotImplementedException();
        }

        public async Task<JsonResponse<Subscription>> GetAsync(CancellationToken cancellationToken = default(CancellationToken)) {
            return await _clientBase.GetAsync<Subscription>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{_subscriptionId}", cancellationToken);
        }

        public ISubscriptionStatusApi Status() {
            throw new NotImplementedException();
        }
    }
}
