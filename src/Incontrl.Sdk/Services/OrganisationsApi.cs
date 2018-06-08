using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Services
{
    internal class OrganisationsApi : IOrganisationsApi
    {
        private readonly ClientBase _clientBase;

        public OrganisationsApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }

        public Task<Organisation> CreateAsync(Organisation request, CancellationToken cancellationToken = default(CancellationToken)) => 
            _clientBase.PostAsync<Organisation, Organisation>($"subscriptions/{SubscriptionId}/organisations", request, cancellationToken);

        public Task<ResultSet<Organisation>> ListAsync(ListOptions<OrganisationFilter> options = null, CancellationToken cancellationToken = default(CancellationToken)) => 
            _clientBase.GetAsync<ResultSet<Organisation>>($"subscriptions/{SubscriptionId}/organisations", options, cancellationToken);
    }
}
