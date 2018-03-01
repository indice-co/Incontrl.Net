using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Incontrl.Sdk.Types;

namespace Incontrl.Sdk.Services
{
    internal class ContactsApi : IContactsApi
    {
        private readonly ClientBase _clientBase;

        public ContactsApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }

        public Task<Contact> CreateAsync(Contact request, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.PostAsync<Contact, Contact>($"subscriptions/{SubscriptionId}/contacts", request, cancellationToken);

        public Task<ResultSet<Contact>> ListAsync(ListOptions<ContactFilter> options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.GetAsync<ResultSet<Contact>>($"subscriptions/{SubscriptionId}/contacts", options, cancellationToken);
    }
}
