using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Services
{
    internal class SubscriptionStatusApi(ClientBase clientBase) : ISubscriptionStatusApi
    {
        public string SubscriptionId { get; set; }

        public async Task<SubscriptionStatus> GetAsync(CancellationToken cancellationToken = default) => 
            (await clientBase.GetAsync<SubscriptionStatusResponse>($"subscriptions/{SubscriptionId}/status", cancellationToken)).Status;

        public async Task<SubscriptionStatus> UpdateAsync(SubscriptionStatus request, CancellationToken cancellationToken = default) => 
            (await clientBase.PutAsync<UpdateSubscriptionStatusRequest, SubscriptionStatusResponse>($"subscriptions/{SubscriptionId}/status", new UpdateSubscriptionStatusRequest { Status = request }, cancellationToken)).Status;
    }
}
