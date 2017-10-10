using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Abstractions;
using Incontrl.Net.Http;
using Incontrl.Net.Models;

namespace Incontrl.Net.Services
{
    internal class SubscriptionStatusApi : ISubscriptionStatusApi
    {
        private ClientBase _clientBase;

        public SubscriptionStatusApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }

        public async Task<SubscriptionStatus> GetAsync(CancellationToken cancellationToken = default(CancellationToken)) => 
            (await _clientBase.GetAsync<SubscriptionStatusResponse>($"subscriptions/{SubscriptionId}/status", cancellationToken)).Status;

        public async Task<SubscriptionStatus> UpdateAsync(SubscriptionStatus status, CancellationToken cancellationToken = default(CancellationToken)) => 
            (await _clientBase.PutAsync<UpdateSubscriptionStatusRequest, SubscriptionStatusResponse>($"subscriptions/{SubscriptionId}/status", new UpdateSubscriptionStatusRequest { Status = status }, cancellationToken)).Status;
    }
}
