using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Services
{
    internal class SubscriptionCompanyApi : ISubscriptionCompanyApi
    {
        private readonly ClientBase _clientBase;

        public SubscriptionCompanyApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }

        public Task<Organisation> GetAsync(CancellationToken cancellationToken = default(CancellationToken)) => 
            _clientBase.GetAsync<Organisation>($"subscriptions/{SubscriptionId}/company", cancellationToken);

        public Task<Organisation> UpdateAsync(UpdateCompanyRequest request, CancellationToken cancellationToken = default(CancellationToken)) => 
            _clientBase.PutAsync<UpdateCompanyRequest, Organisation>($"subscriptions/{SubscriptionId}/company", request, cancellationToken);
    }
}
