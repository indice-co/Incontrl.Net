using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Abstract;
using Incontrl.Net.Http;
using Incontrl.Net.Models;

namespace Incontrl.Net.Services
{
    internal class SubscriptionStatusApi : ISubscriptionStatusApi
    {
        private ClientBase _clientBase;

        public SubscriptionStatusApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }

        public async Task<JsonResponse<SubscriptionStatus>> GetAsync(CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.GetAsync<SubscriptionStatus>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{SubscriptionId}/status", cancellationToken);

        public async Task<JsonResponse<SubscriptionStatus>> UpdateAsync(UpdateSubscriptionStatusRequest status, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.PutAsync<UpdateSubscriptionStatusRequest, SubscriptionStatus>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{SubscriptionId}/status", status, cancellationToken);
    }
}
