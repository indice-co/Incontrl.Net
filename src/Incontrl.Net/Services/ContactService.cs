using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Abstract;
using Incontrl.Net.Http;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Services
{
    internal class ContactService : IContactService
    {
        private ClientBase _clientBase;

        public ContactService(ClientBase clientBase) => _clientBase = clientBase;

        public async Task<JsonResponse<Contact>> CreateAsync(Guid subscriptionId, CreateContactRequest contact, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.PostAsync<CreateContactRequest, Contact>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/contacts", contact, cancellationToken);

        public async Task<JsonResponse<ResultSet<Organisation>>> GetCompaniesAsync(Guid subscriptionId, Guid contactId, ListOptions<OrganisationFilter> options = null, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.GetAsync<ResultSet<Organisation>>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/contacts/{contactId}/companies", options, cancellationToken);

        public async Task<JsonResponse<Contact>> GetByIdAsync(Guid subscriptionId, Guid contactId, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.GetAsync<Contact>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/contacts/{contactId}", cancellationToken);

        public async Task<JsonResponse<ResultSet<Contact>>> GetAsync(Guid subscriptionId, ListOptions<ContactFilter> options = null, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.GetAsync<ResultSet<Contact>>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/contacts", options, cancellationToken);

        public async Task<JsonResponse<Organisation>> UpdateAsync(Guid subscriptionId, Guid contactId, UpdateContactRequest contact, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.PutAsync<UpdateContactRequest, Organisation>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/contacts/{contactId}", contact, cancellationToken);
    }
}
