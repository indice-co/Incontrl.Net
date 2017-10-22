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

        public Task<Contact> GetAsync(CancellationToken cancellationToken = default(CancellationToken)) => 
            _clientBase.GetAsync<Contact>($"subscriptions/{SubscriptionId}/contact", cancellationToken);

        public Task<Contact> UpdateAsync(UpdateContactRequest request, CancellationToken cancellationToken = default(CancellationToken)) => 
            _clientBase.PutAsync<UpdateContactRequest, Contact>($"subscriptions/{SubscriptionId}/contact", request, cancellationToken);
    }
}
