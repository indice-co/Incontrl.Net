using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Abstractions;
using Incontrl.Net.Http;
using Incontrl.Net.Models;

namespace Incontrl.Net.Services
{
    internal class SubscriptionContactApi : ISubscriptionContactApi
    {
        private ClientBase _clientBase;

        public SubscriptionContactApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }

        public async Task<Contact> GetAsync(CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.GetAsync<Contact>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{SubscriptionId}/contact", cancellationToken);

        public Task<Contact> UpdateAsync(UpdateContactRequest contact, CancellationToken cancellationToken = default(CancellationToken)) {
            throw new NotImplementedException();
        }
    }
}
