using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Abstractions;
using Incontrl.Net.Models;

namespace Incontrl.Net.Services
{
    internal class SubscriptionContactApi : ISubscriptionContactApi
    {
        private readonly ClientBase _clientBase;

        public SubscriptionContactApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }

        public async Task<Contact> GetAsync(CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.GetAsync<Contact>($"subscriptions/{SubscriptionId}/contact", cancellationToken);

        public async Task<Contact> UpdateAsync(UpdateContactRequest request, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.PutAsync<Contact, UpdateContactRequest>($"subscriptions/{SubscriptionId}/contact", request, cancellationToken);
    }
}
