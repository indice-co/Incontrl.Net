using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Abstractions;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Services
{
    internal class OrganisationsApi : IOrganisationsApi
    {
        private readonly ClientBase _clientBase;

        public OrganisationsApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }

        public async Task<Organisation> CreateAsync(CreateOrganisationRequest request, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.PostAsync<CreateOrganisationRequest, Organisation>($"subscriptions/{SubscriptionId}/organisations", request, cancellationToken);

        public async Task<ResultSet<Organisation>> ListAsync(ListOptions<OrganisationFilter> options = null, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.GetAsync<ResultSet<Organisation>>($"subscriptions/{SubscriptionId}/organisations", options, cancellationToken);
    }
}
