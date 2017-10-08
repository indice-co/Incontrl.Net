using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Experimental;
using Incontrl.Net.Http;
using Incontrl.Net.Models;

namespace Incontrl.Net.Services
{
    internal class SubscriptionCompanyApi : ISubscriptionCompanyApi
    {
        private ClientBase _clientBase;

        public SubscriptionCompanyApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }

        public async Task<JsonResponse<Organisation>> GetAsync(CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.GetAsync<Organisation>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{SubscriptionId}/company", cancellationToken);

        public async Task<JsonResponse<Organisation>> UpdateAsync(UpdateCompanyRequest company, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.PutAsync<UpdateCompanyRequest, Organisation>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{SubscriptionId}/company", company, cancellationToken);
    }
}
