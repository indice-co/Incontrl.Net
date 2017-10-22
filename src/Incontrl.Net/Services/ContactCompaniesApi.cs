using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Abstractions;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Services
{
    internal class ContactCompaniesApi : IContactCompaniesApi
    {
        private readonly ClientBase _clientBase;

        public ContactCompaniesApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }
        public string ContactId { get; set; }

        public Task<ResultSet<Organisation>> GetAsync(ListOptions<OrganisationFilter> options = null, CancellationToken cancellationToken = default(CancellationToken)) => 
            _clientBase.GetAsync<ResultSet<Organisation>>($"subscriptions/{SubscriptionId}/contacts/{ContactId}/companies", options, cancellationToken);
    }
}
