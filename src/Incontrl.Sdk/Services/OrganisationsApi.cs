using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Services
{
    internal class OrganisationsApi(ClientBase clientBase) : IOrganisationsApi
    {
        public string SubscriptionId { get; set; }

        public Task<Organisation> CreateAsync(Organisation request, CancellationToken cancellationToken = default) => 
            clientBase.PostAsync<Organisation, Organisation>($"subscriptions/{SubscriptionId}/organisations", request, cancellationToken);

        public Task<ResultSet<Organisation>> ListAsync(ListOptions<OrganisationFilter> options = null, CancellationToken cancellationToken = default) => 
            clientBase.GetAsync<ResultSet<Organisation>>($"subscriptions/{SubscriptionId}/organisations", options, cancellationToken);
    }
}
