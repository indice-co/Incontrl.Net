using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Abstract;
using Incontrl.Net.Http;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Services
{
    internal class ContactsApi : IContactsApi
    {
        private ClientBase _clientBase;

        public ContactsApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }

        public async Task<JsonResponse<Contact>> CreateAsync(CreateContactRequest contact, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.PostAsync<CreateContactRequest, Contact>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{SubscriptionId}/contacts", contact, cancellationToken);

        public async Task<JsonResponse<ResultSet<Contact>>> ListAsync(ListOptions<ContactFilter> options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.GetAsync<ResultSet<Contact>>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{SubscriptionId}/contacts", options, cancellationToken);
    }
}
