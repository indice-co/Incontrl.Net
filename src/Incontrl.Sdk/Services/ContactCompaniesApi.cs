using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Services
{
    internal class ContactCompaniesApi : IContactCompaniesApi
    {
        private readonly ClientBase _clientBase;

        public ContactCompaniesApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }
        public string ContactId { get; set; }

        public Task<ResultSet<Organisation>> ListAsync(ListOptions<OrganisationFilter> options = null, CancellationToken cancellationToken = default(CancellationToken)) => 
            _clientBase.GetAsync<ResultSet<Organisation>>($"subscriptions/{SubscriptionId}/contacts/{ContactId}/companies", options, cancellationToken);
    }
}
