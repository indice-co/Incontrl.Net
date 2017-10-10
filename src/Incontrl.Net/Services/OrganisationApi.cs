using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Abstractions;
using Incontrl.Net.Http;
using Incontrl.Net.Models;

namespace Incontrl.Net.Services
{
    internal class OrganisationApi : IOrganisationApi
    {
        private ClientBase _clientBase;

        public OrganisationApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }
        public string OrganisationId { get; set; }

        public async Task<Organisation> GetAsync(CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.GetAsync<Organisation>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{SubscriptionId}/organisations/{OrganisationId}", cancellationToken);

        public async Task<Organisation> UpdateAsync(UpdateOrganisationRequest organisation, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.PutAsync<UpdateOrganisationRequest, Organisation>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{SubscriptionId}/organisations/{OrganisationId}", organisation, cancellationToken);
    }
}
