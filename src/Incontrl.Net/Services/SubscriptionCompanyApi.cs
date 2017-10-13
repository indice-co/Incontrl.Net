using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Abstractions;
using Incontrl.Net.Models;

namespace Incontrl.Net.Services
{
    internal class SubscriptionCompanyApi : ISubscriptionCompanyApi
    {
        private readonly ClientBase _clientBase;

        public SubscriptionCompanyApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }

        public async Task<Organisation> GetAsync(CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.GetAsync<Organisation>($"subscriptions/{SubscriptionId}/company", cancellationToken);

        public async Task<Organisation> UpdateAsync(UpdateCompanyRequest request, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.PutAsync<UpdateCompanyRequest, Organisation>($"subscriptions/{SubscriptionId}/company", request, cancellationToken);
    }
}
