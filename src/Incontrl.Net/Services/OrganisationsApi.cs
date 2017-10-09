using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Abstract;
using Incontrl.Net.Http;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Services
{
    internal class OrganisationsApi : IOrganisationsApi
    {
        private ClientBase _clientBase;

        public OrganisationsApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }

        public async Task<JsonResponse<Organisation>> CreateAsync(CreateOrganisationRequest organisation, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.PostAsync<CreateOrganisationRequest, Organisation>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{SubscriptionId}/organisations", organisation, cancellationToken);

        public async Task<JsonResponse<ResultSet<Organisation>>> ListAsync(ListOptions<OrganisationFilter> options = null, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.GetAsync<ResultSet<Organisation>>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{SubscriptionId}/organisations", options, cancellationToken);
    }
}
