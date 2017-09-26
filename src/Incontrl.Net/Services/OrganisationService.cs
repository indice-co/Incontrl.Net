using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Abstract;
using Incontrl.Net.Http;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Services
{
    internal class OrganisationService : IOrganisationService
    {
        private ClientBase _clientBase;

        public OrganisationService(ClientBase clientBase) => _clientBase = clientBase;

        public async Task<JsonResponse<Organisation>> CreateAsync(Guid subscriptionId, CreateOrganisationRequest organisation, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.PostAsync<CreateOrganisationRequest, Organisation>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/organisations", organisation, cancellationToken);

        public async Task<JsonResponse<Organisation>> GetByIdAsync(Guid subscriptionId, Guid organisationId, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.GetAsync<Organisation>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/organisations/{organisationId}", cancellationToken);

        public async Task<JsonResponse<ResultSet<Organisation>>> GetAsync(Guid subscriptionId, ListOptions<OrganisationFilter> options = null, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.GetAsync<ResultSet<Organisation>>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/organisations", options, cancellationToken);

        public async Task<JsonResponse<Organisation>> UpdateAsync(Guid subscriptionId, Guid organisationId, UpdateOrganisationRequest organisation, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.PutAsync<UpdateOrganisationRequest, Organisation>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/organisations/{organisationId}", organisation, cancellationToken);
    }
}
