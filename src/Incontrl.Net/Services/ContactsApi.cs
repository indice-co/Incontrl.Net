using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Abstractions;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Services
{
    internal class ContactsApi : IContactsApi
    {
        private readonly ClientBase _clientBase;

        public ContactsApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }

        public Task<Contact> CreateAsync(CreateContactRequest request, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.PostAsync<CreateContactRequest, Contact>($"subscriptions/{SubscriptionId}/contacts", request, cancellationToken);

        public Task<ResultSet<Contact>> ListAsync(ListOptions<ContactFilter> options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.GetAsync<ResultSet<Contact>>($"subscriptions/{SubscriptionId}/contacts", options, cancellationToken);
    }
}
