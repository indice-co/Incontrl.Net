using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Services
{
    internal class ContactsApi(ClientBase clientBase) : IContactsApi
    {
        public string SubscriptionId { get; set; }

        public Task<Contact> CreateAsync(Contact request, CancellationToken cancellationToken = default) =>
            clientBase.PostAsync<Contact, Contact>($"subscriptions/{SubscriptionId}/contacts", request, cancellationToken);

        public Task<ResultSet<Contact>> ListAsync(ListOptions<ContactFilter> options = null, CancellationToken cancellationToken = default) =>
            clientBase.GetAsync<ResultSet<Contact>>($"subscriptions/{SubscriptionId}/contacts", options, cancellationToken);
    }
}
