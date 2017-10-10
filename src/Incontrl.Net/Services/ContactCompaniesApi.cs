using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Abstractions;
using Incontrl.Net.Http;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Services
{
    internal class ContactCompaniesApi : IContactCompaniesApi
    {
        private ClientBase _clientBase;

        public ContactCompaniesApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }
        public string ContactId { get; set; }

        public async Task<ResultSet<Organisation>> GetAsync(ListOptions<OrganisationFilter> options = null, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.GetAsync<ResultSet<Organisation>>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{SubscriptionId}/contacts/{ContactId}/companies", options, cancellationToken);
    }
}
