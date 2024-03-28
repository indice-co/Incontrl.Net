using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Services
{
    internal class ContactCompaniesApi(ClientBase clientBase) : IContactCompaniesApi
    {
        public string SubscriptionId { get; set; }
        public string ContactId { get; set; }

        public Task<ResultSet<Organisation>> ListAsync(ListOptions<OrganisationFilter> options = null, CancellationToken cancellationToken = default) => 
            clientBase.GetAsync<ResultSet<Organisation>>($"subscriptions/{SubscriptionId}/contacts/{ContactId}/companies", options, cancellationToken);
    }
}
